using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly PlutoDbContext _context;

        public TagRepository(PlutoDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Tag> GetTags()
        {
            return _context.Tags.ToList();
        }

        public Tag AddTag(Tag tag)
        {
            return _context.Tags.Add(tag);
        }

        private Tag GetTagById(string tagId)
        {
            return _context.Tags.FirstOrDefault(t => t.Id == tagId);
        }

        public IEnumerable<Tag> GetTagsOfCourse(string courseId)
        {
            var course = _context.Courses.Include("Tags").FirstOrDefault(c => c.Id == courseId);

            if (course != null)
            {
                return course.Tags.ToList();
            }
            return new List<Tag>();
        }

        public bool AddTagToCourse(string courseId, string tagId)
        {
            var tag = GetTagById(tagId);
            var course = _context.Courses.Include("Tags").FirstOrDefault(c => c.Id == courseId);

            if (tag != null && course != null)
            {
                course.Tags.Add(tag);
                return true;
            }
            return false;
        }
    }
}
