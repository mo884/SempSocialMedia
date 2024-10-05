using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempSocialMedia.DAL.Entities
{
    public class User:IdentityUser
    {
        
       
        public string? FullName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }=DateTime.Now;
        public string? Image { get; set; }
        public List<Post>? Posts { get; set; }
        public List<Comment>? Comments { get; set; }

    }
}
