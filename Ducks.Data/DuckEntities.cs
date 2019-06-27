using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks.Data
{
    public class BaseData
    {
        public String AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
    }
    public class Country
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
    }

    public class State
    {
        public Guid Id { get; set; }
        public virtual Country Country { get; set; }
        public String Name { get; set; }
    }

    public class City
    {
        public Guid Id { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public string Name { get; set; }
    }

    public class Location : BaseData
    {
        public Guid Id { get; set; }
        public virtual City City { get; set; }
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
    public class Food : BaseData
    {
        public Guid id { get; set; }
        public String Name { get; set; }
        public virtual Unit Unit { get; set; }

    }

    public class FeedLog
    {
        public Guid Id { get; set; }
        public virtual User User { get; set; }
        public virtual Location Location { get; set; }
        public virtual Food Food { get; set; }
        public int FoodAmount { get; set; }
        public int DucksFed { get; set; }
        public DateTime? DateFed { get; set; }
    }

    public class Schedule
    {
        public Guid Id { get; set; }
        public virtual User User { get; set; }
        public virtual FeedLog FeedLog { get; set; }
        public TimeSpan TimeOfDay { get; set; }
        public DateTime? LastRun { get; set; }
    }

}
