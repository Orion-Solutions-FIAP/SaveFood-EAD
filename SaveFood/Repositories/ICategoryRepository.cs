using SaveFood.Models;

namespace SaveFood.Repositories
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        bool Exist(Category category);
    }
}
