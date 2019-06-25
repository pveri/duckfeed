using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ducks.Application.Controllers
{
    public class DucksController : ApiController
    {
        private Models.DuckManager _manager;

        public DucksController()
        {
            _manager = new Models.DuckManager();
        }


    }
}
