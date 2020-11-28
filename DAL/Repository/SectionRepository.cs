using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class SectionRepository : ISectionRepository
    {
        private readonly PlutoDbContext _context;

        public SectionRepository(PlutoDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Section> GetSectionsOfCourse(string courseId)
        {
            return _context.Sections.Where(s => s.CourseId == courseId).ToList();
        }

        public Section GetSectionOfCourse(string courseId, string sectionId)
        {
            return _context.Sections.FirstOrDefault(s => s.CourseId == courseId && s.Id == sectionId);
        }

        public Section AddSectionToCourse(string courseId, Section section)
        {
            section.CourseId = courseId;
            return _context.Sections.Add(section);
        }

        public bool RemoveSectionFromCourse(Section section)
        {
            try
            {
                _context.Sections.Remove(section);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
