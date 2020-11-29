using DAL;
using DAL.Models;
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
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;

        public CourseController(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
            _courseRepository = _unitOfWork.CourseRepository;
            _userRepository = _unitOfWork.UserRepository;
        }

        // GET: Course
        [HttpGet]
        public ActionResult Index(string categoryName)
        {
            CoursesViewModel model = null;
            if (categoryName != null)
            {
                model = new CoursesViewModel
                {
                    Courses = _courseRepository.GetCourses().Where(c => c.Category.Name == categoryName).ToList()
                };
                return View(model);
            }
            
            model = new CoursesViewModel
            {
                Courses = _courseRepository.GetCourses()
            };
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult MyCourses()
        {
            var author = _userRepository.GetUserByUsername(User.Identity.Name);
            var authorCourses = _courseRepository.GetCoursesOfAuthor(author.Id);
            var coursesViewModel = new CoursesViewModel
            {
                Courses = authorCourses
            };
            return View(coursesViewModel);
        }
    }
}