using System;
using System.Collections.Generic;
using System.Text;
using EWallet.DataAcess.Entities;

namespace EWallet.DataAcess.Interfaces
{
    public interface IOtpRepository
    {
        bool AddOtp(OtpEntity entity);
        OtpEntity GetOtpByEmail(string email);
        bool UpdateOtp(OtpEntity otp);
    }
}
