using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI2.Controllers
{
    public class BaseController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Version()
        {
            return Json("Our first REST API - Version 0.0.1");
        }
    }
}
