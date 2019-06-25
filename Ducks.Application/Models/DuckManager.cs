using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Ducks.Application.Models.ViewModels;


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
            toReturn.Food = _db.Food.ToDictionary(x => x.id, x => x.Name);
            return toReturn;
        }

        public Models.ViewModels.FoodVM AddFood(FoodVM FoodVM, String User)
        {
            var Food = new Ducks.Data.Food();
            Food.Unit = _db.Unit.Find(FoodVM.UnitId);
            Food.AddedBy = User;
            _db.Food.Add(Food);
            _db.SaveChangesAsync();
            return new FoodVM () { Name = Food.Name }; //TODO: Display Method
        }

        public Models.ViewModels.LocationVM AddLocation(LocationVM locationVM, String User)
        {
            var location = new Ducks.Data.Location();
            location.Address = locationVM.Address;
            location.AddedBy = User;
            _db.Locations.Add(location);
            _db.SaveChangesAsync();
            return locationVM;
        }

        public List<Ducks.Data.Country> Countries()
        {
            return _db.Countries.ToList();
        }

        public List<Ducks.Data.State> States(Guid Country)
        {
            return _db.State.Where(x=>x.Country.Id==Country).ToList();
        }

        public List<Ducks.Data.City> Cities(Guid State)
        {
            return _db.Cities.Where(x => x.State.Id== State).ToList();
        }
        public List<Data.Unit> UnitsOfMeasure()
        {
            return _db.Unit.ToList();
        }
    }
}