using SempSocialMedia.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SempSocialMedia.DAL.Repo.Abstraction
{
    public interface IPostRepo
    {
        List<Post> GetAll(Expression<Func<Post, bool>>? Filter); //a=>a.Name="Mohamed"   a=>a.UserId =3 //Enhance EF
    
        bool Create(Post post);
    
    }
}
