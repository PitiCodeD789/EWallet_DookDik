﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Mobile.Services.Models
{
    public class ResultServiceModel<T> where T : class
    {
        public bool IsError { get; set; } = true;
        public T Model { get; set; }
    }
}
