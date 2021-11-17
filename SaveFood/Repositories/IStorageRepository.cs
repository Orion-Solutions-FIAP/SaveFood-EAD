using SaveFood.Models;

namespace SaveFood.Repositories
{
    public interface IStorageRepository : IRepositoryBase<Storage>
    {
        bool Exist(Storage storage);
    }
}
