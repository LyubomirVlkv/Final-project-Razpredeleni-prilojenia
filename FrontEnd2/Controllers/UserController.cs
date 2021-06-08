using FrontEnd2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index(string username)
        {
            List<UserVM> userVM = new List<UserVM>();

            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                foreach(var item in service.GetUser())
                {
                    userVM.Add(new UserVM(item));
                }
            }
            if (username != null)
            {
                Object usrnm = userVM.Where(x => x.Username == username);
                return View(usrnm);
            }
            return View(userVM);
        }

        public ActionResult Edit(int id)
        {
            UserVM userVM = new UserVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var userDto = service.GetUserById(id);
                userVM = new UserVM(userDto);
            }

            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit (UserVM userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        ServiceReference1.UserDTO userDto = new ServiceReference1.UserDTO
                        {
                            Id = userVM.Id,
                            Username = userVM.Username,
                            Password = userVM.Password,
                            Description = userVM.Description,
                            Email = userVM.Email,
                            userAge = userVM.userAge,
                            userCreated = DateTime.Now
                            
                        };
                        service.PostUser(userDto);
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }

            catch
            {
                return View();

            }
        }




        public ActionResult Details(int id)
        {
            UserVM userVM = new UserVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var userDto = service.GetUserById(id);
                userVM = new UserVM(userDto);
            }
            return View(userVM);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(UserVM userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        ServiceReference1.UserDTO userDTO = new ServiceReference1.UserDTO
                        {
                            Username = userVM.Username,
                            Password = userVM.Password,
                            Description = userVM.Description,
                            Email = userVM.Email,
                            userAge = userVM.userAge,
                            userCreated = DateTime.Now                  
                        };
                        service.PostUser(userDTO);
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        
        }

        public ActionResult Delete(int id)
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                service.DeleteUser(id);
            }
            return RedirectToAction("Index");
        }

    }
}