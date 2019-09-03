using EWallet.DataAcess.Interfaces;
using EWallet.DataAcess.Entities;
using EWallet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ExistingEmail(string email)
        {
            UserEntity user = _userRepository.GetUserByEmail(email);

            if (user == null)
                return false;
            return true;
        }
    }
}
