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

        public DuckManager(Ducks.Data.Context.DuckContext db)
        {
            _db = db;
        }

        public Models.ViewModels.FeedingVM FeedLogEntry()
        {
            var toReturn = new Models.ViewModels.FeedingVM();
            toReturn.Locations = _db.Locations.Include("City").ToDictionary(x => x.Id, x => $"{x.Address}, {x.City.Name}");
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
            return new FoodVM() { Name = Food.Name, Id = Food.id }; //TODO: Display Method
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
            return new LocationVM() { Address = location.Address, Id = location.Id };
        }

        public Task<List<Ducks.Data.Country>> Countries()
        {
            return _db.Countries.ToListAsync();
        }

        public Task<List<Ducks.Data.State>> States(Guid Country)
        {
            return _db.State.Where(x => x.Country.Id == Country).ToListAsync();
        }

        public Task<List<Ducks.Data.City>> Cities(Guid State)
        {
            return _db.Cities.Where(x => x.State.Id == State).ToListAsync();
        }
        public Task<List<Data.Unit>> UnitsOfMeasure()
        {
            return _db.Unit.ToListAsync();
        }
        public Task<List<Data.FeedLog>> GetAll()
        {
            return _db.FeedLog.ToListAsync();
        }

        public async Task<Data.FeedLog> InsertFeedingRecord(FeedingVM feedingVm, string User)
        {
            var Feed = new Data.FeedLog();
            Feed.DateFed = feedingVm.DateFed;
            Feed.DucksFed = feedingVm.Quantity;
            Feed.Food = _db.Food.Find(feedingVm.FoodId);
            Feed.FoodAmount = feedingVm.FoodAmount;
            Feed.Id = Guid.NewGuid();
            Feed.Location = _db.Locations.Find(feedingVm.LocationId);
            Feed.User = await _db.Users.FirstAsync(u => u.Email == User);
            _db.FeedLog.Add(Feed);


            if (feedingVm.Schedule)
            {
                _db.Schedules.Add(new Data.Schedule() { Id = Guid.NewGuid(), FeedLog = Feed, User = Feed.User, TimeOfDay = TimeSpan.Parse(feedingVm.Time) });
            }
            await _db.SaveChangesAsync();
            return Feed;
        }

        public void AddDuckFeeder(Guid Id, String Email, String FirstName = "", String LastName = "")
        {
            if (!_db.Users.Any(x => x.Email == Email))
            {
                _db.Users.Add(new Data.User() { Id = Id, Email = Email, FirstName = FirstName, LastName = LastName });
                _db.SaveChanges();
            }
        }

        public void RunScheduleFeed()
        {
            var time = DateTime.Now.TimeOfDay;
            // If the first job runs at 12:01 AM, this would grab all jobs at 12:00.
            var tasks = _db.Schedules.Where(x => x.TimeOfDay < time).ToList();

            // If the time is 1:00 AM, we will have grabbed all jobs including ones that have already been run between
            // midnight and now. Only run either new jobs (lastrun is null) or jobs that are before right now,
            // and have not been run yet today 

            tasks = tasks.Where(x => !x.LastRun.HasValue || x.LastRun.Value.Date < DateTime.Today.Date).ToList();

            foreach (var feeding in tasks)
            {
                var feedLog = feeding.FeedLog;
                _db.FeedLog.Add(new Data.FeedLog()
                {
                    DateFed = DateTime.Now,
                    DucksFed = feedLog.DucksFed,
                    Food = feedLog.Food,
                    FoodAmount = feedLog.FoodAmount,
                    Id = Guid.NewGuid(),
                    Location = feedLog.Location,
                    User = feedLog.User
                });
                _db.Schedules.Find(feeding.Id).LastRun = DateTime.Now;
                _db.SaveChanges();

            }
        }
    }
}