using Microsoft.EntityFrameworkCore;
using SempSocialMedia.DAL.DataBase;
using SempSocialMedia.DAL.Entities;
using SempSocialMedia.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SempSocialMedia.DAL.Repo.Impelementation
{
    public class PostRepo:IPostRepo
    {
        private readonly SempSocialMediaDbContext db;

        public PostRepo(SempSocialMediaDbContext db)
        {
            this.db=db;
        }

        public bool Create(Post post)
        {
            try
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

               return false;
            }
           
        }

        public List<Post> GetAll(Expression<Func<Post, bool>>? Filter) //2
        {
            var Result = db.Posts.Where(Filter).Include(a=>a.User).ToList();
            return Result;
        }
      
    }
}
