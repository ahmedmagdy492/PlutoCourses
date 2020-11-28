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

        public CourseController(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
            _courseRepository = _unitOfWork.CourseRepository;
        }

        // GET: Course
        public ActionResult Index()
        {
            var model = new CoursesViewModel
            {
                Courses = _courseRepository.GetCourses()
            };
            return View(model);
        }
    }
}