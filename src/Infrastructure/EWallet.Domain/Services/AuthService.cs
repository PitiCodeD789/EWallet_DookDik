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
        private readonly IOtpRepository _otpRepository;


        public AuthService(IUserRepository userRepository, 
                            IOtpRepository otpRepository)
        {
            _userRepository = userRepository;
            _otpRepository = otpRepository;
        }

        public bool ExistingEmail(string email)
        {
            UserEntity user = _userRepository.GetUserByEmail(email);

            if (user == null)
                return false;
            return true;
        }

        public bool SaveOtp(string email, string refNumber, string otpNumber)
        {
            //
            OtpEntity otp = _otpRepository.GetOtpByEmail(email);

            if (otp == null)
            {
                otp = new OtpEntity()
                {
                    Email = email,
                    Reference = refNumber,
                    Otp = otpNumber,
                };

                return _otpRepository.AddOtp(otp);
            }
            else
            {
                otp.Otp = otpNumber;
                otp.Reference = refNumber;

                object obj = new { otp.Otp, otp.Reference, UpdateDateTime = DateTime.UtcNow };

                return _otpRepository.UpdateOtp(obj, otp.Id);
            }


            
        }
    }
}
