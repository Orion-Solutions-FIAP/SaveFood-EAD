using SaveFood.Models;

namespace SaveFood.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User SearchByEmail(string email);
    }
}
