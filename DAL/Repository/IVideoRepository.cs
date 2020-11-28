using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repository
{
    public interface IVideoRepository
    {
        Video AddVideoToSection(string sectionId, Video video);
        Video GetVideo(string videoId);
        IEnumerable<Video> GetVideosOfSection(string sectionId);
        bool RemoveVideoFromSection(Video video);
    }
}