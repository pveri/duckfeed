using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ducks.Application.Models.ViewModels;
]

namespace Ducks.Application.Models
{
    public class DuckManager
    {
        private Ducks.Data.Context.DuckContext _db;

        public DuckManager()
        {
            _db = new Data.Context.DuckContext();
        }

        public Models.ViewModels.FeedingVM FeedLogEntry()
        {
            var toReturn = new Models.ViewModels.FeedingVM();
            toReturn.Locations = _db.Locations.Include("City").ToDictionary(x => x.Id, x => $"{x.Address}, {x.City.Name}" );
            toReturn.Food = _db.Food.ToList();
            return toReturn;
        }

        public Models.ViewModels.LocationVM AddLocation(LocationVM locationVM)
        {
            var location = new Ducks.Data.Location();
            location.Address = locationVM.Address;
            
            return null;
        }
    }
}