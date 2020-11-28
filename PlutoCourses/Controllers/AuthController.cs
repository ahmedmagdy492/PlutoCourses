using DAL;
using DAL.Models;
using DAL.Repository;
using PlutoCourses.Services;
using PlutoCourses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace PlutoCourses.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashingService _hashingService;

        public AuthController(
            IUnitOfWork unitOfWork,
            IHashingService hashingService
            )
        {
            _userRepository = unitOfWork.UserRepository;
            this._unitOfWork = unitOfWork;
            _hashingService = hashingService;
        }

        // GET: /Auth/Login
        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _userRepository.GetUserByUsername(model.Username);

            if (user == null)
            {
                ModelState.AddModelError("Username", "Invalid Username");
                return View(model);
            }

            // hashing the password
            string hashedPass = Converter.ConvertToHexa(_hashingService.Hash(model.Password));

            if(user.Password != hashedPass)
            {
                ModelState.AddModelError("Password", "Incorrect Password");
                return View(model);
            }

            var identity = new ClaimsIdentity("CookieAuthentication");
            identity.AddClaims(
                new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.Username),
                    new Claim(ClaimTypes.Name, user.Name)
                }
            );

            HttpContext.GetOwinContext().Authentication.SignIn(identity);

            return RedirectToAction("Profile", "User");
        }

        [HttpPost]
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut("CookieAuthentication");
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existingUser = _userRepository.GetUserByUsername(model.Username);

            if(existingUser != null)
            {
                ModelState.AddModelError("Username", "Username is already taken");
                return View(model);
            }

            string hashedPass = Converter.ConvertToHexa(_hashingService.Hash(model.Password));
            var user = new User
            {
                Name = model.Name,
                Username = model.Username,
                Password = hashedPass
            };

            if (model.Image != null)
            {
                user.ImageUrl = Utility.SaveImage(model.Image, HttpContext);
            }

            _userRepository.RegisterUser(user);
            _unitOfWork.Save();

            return RedirectToAction("Login");
        }
    }
}