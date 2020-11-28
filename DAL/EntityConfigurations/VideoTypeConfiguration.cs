using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityConfigurations
{
    public class VideoTypeConfiguration : EntityTypeConfiguration<Video>
    {
        public VideoTypeConfiguration()
        {
            HasKey(v => v.Id);

            Property(v => v.Url)
                .IsRequired();

            HasRequired(v => v.Section)
                .WithMany(s => s.Videos)
                .HasForeignKey(v => v.SectionId);
        }
    }
}
