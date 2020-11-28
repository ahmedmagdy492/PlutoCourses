using DAL.Data;
using DAL.Repository;
using System;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlutoDbContext _context;
        private ICategoryRepository categoryRepository;
        private ICourseRepository courseRepository;
        private ISectionRepository sectionRepository;
        private ITagRepository tagRepository;
        private IUserRepository userRepository;
        private IVideoRepository videoRepository;

        public UnitOfWork(PlutoDbContext context)
        {
            this._context = context;
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(_context);
                return categoryRepository;
            }
        }

        public ICourseRepository CourseRepository
        {
            get
            {
                if (courseRepository == null)
                    courseRepository = new CourseRepository(_context);
                return courseRepository;
            }
        }

        public ISectionRepository SectionRepository
        {
            get
            {
                if (sectionRepository == null)
                    sectionRepository = new SectionRepository(_context);
                return sectionRepository;
            }
        }

        public ITagRepository TagRepository
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepository(_context);
                return tagRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_context);
                return userRepository;
            }
        }

        public IVideoRepository VideoRepository
        {
            get
            {
                if (videoRepository == null)
                    videoRepository = new VideoRepository(_context);
                return videoRepository;
            }
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
