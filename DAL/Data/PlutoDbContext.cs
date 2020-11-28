using DAL.EntityConfigurations;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL.Data
{
    public class PlutoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Video> Videos { get; set; }

        public PlutoDbContext() : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserTypeConfiguration());
            modelBuilder.Configurations.Add(new TagTypeConfiguration());
            modelBuilder.Configurations.Add(new CategoryTypeConfiguration());
            modelBuilder.Configurations.Add(new CourseTypeConfiguration());
            modelBuilder.Configurations.Add(new SectionTypeConfiguration());
            modelBuilder.Configurations.Add(new VideoTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
