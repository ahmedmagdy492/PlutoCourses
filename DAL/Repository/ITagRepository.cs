using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repository
{
    public interface ITagRepository
    {
        Tag AddTag(Tag tag);
        bool AddTagToCourse(string courseId, string tagId);
        IEnumerable<Tag> GetTags();
        IEnumerable<Tag> GetTagsOfCourse(string courseId);
    }
}