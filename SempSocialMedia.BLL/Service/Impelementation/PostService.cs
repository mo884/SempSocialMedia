using AutoMapper;
using SempSocialMedia.BLL.Helper;
using SempSocialMedia.BLL.Service.Abstraction;
using SempSocialMedia.BLL.ViewModel.PostVM;
using SempSocialMedia.DAL.Entities;
using SempSocialMedia.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempSocialMedia.BLL.Service.Impelementation
{
    public class PostService : IPostService
    {
        private readonly IPostRepo postRepo;
        private readonly IMapper mapper;

        public PostService(IPostRepo postRepo,IMapper mapper)
        {
            this.postRepo=postRepo;
            this.mapper=mapper;
        }

        public bool Create(CreatePostVM createPost)
        {
            try
            {
                var Result = mapper.Map<Post>(createPost);
                if (createPost.Photo !=null)
                {
                    Result.Image = Upload.UploadFile("Post", createPost.Photo);

                }
                postRepo.Create(Result);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
          
        }

        public List<GetAllPostsVM> GetAll()
        {
            try
            {
                var Posts = postRepo.GetAll(a => a.IsDeleted != true);
                var Result = mapper.Map<List<GetAllPostsVM>>(Posts);
                return Result;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
