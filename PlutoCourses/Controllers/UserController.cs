using DAL;
using DAL.Repository;
using PlutoCourses.ViewModels;
using System;
using System.Collections.Generic;
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
            var currentUser = _userRepository.GetUserByUsername(User.Identity.Name);
            var userPreferedTags = _userRepository.GetUserPreferedTags(currentUser.Id);

            var model = new ProfileViewModel
            {
                CurrentUser = currentUser,
                MyTags = userPreferedTags
            };
            return View(model);
        }
    }
}