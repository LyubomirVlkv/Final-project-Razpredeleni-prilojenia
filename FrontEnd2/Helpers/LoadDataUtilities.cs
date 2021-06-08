using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd2.Helpers
{
    public class LoadDataUtilities
    {
        public static SelectList LoadUserData()
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                return new SelectList(service.GetUser(), "Id", "Username");
            }

        }

        public static SelectList LoadPostData()
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                return new SelectList(service.GetPost(), "Id", "title");
            }
        }
    }
}