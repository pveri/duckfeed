using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<Models.ViewModels.FoodVM> AddFood(FoodVM FoodVM, String User)
        {
            var Food = new Ducks.Data.Food();
            Food.Unit = _db.Unit.Find(FoodVM.UnitId);
            Food.AddedBy = User;
            Food.Name = FoodVM.Name;
            Food.id = Guid.NewGuid();
            _db.Food.Add(Food);
            await _db.SaveChangesAsync();
            return new FoodVM () { Name = Food.Name , Id=Food.id}; //TODO: Display Method
        }

        public async Task<Models.ViewModels.LocationVM> AddLocation(LocationVM locationVM, String User)
        {
            var location = new Ducks.Data.Location();
            location.Address = locationVM.Address;
            location.AddedBy = User;
            location.City = _db.Cities.Find(Guid.Parse(locationVM.CityId));
            location.Id = Guid.NewGuid();
            _db.Locations.Add(location);
            await _db.SaveChangesAsync();
            return locationVM;
        }

        public Task<List<Ducks.Data.Country>> Countries()
        {
            return _db.Countries.ToListAsync();
        }

        public Task<List<Ducks.Data.State>> States(Guid Country)
        {
            return _db.State.Where(x=>x.Country.Id==Country).ToListAsync();
        }

        public Task<List<Ducks.Data.City>> Cities(Guid State)
        {
            return _db.Cities.Where(x => x.State.Id== State).ToListAsync();
        }
        public Task<List<Data.Unit>> UnitsOfMeasure()
        {
            return _db.Unit.ToListAsync();
        }
    }
}