using ApplicationService1.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ApplicationService1.Implementations;

namespace Final_project_Razpredeleni_prilojenia
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
       

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        private UserManagementService userService = new UserManagementService();
        private PostManagementService postService = new PostManagementService();
        private ThreadServiceManagement threadService = new ThreadServiceManagement();
        public List<UserDTO> GetUser()
        {
            return userService.Get();
        }

        public string PostUser(UserDTO userDto)
        {
            if (!userService.Save(userDto))
            {
                return "User is not saved!";
            }
            else
            {
                return "User saved!";
            }
        }

        public string DeleteUser(int id)
        {
            if (!userService.Delete(id))
            {
                return "User not deleted!";
            }
            else
            {
                return "User deleted!";
            }
        }

        public List<PostDTO> GetPost()
        {
            return postService.Get();
        }

        public string AddPost(PostDTO postDto)
        {
            if (!postService.Save(postDto))
            {
                return "Post cannot be saved!";
            }
            else
            {
                return "Post saved!";
            }
        }

        public string DeletePost(int id)
        {
            if (!postService.Delete(id))
            {
                return "Post cannot be deleted!";
            }
            else return "Post deleted!";
        }

        public UserDTO GetUserById(int id)
        {
            return userService.GetById(id);
        }

        public PostDTO getPostById(int id)
        {
            return postService.GetById(id);
        }

        public List<ThreadDTO> GetThread()
        {
            return threadService.Get();
        }

        public ThreadDTO getThreadById(int id)
        {
            return threadService.GetByID(id);
        }

        public string AddThread(ThreadDTO postDto)
        {
            if (!threadService.Save(postDto))
            {
                return "Thread not saved!";
            }
            else
            {
                return "Thread saved!";
            }
        }

        public string DeleteThread(int id)
        {
            if (!threadService.Delete(id))
            {
                return "Thread cannot be deleted!";
            }
            else
            {
                return "Thread deleted!";
            }
        }
    }
}
