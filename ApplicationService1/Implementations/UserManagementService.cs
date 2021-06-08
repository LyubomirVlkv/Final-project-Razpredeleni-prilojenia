using ApplicationService1.DTOs;
using ClassContext.Entities;
using ClassContextt2.Context;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService1.Implementations
{
    public class UserManagementService
    {
        private ForumDBContextt2 ctx = new ForumDBContextt2();

        public List<UserDTO> Get()
        {
            List<UserDTO> userDto = new List<UserDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.UserRepository.Get()) 
                            userDto.Add(new UserDTO
                {

                    Id = item.Id,
                    Username = item.Username,                
                    Description = item.Description,              
                    userCreated = item.userCreated,
                    userAge = item.userAge
                });

            }
            return userDto;

        }

        public UserDTO GetById(int id)
        {
            UserDTO userDTO = new UserDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                User user = unitOfWork.UserRepository.GetByID(id);
                if (user != null)
                {                 
                    userDTO.Id = user.Id;
                    userDTO.Username = user.Username;
                    
                    userDTO.userCreated = user.userCreated;
                    userDTO.userAge = user.userAge;
                    
                    userDTO.Description = user.Description;
                
                }
            }
            return userDTO;
        }

        public bool Save(UserDTO userDto)
        {
            User user = new User
            {
                Id = userDto.Id,
                Username = userDto.Username,
                Password = userDto.Password,
                Description = userDto.Description,
                Email = userDto.Email,
                userCreated = userDto.userCreated,
                userAge = userDto.userAge
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (userDto.Id == 0)
                    {
                        unitOfWork.UserRepository.Insert(user);
                    }
                    else
                        unitOfWork.UserRepository.Update(user);

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
                using (UnitOfWork unitOfWork = new UnitOfWork()) {

                    User user = unitOfWork.UserRepository.GetByID(id);
                    unitOfWork.UserRepository.Delete(user);
                    unitOfWork.Save();
                }
                return true;
            }catch { return false; }

        }
    }
}
