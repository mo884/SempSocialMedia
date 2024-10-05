using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempSocialMedia.DAL.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        public string? Body { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? Image { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }
        [ForeignKey("Post")]
        public long? PostId { get; set; }
        public Post? Post { get; set; }
    }
}
