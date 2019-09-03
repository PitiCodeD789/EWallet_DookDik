using EWallet.DataAcess.Contexts;
using EWallet.DataAcess.Interfaces;
using EWallet.DataAcess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWallet.DataAcess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EWalletContext _context;
        public UserRepository(EWalletContext context)
        {
            _context = context;
        }

        public UserEntity GetUserByEmail(string email)
        {
            UserEntity user = _context.User.FirstOrDefault(x => x.Email == email.ToLower());
            return user;
        }
    }
}
