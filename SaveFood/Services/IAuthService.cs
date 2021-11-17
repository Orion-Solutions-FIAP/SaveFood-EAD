using SaveFood.Models;
using SaveFood.Services.Enums;
using System.Security.Claims;

namespace SaveFood.Services
{
    public interface IAuthService
    {
        (AuthStatus, User) ValidateUser(User currentUser);
        ClaimsPrincipal CreateAuth(User user);
    }
}
