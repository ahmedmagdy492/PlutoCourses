using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Course
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float Duration { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public string AuthorId { get; set; }
        public string BannerImgUrl { get; set; }

        public User User { get; set; }
        public Category Category { get; set; }
        public IList<Tag> Tags { get; set; }
        public IList<User> EnrolledUsers { get; set; }
        public IList<Section> Sections { get; set; }
    }
}
