using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repository
{
    public interface ICourseRepository
    {
        Course Add(string userId, Course course);
        bool Delete(Course course);
        Course GetById(string courseId);
        IEnumerable<Course> GetCourses();
        IEnumerable<Course> GetCoursesOfAuthor(string authorId);
        IEnumerable<Course> GetCoursesOfCategory(int CategoryId);
        IEnumerable<Course> GetCoursesOfTag(string tagId);
        bool Update(Course course);
    }
}