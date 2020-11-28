using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Video
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string SectionId { get; set; }
        public Section Section { get; set; }
    }
}
