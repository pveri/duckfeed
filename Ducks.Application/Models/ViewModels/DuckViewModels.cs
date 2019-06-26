using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ducks.Application.Models.ViewModels
{
    //TODO: Validation
    public class FeedingVM
    {
        public Guid FoodId { get; set; }
        public Guid LocationId { get; set; }
        public Dictionary<Guid, String> Locations { get; set; }
        public Dictionary<Guid, String> Food { get; set; }
        public int Quantity { get; set; }
        public int FoodAmount { get; set; }
        public DateTime DateFed { get; set; }
        public String Time { get; set; }
        public bool Schedule { get; set; }
    }

    public class LocationVM
    {
        public Guid Id { get; set; }
        public String CityId { get; set; }
        public String Country { get; set; }
        public String State { get; set; }
        public String Address { get; set; }
    }

    public class FoodVM
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Dictionary<Guid, String> UnitStored { get; set; }
        public Guid UnitId { get; set; }
    }

    public class FeedingDetailsVM
    {
        public FeedingDetailsVM(Data.FeedLog record)
        {
            this.Food = record?.Food?.Name;
            this.FoodAmount = record.FoodAmount;
            this.Quantity = record.DucksFed;
            this.State = record?.Location?.City?.State.Name;
            this.Time = record.DateFed.Value.ToString("yyyy MM dd");
            this.Units = record?.Food?.Unit.Measurement;
            this.Country = record?.Location?.City?.Country.Name;
            this.Address = record?.Location?.Address;
            this.City = record?.Location?.City.Name;
        }
        public String Food { get; set; }
        public int Quantity { get; set; }
        public String Time { get; set; }
        public int FoodAmount { get; set; }
        public String Units { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public String State { get; set; }
        public String Address { get; set; }
    }

}