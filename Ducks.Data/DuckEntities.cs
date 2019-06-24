using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks.Data
{
    public class Country
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
    }

   public class State
    {
        public Guid Id { get; set; }
        public Country Country { get; set; }
        public String Name { get; set; }
    }

    public class City
    {
        public Guid Id { get; set; }
        public Country Country { get; set; }
        public string Name { get; set; }
    }

    public class Location
    {
        public Guid Id { get; set; }
        public City City { get; set; }
        public String KeyWords { get; set; }
        public String Address { get; set; }
    }


    public class User
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    }

    public class Unit
    {
        public Guid Id { get; set; }
        public String Measurement { get; set; }
    }
    public class Food
    {
        public Guid id { get; set; }
        public String Name { get; set; }
        public Unit Unit { get; set; }

    }

    public class FeedLog
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Location Location { get; set; }
        public Food Food { get; set; }
        public int FoodAmount { get; set; }
        public int DucksFed { get; set; }

    }

}
