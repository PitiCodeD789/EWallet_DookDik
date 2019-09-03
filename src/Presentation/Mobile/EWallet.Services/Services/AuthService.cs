using EWallet.Core.Models.MobileAndApi.Auth;
using EWallet.Services.Interfaces;
using EWallet.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EWallet.Services.Services
{
    public class AuthService : BaseService, IAuthService 
    {
        private const string url = "http://10.0.2.2:30000/api/auth";

        public async Task<ResultServiceModel<CheckEmailResult>> SignIn(string email)
        {
            CheckEmailModel model = new CheckEmailModel()
            {
                Email = email
            };

            return await Post<CheckEmailResult>(url, model);
        }


    }
}
