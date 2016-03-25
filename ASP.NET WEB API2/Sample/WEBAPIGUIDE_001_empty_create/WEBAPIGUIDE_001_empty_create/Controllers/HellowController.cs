using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEBAPIGUIDE_001_empty_create.Controllers
{
    public class HellowController : ApiController
    {
        public string Get()
        {
            return "Hellow ASP.NET WEB API2!";
        }
    }
}
