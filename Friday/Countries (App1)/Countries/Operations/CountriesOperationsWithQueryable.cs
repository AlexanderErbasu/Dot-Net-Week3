using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries.Entities;

namespace Countries.Operations
{
    public class CountriesOperationsWithQueryable : ICountriesOperations
    {
        IList<Country> countries;

        public CountriesOperationsWithQueryable(IList<Country> countries)
        {
            this.countries = countries;
        }

        public IList<Country> AllWithPosition()
        {
            //return countries
            //    .Where(c => c.Latitude != null && c.Longitude != null)
            //    .ToList();
            return countries
                .Where(c => c.Latitude.HasValue && c.Longitude.HasValue)
                .ToList();
        }

        public IList<Country> FirstCountriesOrderedByName(int howMany, string name)
        {
            return 
                countries
                    .Where(c => c.Nume.StartsWith(name))
                    .OrderBy(c => c.Nume)
                    .Take(howMany)
                    .ToList();
        }

        private class myPrivateClass : IEqualityComparer<Country>
        {
            public bool Equals(Country x, Country y)
            {
                return x.Code == y.Code && x.Nume == y.Nume;
            }

            public int GetHashCode(Country obj)
            {
                return obj.Code.GetHashCode();
            }
        }

        public IList<VeryLittleCountry> GetAllCountryNames()
        {
            return countries
                .Distinct(new myPrivateClass())
                .Select(c => new LittleCountry
                    {
                        Code = c.Code,
                        Name = c.Nume
                })
                    .Where(lc => lc.Code.StartsWith("d"))
                    .Select(lc => new VeryLittleCountry {  Code =lc.Code})
                    .Where(vlc => vlc.Code == "ss")
                    .ToList();
        }

        public IList<Country> GetPageFilterByNameOrderByName(int howMany, int pageNumber, string name)
        {
            return
                countries
                    .Where(c => c.Nume.StartsWith(name))
                    .OrderBy(c => c.Nume)
                    .Skip(pageNumber * howMany)
                    .Take(howMany)
                    .ToList();
        }

        public Dictionary<string, List<Country>> GroupByNameFirstLetter()
        {
            return countries
                .GroupBy(a => a.Nume.Substring(0, 1))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.ToList());
        }

        public IList<Country> ListNameStartsWith(string name)
        {
            return countries.Where(c => c.Nume.StartsWith(name)).ToList();
        }

        public decimal MedianOfSumsOfLatAnLongForNameStartsWith(string name)
        {
            return countries.Where(c =>
    c.Latitude.HasValue && c.Longitude.HasValue && c.Nume.StartsWith(name))
            .Average(c => c.Latitude.Value + c.Longitude.Value);
        }

        public Country SingleByCode(string code)
        {
            return countries.SingleOrDefault(c => c.Code == code);
        }

        public decimal SumOfLatitudeForNameStartsWith(string name)
        {
            return countries.Where(c =>
                c.Latitude.HasValue && c.Longitude.HasValue && c.Nume.StartsWith(name))
                        .Sum(c => c.Latitude.Value);
        }

        IList<Country> ICountriesOperations.GetAllCountryNames()
        {
            throw new NotImplementedException();
        }
    }
}
