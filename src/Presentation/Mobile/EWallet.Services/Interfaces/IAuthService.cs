using EWallet.Core.Models.MobileAndApi.Auth;
using EWallet.Mobile.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EWallet.Mobile.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResultServiceModel<CheckEmailResult>> SignIn(string email);
    }
}
