using SempSocialMedia.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempSocialMedia.DAL.Repo.Abstraction
{
    public interface IUserRepo
    {
        Task<User> GetUserByUserName(string UserName);
    }
}
