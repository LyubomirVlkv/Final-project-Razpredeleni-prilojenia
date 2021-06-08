using ApplicationService1.DTOs;
using ClassContext.Entities;
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
    public class ThreadServiceManagement
    {
        private ForumDBContextt2 ctx = new ForumDBContextt2();

        public List<ThreadDTO> Get()
        {
            List<ThreadDTO> threadDTOs = new List<ThreadDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in ctx.Threads.ToList())
                {
                    threadDTOs.Add(new ThreadDTO
                    {
                        Id = item.Id,
                        threadName = item.threadName,
                        threadDiscription = item.threadDiscription,
                        threadKeyTerms = item.threadKeyTerms,
                        threadCreationDate = item.threadCreationDate,
                        threadNumber = item.threadNumber,
                        PostId = item.PostId,
                        UserId = item.UserId,
                        post = new PostDTO
                        {
                            Id = item.PostId,
                            title = item.post.title,
                            smallerdescription = item.post.smallerdescription,
                            description = item.post.description,
                            keyterms = item.post.keyterms,
                            postcreated = item.post.postcreated,
                            postNumber = item.post.postNumber
                        },

                        user = new UserDTO
                        {
                            Id = item.UserId,
                            Username = item.user.Username,                     
                            Description = item.user.Description,
                            userCreated = item.user.userCreated,
                            userAge = item.user.userAge
                        }
                    });

                }
            }
            return threadDTOs;
        }

        public ThreadDTO GetByID(int id)
        {
            ThreadDTO threadDTO = new ThreadDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Thread item = unitOfWork.ThreadRepository.GetByID(id);

                 threadDTO = new ThreadDTO
                {
                    Id = item.Id,
                    threadName = item.threadName,
                    threadDiscription = item.threadDiscription,
                    threadKeyTerms = item.threadKeyTerms,
                    threadCreationDate = item.threadCreationDate,
                    threadNumber = item.threadNumber,
                    PostId = item.PostId,
                    UserId = item.UserId,
                    post = new PostDTO
                    {
                        Id = item.PostId,
                        title = item.post.title,
                        smallerdescription = item.post.smallerdescription,
                        description = item.post.description,
                        keyterms = item.post.keyterms,
                        postcreated = item.post.postcreated,
                        postNumber = item.post.postNumber
                    },

                    user = new UserDTO
                    {
                        Id = item.UserId,
                        Username = item.user.Username,
                        Description = item.user.Description,
                        userCreated = item.user.userCreated,
                        userAge = item.user.userAge
                    }

                };
            }
            return threadDTO;
            
        }


        public bool Save(ThreadDTO threadDTO)
        {
            if (threadDTO.post == null || threadDTO.PostId == 0)
                return false;
            if (threadDTO.user == null || threadDTO.UserId == 0)
                return false;

            
            Thread thread = new Thread
            {
                Id = threadDTO.Id,
                threadName = threadDTO.threadName,
                threadDiscription = threadDTO.threadDiscription,
                threadKeyTerms = threadDTO.threadKeyTerms,
                threadCreationDate = threadDTO.threadCreationDate,
                threadNumber = threadDTO.threadNumber,
                PostId = threadDTO.PostId,      
                UserId = threadDTO.UserId,

                
            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (threadDTO.Id == 0)
                        unitOfWork.ThreadRepository.Insert(thread);
                    else
                        unitOfWork.ThreadRepository.Update(thread);

                    unitOfWork.Save();
                }
                    
                return true;
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
                //Thread thread = ctx.Threads.Find(id);
                // ctx.Threads.Remove(thread);
                //ctx.SaveChanges();

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Thread thread = unitOfWork.ThreadRepository.GetByID(id);
                    unitOfWork.ThreadRepository.Delete(thread);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
