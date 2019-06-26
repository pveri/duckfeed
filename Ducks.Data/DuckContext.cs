using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Ducks.Data.Context
{
    public class DuckContext : DbContext
    {
        public DuckContext(string conn) : base(conn)
        {

        }
        public DuckContext() : base("name=DucksConnection")
        {

        }
        public DbSet<Food> Food { get; set; }
        public DbSet<FeedLog> FeedLog { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

    }
}
