using SaveFood.Models;
using SaveFood.Services.Enums;

namespace SaveFood.Services
{
    public interface IAuthService
    {
        AuthStatus ValidateUser(User currentUser);
    }
}
