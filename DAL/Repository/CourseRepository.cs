using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly PlutoDbContext _context;

        public CourseRepository(PlutoDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public IEnumerable<Course> GetCoursesOfCategory(int CategoryId)
        {
            return _context.Courses.Where(c => c.CategoryId == CategoryId).ToList();
        }

        public IEnumerable<Course> GetCoursesOfAuthor(string authorId)
        {
            return _context.Courses.Where(c => c.AuthorId == authorId);
        }

        public IEnumerable<Course> GetCoursesOfTag(string tagId)
        {
            var tag = _context.Tags.Include("Courses").FirstOrDefault(t => t.Id == tagId);

            if(tag != null)
            {
                return tag.Courses.ToList();
            }
            return new List<Course>();
        }

        public Course GetById(string courseId)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == courseId);
        }

        public Course Add(string userId, Course course)
        {
            course.AuthorId = userId;
            return _context.Courses.Add(course);
        }

        public bool Delete(Course course)
        {
            try
            {
                _context.Courses.Remove(course);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Course course)
        {
            try
            {
                _context.Entry(course).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
