using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks.Initializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = System.IO.File.ReadAllText(@"baselocations.json");
            var test1=Newtonsoft.Json.JsonConvert.DeserializeObject<List<Location>>(file);
            var db = new Ducks.Data.Context.DuckContext();
            var test2 = test1.GroupBy(x => x.country);
            foreach (var item in test2)
            {
                Ducks.Data.Country countryAdded = new Data.Country(); ;
                var country = item.Key;
                if (db.Countries.Where(x => x.Name == country).Count() == 0)
                {
                    countryAdded = new Data.Country() { Id = Guid.NewGuid(), Name = country };
                    db.Countries.Add(countryAdded);
                }
                // Console.WriteLine($"Country is: {country}");
                var state = item.GroupBy(x => x.subcountry).ToList();
                foreach (var city in state)
                {
                    if (countryAdded.Id != Guid.Empty)
                    {
                        Ducks.Data.State stateToAdd = new Data.State();
                        //Console.WriteLine($"State is: {city.Key}");
                        stateToAdd = new Data.State() { Id = Guid.NewGuid(), Country = countryAdded, Name = city.Key };
                        db.State.Add(stateToAdd);

                        foreach (var location in city.ToList())
                        {
                            if (stateToAdd.Id != Guid.Empty)
                            {
                                Ducks.Data.City cityToAdd = new Data.City();
                              
                                cityToAdd = new Data.City() { Id = Guid.NewGuid(), Country = countryAdded, State = stateToAdd, Name = location.name };
                                db.Cities.Add(cityToAdd);

                            }
                          
                        }
                    }
                }
            }

            db.Unit.Add(new Data.Unit { Id = Guid.NewGuid(), Measurement = "Pounds" });
            db.Unit.Add(new Data.Unit { Id = Guid.NewGuid(), Measurement = "Grams" });
            db.Unit.Add(new Data.Unit { Id = Guid.NewGuid(), Measurement = "Pieces" });
            db.Unit.Add(new Data.Unit { Id = Guid.NewGuid(), Measurement = "Handful" });
            db.Unit.Add(new Data.Unit { Id = Guid.NewGuid(), Measurement = "Ounces" });
            db.Unit.Add(new Data.Unit { Id = Guid.NewGuid(), Measurement = "Millilitres" });
            db.SaveChanges();

            Console.Write(file);
            while (1 == 1) ;
        }
    }


    public class Location
    {
        public string country { get; set; }
        public int geonameid { get; set; }
        public string name { get; set; }
        public string subcountry { get; set; }
    }
}
