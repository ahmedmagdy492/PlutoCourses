using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PlutoDbContext _context;

        public CategoryRepository(PlutoDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category Add(Category category)
        {
            return _context.Categories.Add(category);
        }

        public bool Delete(Category category)
        {
            try
            {
                _context.Categories.Remove(category);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
