using DAL.Models;
using System;
using System.Data.Entity.ModelConfiguration;

namespace DAL.EntityConfigurations
{
    public class CourseTypeConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseTypeConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            HasRequired(c => c.User)
                .WithMany(u => u.Courses)
                .HasForeignKey(c => c.AuthorId);
        }
    }
}
