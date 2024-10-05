using SempSocialMedia.BLL.ViewModel.PostVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempSocialMedia.BLL.Service.Abstraction
{
    public interface IPostService
    {
        List<GetAllPostsVM> GetAll();
        bool Create(CreatePostVM createPost);
    }
}
