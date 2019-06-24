using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks.Data.Migrations
{
    using Ducks.Data.Context;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration: DbMigrationsConfiguration<DuckContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = false;
            AutomaticMigrationsEnabled = true;
        }
    }
}
