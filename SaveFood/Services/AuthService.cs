using SaveFood.Models;
using SaveFood.Repositories;
using SaveFood.Services.Enums;

namespace SaveFood.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public AuthStatus ValidateUser(User currentUser)
        {
            var user = _userRepository.SearchByEmail(currentUser.Email);
            if (user == null)
                return AuthStatus.UserNotFound;

            currentUser.Salt = user.Salt;
            currentUser.EncryptPassword();

            if (user.Password != currentUser.Password)
                return AuthStatus.WrongPassword;

            return AuthStatus.Authorized;
        }
    }
}
