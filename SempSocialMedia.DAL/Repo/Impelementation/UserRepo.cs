using Microsoft.EntityFrameworkCore;
using SempSocialMedia.DAL.DataBase;
using SempSocialMedia.DAL.Entities;
using SempSocialMedia.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempSocialMedia.DAL.Repo.Impelementation
{
    public class UserRepo : IUserRepo
    {
        private readonly SempSocialMediaDbContext db;

        public UserRepo(SempSocialMediaDbContext db)
        {
            this.db=db;
        }
        public async Task<User> GetUserByUserName(string UserName)=> await db.Users.Where(user=>user.UserName == UserName).FirstOrDefaultAsync();
        
    }
}
