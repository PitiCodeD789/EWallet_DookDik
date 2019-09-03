using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.DataAcess.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
