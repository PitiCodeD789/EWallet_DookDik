using EWallet.DataAcess.Contexts;
using EWallet.DataAcess.Entities;
using EWallet.DataAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWallet.DataAcess.Repositories
{
    public class OtpRepository : IOtpRepository
    {
        private readonly EWalletContext _context;
        public OtpRepository(EWalletContext context)
        {
            _context = context;
        }

        public bool AddOtp(OtpEntity entity)
        {
            try
            {
                var now = DateTime.UtcNow;
                entity.CreateDateTime = now;
                entity.UpdateDateTime = now;

                _context.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not add otp => ", ex.Message);
                return false;
            }

        }

        public OtpEntity GetOtpByEmail(string email)
        {
            return _context.Otp.FirstOrDefault(x => x.Email == email);
        }

        public bool UpdateOtp(OtpEntity otp)
        {

            try
            {
                OtpEntity entity = _context.Otp.Find(otp.Id);

                entity.Otp = otp.Otp;
                entity.Reference = otp.Reference;
                entity.UpdateDateTime = DateTime.UtcNow;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not update otp => ", ex.Message);
                return false;
            }
        }
    }
}
