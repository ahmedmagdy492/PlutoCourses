using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlutoCourses.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
    }
}