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
            return Json(_manager.AddLocation(NewLocation, User.Identity.Name));
        }

        [HttpPost]
        [Authorize]
        [Route("api/Ducks/Location/Countries")]
        public async Task<object> ListCountries()
        {
            return Json(_manager.Countries().Select(x => new { Id=x.Id, Name = x.Name }));
        }

        [HttpPost]
        [Authorize]
        [Route("api/Ducks/Location/States")]
        public async Task<object> ListStates([FromBody]Guid Country)
        {
            return Json(_manager.States(Country).Select(x => new { Id = x.Id, Name = x.Name }));
        }

        [HttpPost]
        [Authorize]
        [Route("api/Ducks/Location/Cities")]
        public async Task<object> ListCities([FromBody]Guid State)
        {
            return Json(_manager.Cities(State).Select(x => new { Id = x.Id, Name = x.Name }));
        }
        [HttpPost]
        [Authorize]
        [Route("api/Ducks/Food/Units")]
        public async Task<object> ListUnitsOfMeasure()
        {
            return Json(_manager.UnitsOfMeasure().Select(x => new { Id = x.Id, Name = x.Measurement }));
        }

        [HttpPost]
        [Authorize]
        [Route("api/Ducks/Food/Add")]
        public async Task<JsonResult<FoodVM>> AddFood([FromBody]FoodVM NewFood)
        {
            return Json(_manager.AddFood(NewFood, User.Identity.Name));
        }
    }
}
