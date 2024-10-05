using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempSocialMedia.DAL.Entities
{
    public class Post
    {
        public long Id { get; set; }
        public string? Body { get; set; }
        public string? Image { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public List<Comment>?Comments { get; set; }
        [ForeignKey("User")]
        public string? UserId {  get; set; }
        
        public User? User { get; set; }
    }
}
