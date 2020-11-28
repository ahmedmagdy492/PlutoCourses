using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Section
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }
        public IList<Video> Videos { get; set; }
    }
}
