using SaveFood.Models;
using System.Collections.Generic;

namespace SaveFood.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IList<Product> SearchByUserIdAndStatus(int userId, Status status = Status.Enabled);
    }
}
