using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class VideoRepository : IVideoRepository
    {
        private readonly PlutoDbContext _context;

        public VideoRepository(PlutoDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Video> GetVideosOfSection(string sectionId)
        {
            return _context.Videos.Where(v => v.SectionId == sectionId).ToList();
        }

        public Video GetVideo(string videoId)
        {
            return _context.Videos.FirstOrDefault(v => v.Id == videoId);
        }

        public Video AddVideoToSection(string sectionId, Video video)
        {
            video.SectionId = sectionId;
            return _context.Videos.Add(video);
        }

        public bool RemoveVideoFromSection(Video video)
        {
            try
            {
                _context.Videos.Remove(video);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
