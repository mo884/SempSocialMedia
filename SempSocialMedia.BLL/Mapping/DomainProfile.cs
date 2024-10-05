using AutoMapper;
using SempSocialMedia.BLL.ViewModel.PostVM;
using SempSocialMedia.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempSocialMedia.BLL.Mapping
{
    public class DomainProfile: Profile
    {
        public DomainProfile()
        {
           CreateMap<Post, GetAllPostsVM>()
          .ForMember(dest => dest.UserName, opt =>
         opt.MapFrom(src => src.User.FullName));

            CreateMap<Post, CreatePostVM>().ReverseMap();
        }
    }
}
