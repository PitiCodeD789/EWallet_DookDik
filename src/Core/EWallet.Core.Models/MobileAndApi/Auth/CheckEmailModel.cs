using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EWallet.Core.Models.MobileAndApi.Auth
{
    public class CheckEmailModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
