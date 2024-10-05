using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SempSocialMedia.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempSocialMedia.DAL.DataBase
{
    public class SempSocialMediaDbContext :IdentityDbContext
    {
        public SempSocialMediaDbContext(DbContextOptions<SempSocialMediaDbContext> opt):base(opt)
        {
            
        }

        public DbSet<User>Users { get; set; }
        public DbSet<Post>Posts { get; set; }
        public DbSet<Comment>Comments { get; set; }
        //
    }
}
