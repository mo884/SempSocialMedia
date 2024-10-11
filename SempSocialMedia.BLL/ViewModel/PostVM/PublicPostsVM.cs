using SempSocialMedia.BLL.ViewModel.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempSocialMedia.BLL.ViewModel.PostVM
{
    public class PublicPostsVM
    {
        public List<GetAllPostsVM>? postsVMs { get; set; }
        public UserVMByUserName? User { get; set; }

    }
}
