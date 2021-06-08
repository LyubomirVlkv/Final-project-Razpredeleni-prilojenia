using ApplicationService1.DTOs;
using ClassContextt2.Context;
using DBContext.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService1.Implementations
{
    public class PostManagementService
    {
        private ForumDBContextt2 ctx = new ForumDBContextt2();

     
        public List<PostDTO> Get()
        {
              List<PostDTO> postDto = new List<PostDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach(var item in unitOfWork.PostRepository.Get())
                postDto.Add(new PostDTO
                {
                    Id = item.Id,
                    title = item.title,
                    smallerdescription = item.smallerdescription,
                    description = item.description,
                    keyterms = item.keyterms,
                    postcreated = item.postcreated,
                    postNumber = item.postNumber

                });
            }
            return postDto;

        }

        public PostDTO GetById(int id)
        {
            PostDTO postDTO = new PostDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork()) { 
                Post post = unitOfWork.PostRepository.GetByID(id);

            if(post != null)
            {
                postDTO.Id = post.Id;
                postDTO.title = post.title;
                postDTO.description = post.description;
                postDTO.smallerdescription = post.smallerdescription;
                postDTO.keyterms = post.keyterms;
                postDTO.postcreated = post.postcreated;
                postDTO.postNumber = post.postNumber;
            }
            }
            return postDTO;
        }


        public bool Save(PostDTO postDto)
        {

            Post post = new Post
            {
                Id = postDto.Id,
                title = postDto.title,
                smallerdescription = postDto.smallerdescription,
                description = postDto.description,
                keyterms = postDto.keyterms,
                 postcreated = DateTime.Now,
                postNumber = postDto.postNumber

            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork()) {
                    if (postDto.Id == 0)
                    {
                        unitOfWork.PostRepository.Insert(post);
                    }
                    else    
                        unitOfWork.PostRepository.Update(post);

                    unitOfWork.Save();
                             
                return true;

                }
            }
            catch
            {
                return false;
            }


        }

        public bool Delete(int id)
        {

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Post post = unitOfWork.PostRepository.GetByID(id);
                    unitOfWork.PostRepository.Delete(post);
                    unitOfWork.Save();

                }
                return true;

            }
            catch { return false; }


        }
           
             
 
        

       }


}
    

