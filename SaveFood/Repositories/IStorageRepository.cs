using SaveFood.Models;
using System.Collections;
using System.Collections.Generic;

namespace SaveFood.Repositories
{
    public interface IStorageRepository : IRepositoryBase<Storage>
    {
        bool Exist(Storage storage);
        IList<Storage> SearchByUserId(int userId);
    }
}
