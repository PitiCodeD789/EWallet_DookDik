using EWallet.DataAcess.Contexts;
using EWallet.DataAcess.Entities;
using EWallet.DataAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EWallet.DataAcess.Repositories
{
    public class OtpRepository : IOtpRepository
    {
        private readonly EWalletContext _context;
        public OtpRepository(EWalletContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
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

        public bool UpdateOtp(object otp, int id)
        {

            try
            {
                OtpEntity entity = _context.Otp.AsTracking().FirstOrDefault(x => x.Id == id);

                _context.Entry(entity).CurrentValues.SetValues(otp);
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
