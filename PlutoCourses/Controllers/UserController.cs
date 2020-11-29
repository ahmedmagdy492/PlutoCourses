using DAL;
using DAL.Repository;
using PlutoCourses.Services;
using PlutoCourses.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlutoCourses.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly ITagRepository _tagRepository;

        public UserController(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.UserRepository;
            _tagRepository = _unitOfWork.TagRepository;
        }

        // GET: User
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Response.Cache.SetNoStore();

            var currentUser = _userRepository.GetUserByUsername(User.Identity.Name);
            var userPreferedTags = _userRepository.GetUserPreferedTags(currentUser.Id);

            var model = new ProfileViewModel
            {
                CurrentUser = currentUser,
                MyTags = userPreferedTags
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult UpdateProfileImage(HttpPostedFileBase img)
        {
            if (img == null)
                return Json(new { msg = "Image is null" });

            try
            {
                var uploadedImage = Image.FromStream(img.InputStream);
                string imgPath = Utility.SaveImage(img, HttpContext);

                // getting the current user
                var currentUser = _userRepository.GetUserByUsername(User.Identity.Name);
                currentUser.ImageUrl = imgPath;
                var isUpdatedSuccessfully = _userRepository.Update(currentUser);

                if(isUpdatedSuccessfully)
                {
                    _unitOfWork.Save();
                }

                return Json(new { msg = "Uploaded Successfully", url = imgPath });
            }
            catch(Exception)
            {
                return Json(new { msg = "Invalid Image" });
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult UpdateUserData(UserProfileDataViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { msg = "username and name cannot be empty" });

            var currentUser = _userRepository.GetUserByUsername(User.Identity.Name);

            if(currentUser != null)
            {
                currentUser.Name = model.Name;
                currentUser.Username = model.Username;
                _userRepository.Update(currentUser);
                _unitOfWork.Save();
                return Json(new { msg = "Changes are Applied Successfully" });
            }
            return Json(new { msg = "an error has occured" });
        }
    }
}