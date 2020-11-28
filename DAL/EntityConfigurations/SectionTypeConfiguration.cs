using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityConfigurations
{
    public class SectionTypeConfiguration : EntityTypeConfiguration<Section>
    {
        public SectionTypeConfiguration()
        {
            HasKey(s => s.Id);

            Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(40);

            HasRequired(s => s.Course)
                .WithMany(s => s.Sections)
                .HasForeignKey(s => s.CourseId);
        }
    }
}
