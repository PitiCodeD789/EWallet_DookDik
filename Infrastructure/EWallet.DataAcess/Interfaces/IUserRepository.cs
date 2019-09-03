using System;
using System.Collections.Generic;
using System.Text;
using EWallet.DataAcess.Entities;

namespace EWallet.DataAcess.Interfaces
{
    public interface IUserRepository
    {
        UserEntity GetUserByEmail(string email);
    }
}
