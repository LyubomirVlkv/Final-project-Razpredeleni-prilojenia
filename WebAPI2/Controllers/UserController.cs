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
    //[RoutePrefix("api/usr")]
    public class UserController : ApiController
    {
        private readonly UserManagementService _service = null;


        public UserController()
        {
            _service = new UserManagementService();
        }
        [HttpGet]
        //[Route("")]
        public IHttpActionResult Get()
        {
            return Json(_service.Get());
        }
        [HttpGet]
         //[Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Json(_service.GetById(id));
        }
        [HttpPost]
        //[Route("")]
        public IHttpActionResult Save(UserDTO userDTO)
        {
            ResponseMessage response = new ResponseMessage();

            if (_service.Save(userDTO))
            {
                response.Code = 201;
                response.Body = "User has been saved";

            }
            else
            {
                response.Code = 200;
                response.Body = "User has not been saved";
            }
            return Json(response);
        }

        [HttpDelete]
       //[Route("")]
        public IHttpActionResult Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (_service.Delete(id))
            {
                response.Code = 201;
                response.Body = "User has been deleted";

            }
            else
            {
                response.Code = 200;
                response.Body = "User has not been deleted";
            }
            return Json(response);
        }
    }
}
