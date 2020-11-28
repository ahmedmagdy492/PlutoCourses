using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        
        public IList<Tag> Tags { get; set; }
        public IList<Course> Courses { get; set; }
        public IList<Course> EnrolledCourses { get; set; }
    }
}
