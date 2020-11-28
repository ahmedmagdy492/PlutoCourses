using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityConfigurations
{
    public class TagTypeConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagTypeConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);


            HasMany(t => t.Users)
                .WithMany(u => u.Tags)
                .Map(m =>
                {
                    m.ToTable("UserPreferedTags");
                    m.MapLeftKey("TagId");
                    m.MapRightKey("UserId");
                });

            HasMany(t => t.Courses)
                .WithMany(c => c.Tags)
                .Map(m => {
                    m.ToTable("CourseTags");
                    m.MapLeftKey("TagId");
                    m.MapRightKey("CourseId");
                });
        }
    }
}
