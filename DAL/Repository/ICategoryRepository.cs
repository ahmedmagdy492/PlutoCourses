using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repository
{
    public interface ICategoryRepository
    {
        Category Add(Category category);
        bool Delete(Category category);
        IEnumerable<Category> GetCategories();
    }
}