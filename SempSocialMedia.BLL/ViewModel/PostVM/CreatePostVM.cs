using Microsoft.AspNetCore.Http;
using SempSocialMedia.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempSocialMedia.BLL.ViewModel.PostVM
{
    public class CreatePostVM
    {
        public IFormFile? Photo { get; set; }

        public string? Image { get; set; }
        [Required]
        public string Body { get; set; }
        public string? UserId { get; set; }
    }
}
