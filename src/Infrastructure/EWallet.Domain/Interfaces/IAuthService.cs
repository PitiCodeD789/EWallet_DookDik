using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Interfaces
{
    public interface IAuthService
    {
        bool ExistingEmail(string email);
    }
}
