using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempSocialMedia.BLL.ViewModel.PostVM
{
    public class GetAllPostsVM
    {
        public string? Body { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedOn { get; set; }

        public string UserName { get; set; }
    }
}
