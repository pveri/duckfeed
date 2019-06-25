using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ducks.Application.Models.ViewModels
{
    public class FeedingVM
    {
       public Dictionary<Guid, String> Locations { get; set; }
        public Dictionary<Guid, String> Food { get; set; }
       public int Quantity { get; set; }
        public int FoodAmount { get; set; }
       public DateTime DateFed { get; set; }
    }

    public class LocationVM
    {
        public String CityId { get; set; }
        public String Country { get; set; }
        public String State { get; set; }
        public String Address { get; set; }

    }

    public class FoodVM
    {
        public String Name { get; set; }
        public Dictionary<Guid, String> UnitStored { get; set; }

    }
}