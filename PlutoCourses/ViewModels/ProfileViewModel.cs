using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlutoCourses.ViewModels
{
    public class ProfileViewModel
    {
        public User CurrentUser { get; set; }
        public IEnumerable<Tag> MyTags { get; set; }
    }
}