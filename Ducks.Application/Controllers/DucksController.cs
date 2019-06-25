using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Ducks.Application.Models.ViewModels;
namespace Ducks.Application.Controllers
{
    public class DucksController : ApiController
    {
        private Models.DuckManager _manager;

        public DucksController()
        {
            _manager = new Models.DuckManager();
        }

        [HttpPost]
        [Authorize]
        [Route("api/Ducks/Location/Add")]
        public async Task<JsonResult<LocationVM>> AddLocation([FromBody]LocationVM NewLocation)
        {
            return Json(_manager.AddLocation(NewLocation));
        }


    }
}
