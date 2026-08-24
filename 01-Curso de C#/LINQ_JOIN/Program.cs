using System.Linq;

namespace LINQ_JOIN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var beers = new List<Beer>()
            {
                new Beer() {
                    Name="Corona", Country="Mexico"
                },
                new Beer()
                {
                    Name="Delirium", Country="Belgica"
                },
                new Beer()
                {
                    Name="Erdinger", Country="Alemania"
                }
            };

            var countries = new List<Country>()
            {
                new Country()
                {
                    Name="Mexico", Continent="America"
                },
                                new Country()
                {
                    Name="Alemania", Continent="Europa"
                },
                                                new Country()
                {
                    Name="Belgica", Continent="Europa"
                }
            };

            var beersWithContinent = from beer in beers
                                     join country in countries
                                     on beer.Country equals country.Name
                                     select new
                                     {
                                         Name = beer.Name,
                                         country = beer.Country,
                                         Continent = country.Continent
                                     };
            foreach (var beer in beersWithContinent)
            {
                Console.WriteLine($"{beer.Name} {beer.country} {beer.Continent}");
            }
        }

    }

    public class Beer
    {
        public  required string Name { get; set; }

        public required string Country { get; set; }

    }

    public class Country
    {
        public required string Name { get; set; }

        public required string Continent { get; set; }

    }


}
