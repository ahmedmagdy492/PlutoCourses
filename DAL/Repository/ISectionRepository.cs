using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repository
{
    public interface ISectionRepository
    {
        Section AddSectionToCourse(string courseId, Section section);
        Section GetSectionOfCourse(string courseId, string sectionId);
        IEnumerable<Section> GetSectionsOfCourse(string courseId);
        bool RemoveSectionFromCourse(Section section);
    }
}