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
    public class ThreadController : ApiController
    {
        private readonly ThreadServiceManagement _service = null;

        public ThreadController()
        {
            _service = new ThreadServiceManagement();
        }

        public IHttpActionResult Get()
        {
            return Json(_service.Get());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(_service.GetByID(id));
        }

        [HttpPost]


        public IHttpActionResult Save(ThreadDTO threadDTO)
        {
            ResponseMessage response = new ResponseMessage();

            if(_service.Save(threadDTO))
            {
                response.Code = 201;
                response.Body = "Thread has  been saved";
            }
            else
            {
                response.Code = 200;
                response.Body = "Thread has not been saved";
            }
            return Json(response);
        }

        public IHttpActionResult Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (_service.Delete(id))
            {
                response.Code = 201;
                response.Body = "Thread has been deleted";
            }
            else
            {
                response.Code = 200;
                response.Body = "Thread has not been deleted";
            }
            return Json(response);
        }


    }
}
