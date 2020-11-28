using DAL.Repository;

namespace DAL
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ICourseRepository CourseRepository { get; }
        ISectionRepository SectionRepository { get; }
        ITagRepository TagRepository { get; }
        IUserRepository UserRepository { get; }
        IVideoRepository VideoRepository { get; }
        bool Save();
    }
}