using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.DataAcess.Entities
{
    public class OtpEntity : BaseEntity
    {
        public string Email { get; set; }
        public string Otp { get; set; }
        public string Reference { get; set; }
    }
}
