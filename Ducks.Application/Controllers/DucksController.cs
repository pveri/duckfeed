﻿using System;
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
    /// <summary>
    /// 
    /// </summary>
    public class DucksController : ApiController
    {
        private Models.DuckManager _manager;

        public DucksController()
        {
            _manager = new Models.DuckManager();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewLocation"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("api/Ducks/Location/Add")]
        public async Task<JsonResult<LocationVM>> AddLocation([FromBody]LocationVM NewLocation)
        {
            return Json(await _manager.AddLocation(NewLocation, User.Identity.Name));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("api/Ducks/Location/Countries")]
        public async Task<object> ListCountries()
        {
            var result = await _manager.Countries();
            return Json(result.Select(x => new { Id=x.Id, Name = x.Name }));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Country"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("api/Ducks/Location/States")]
        public async Task<object> ListStates([FromBody]Guid Country)
        {
            var result = await _manager.States(Country);
            return Json(result.Select(x => new { Id = x.Id, Name = x.Name }));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="State"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("api/Ducks/Location/Cities")]
        public async Task<object> ListCities([FromBody]Guid State)
        {
            var result = await _manager.Cities(State);
            return Json(result.Select(x => new { Id = x.Id, Name = x.Name }));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("api/Ducks/Food/Units")]
        public async Task<object> ListUnitsOfMeasure()
        {
            var result = await _manager.UnitsOfMeasure();
            return Json(result.Select(x => new { Id = x.Id, Name = x.Measurement }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewFood"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("api/Ducks/Food/Add")]
        public async Task<JsonResult<FoodVM>> AddFood([FromBody]FoodVM NewFood)
        {
            return Json(await _manager.AddFood(NewFood, User.Identity.Name));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/Schedule/Run")]
        public void RunDucks()
        {
           _manager.RunScheduleFeed();
        }
    }
}
