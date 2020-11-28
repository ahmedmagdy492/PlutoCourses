using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repository
{
    public interface IUserRepository
    {
        IEnumerable<Course> GetCoursesUserEnrolledIn(string userId);
        User GetUserById(string id);
        User GetUserByUsername(string username);
        User RegisterUser(User user);
    }
}