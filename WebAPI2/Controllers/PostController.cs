using ApplicationService1.DTOs;
using ApplicationService1.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI2.Messages;

namespace WebAPI2.Controllers
{
    public class PostController : ApiController
    {
        private readonly PostManagementService _service = null;


        public PostController()
        {
            _service = new PostManagementService();
        }

        [HttpGet]
            public IHttpActionResult Get()
        {
            return Json(_service.Get());
        }
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            return Json(_service.GetById(id));
        }

        public IHttpActionResult Save(PostDTO postDTO)
        {
            ResponseMessage response = new ResponseMessage();

            if (_service.Save(postDTO))
            {
                response.Code = 201;
                response.Body = "Post has been saved";
            }
            else
            {
                response.Code = 200;
                response.Body = "Post cannot be saved";
            }
            return Json(response);
        }

        public IHttpActionResult Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (_service.Delete(id))
            {
                response.Code = 201;
                response.Body = "Post has been deleted";
            }
            else
            {
                response.Code = 200;
                response.Body = "Post cannot be deleted";
            }
            return Json(response);
        }
    }
}
