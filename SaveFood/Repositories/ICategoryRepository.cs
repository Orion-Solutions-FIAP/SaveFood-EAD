using SaveFood.Models;
using System.Collections.Generic;

namespace SaveFood.Repositories
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        bool Exist(Category category);
        IList<Category> SearchByUserId(int userId);
    }
}
