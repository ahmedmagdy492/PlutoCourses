﻿using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PlutoDbContext _context;

        public UserRepository(PlutoDbContext context)
        {
            this._context = context;
        }

        public User GetUserById(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public User RegisterUser(User user)
        {
            return _context.Users.Add(user);
        }

        public bool Update(User user)
        {
            try
            {
                _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Course> GetCoursesUserEnrolledIn(string userId)
        {
            var user = GetUserById(userId);

            if (user != null)
            {
                return user.EnrolledCourses;
            }
            return new List<Course>();
        }

        public IEnumerable<Tag> GetUserPreferedTags(string userId)
        {
            var user = GetUserById(userId);

            if(user != null)
            {
                return user.Tags;
            }
            return new List<Tag>();
        }
    }
}
