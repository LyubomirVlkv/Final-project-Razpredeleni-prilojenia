using FrontEnd2.ServiceReference1;
using FrontEnd2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd2.Controllers
{
    public class ThreadController : Controller
    {
        // GET: Thread
        public ActionResult Index(string Title)
        {
            List<ThreadVM> threadVMs = new List<ThreadVM>();

            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                foreach(var item in service.GetThread())
                {
                    threadVMs.Add(new ThreadVM(item));
                }
            }

            if (Title != null)
            {
                Object pstnm = threadVMs.Where(x => x.threadName == Title);
                return View(pstnm);
            }

            
            return View(threadVMs);
        }

        public ActionResult Details(int id)
        {
            ThreadVM threadVM = new ThreadVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var threadDTO = service.getThreadById(id);
                threadVM = new ThreadVM(threadDTO);
            }
            return View(threadVM);
        }

        public ActionResult Edit(int id)
        {
            ThreadVM threadVM = new ThreadVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var threadDto = service.getThreadById(id);
                threadVM = new ThreadVM(threadDto);
               
            }
            ViewBag.Users = Helpers.LoadDataUtilities.LoadUserData();
            ViewBag.Posts = Helpers.LoadDataUtilities.LoadPostData();

            //Viewbag-s не работи :(.

            return View(threadVM);
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(ThreadVM threadVM)
        {
            var ran = new Random();
            try
            {
                if (ModelState.IsValid)
                {
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        ServiceReference1.ThreadDTO threadDto = new ServiceReference1.ThreadDTO
                        {
                            
                             Id =threadVM.Id,
                            threadName = threadVM.threadName,
                            threadDiscription = threadVM.threadDiscription,
                            threadKeyTerms = threadVM.threadKeyTerms,
                            threadCreationDate = DateTime.Now,
                            threadNumber = ran.Next(1, 999999),
                            PostId = threadVM.PostId,
                            post = new PostDTO
                            {
                                Id = threadVM.PostId
                            },
                            UserId = threadVM.UserId,
                            user = new UserDTO
                            {
                                Id = threadVM.UserId
                            }

                        };
                        service.AddThread(threadDto);
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }

            catch
            {
                ViewBag.Users = Helpers.LoadDataUtilities.LoadUserData();
                ViewBag.Posts = Helpers.LoadDataUtilities.LoadPostData();
                return View();

            }
        }


        public ActionResult Create()
        {
            ViewBag.Users = Helpers.LoadDataUtilities.LoadUserData();
            ViewBag.Posts = Helpers.LoadDataUtilities.LoadPostData();

            return View();
        }

        [HttpPost]
        public ActionResult Create(ThreadVM threadVM)
        {
            var ran = new Random();
            try
            {
                using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                {
                    ThreadDTO threadDTO = new ThreadDTO
                    {                
                        threadName = threadVM.threadName,
                        threadDiscription = threadVM.threadDiscription,
                        threadKeyTerms = threadVM.threadKeyTerms,
                        threadCreationDate = DateTime.Now,
                        threadNumber = ran.Next(1,999999),
                        PostId = threadVM.PostId,
                        post = new PostDTO
                        {
                            Id = threadVM.PostId
                        },
                        UserId = threadVM.UserId,
                        user = new UserDTO
                        {
                            Id = threadVM.UserId
                        }
                    };
                    service.AddThread(threadDTO);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Users = Helpers.LoadDataUtilities.LoadUserData();
                ViewBag.Posts = Helpers.LoadDataUtilities.LoadPostData();
                return View();

            }
        }

        public ActionResult Delete(int id)
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                service.DeleteThread(id);
            }
            return RedirectToAction("Index");
        }
    }
}