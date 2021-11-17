using Microsoft.AspNetCore.Authentication.Cookies;
using SaveFood.Models;
using SaveFood.Repositories;
using SaveFood.Services.Enums;
using System.Collections.Generic;
using System.Security.Claims;

namespace SaveFood.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ClaimsPrincipal CreateAuth(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            return new ClaimsPrincipal(new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme));
        }

        public (AuthStatus, User) ValidateUser(User currentUser)
        {
            var user = _userRepository.SearchByEmail(currentUser.Email);
            if (user == null)
                return (AuthStatus.UserNotFound, null);

            currentUser.Salt = user.Salt;
            currentUser.EncryptPassword();

            if (user.Password != currentUser.Password)
                return (AuthStatus.WrongPassword, null);

            return (AuthStatus.Authorized, user);
        }
    }
}
