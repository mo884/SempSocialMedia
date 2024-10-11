﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempSocialMedia.BLL.ViewModel.AccountVM
{
    public class SignUPVM
    {
        public string Email { get; set; }
        public string Password { get;set; }
        public string Username { get;set; }
        public IFormFile ?File { get; set; }
        public string? Image { get; set; }


    }
}
