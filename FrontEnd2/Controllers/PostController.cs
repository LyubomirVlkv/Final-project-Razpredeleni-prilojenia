using FrontEnd2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd2.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index(string Title)
        {
            List<PostVM> postVMs = new List<PostVM>();

            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                foreach(var item in service.GetPost())
                {
                    postVMs.Add(new PostVM(item));
                }
            }

            if (Title != null)
            {
                Object pstnm = postVMs.Where(x => x.title == Title);
                return View(pstnm);
            }
            return View(postVMs);
        }
       
        public ActionResult Details(int id)
        {
            PostVM postVM = new PostVM();

            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var postDTO = service.getPostById(id);
                postVM = new PostVM(postDTO);
            }
            return View(postVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(PostVM postVM)
        {

            //VURPOS ZA RANDOM NA CREATE/EDIT
            var rn = new Random();
            var rnd = rn.Next(1, 9999999);
            try
            {
                if (ModelState.IsValid)
                {
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        ServiceReference1.PostDTO postDTO = new ServiceReference1.PostDTO
                        {
                            title = postVM.title,
                            smallerdescription = postVM.smallerdescription,
                            description = postVM.description,
                            keyterms = postVM.keyterms,
                            postNumber = rnd,
                            postcreated = DateTime.Now


                        };
                        service.AddPost(postDTO);
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

        public ActionResult Edit(int id)
        {
            PostVM postVM = new PostVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var postDto = service.getPostById(id);
                postVM = new PostVM(postDto);
            }

            return View(postVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(PostVM postVM)
        {
          
            try
            {
                if (ModelState.IsValid)
                {
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        ServiceReference1.PostDTO postDto = new ServiceReference1.PostDTO
                        {
                            Id = postVM.Id,
                            title = postVM.title,
                            smallerdescription = postVM.smallerdescription,
                            description = postVM.description,
                            keyterms = postVM.keyterms,
                          
                        };
                        service.AddPost(postDto);
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
                service.DeletePost(id);
            }
            return RedirectToAction("Index");
        }
    }
}