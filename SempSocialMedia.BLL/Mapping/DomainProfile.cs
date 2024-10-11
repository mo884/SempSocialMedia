using AutoMapper;
using SempSocialMedia.BLL.ViewModel.PostVM;
using SempSocialMedia.BLL.ViewModel.UserVM;
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
         opt.MapFrom(src => src.User.FullName))
           .ForMember(dest => dest.ImageUser, opt =>
         opt.MapFrom(src => src.User.Image))

          ;

            CreateMap<Post, CreatePostVM>().ReverseMap();

                 CreateMap<User, UserVMByUserName>()
          .ForMember(dest => dest.Name, opt =>
         opt.MapFrom(src => src.FullName));

        }
    }
}
