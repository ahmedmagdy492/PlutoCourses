using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Tag
    {
        public Tag()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public IList<User> Users { get; set; }
        public IList<Course> Courses { get; set; }
    }
}
