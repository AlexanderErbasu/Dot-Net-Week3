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
            return countries.Where(c => c.Latitude != null && c.Longitude != null).ToList();
        }

        public Dictionary<string, List<Country>> GroupByNameFirstLetter()
        {
            return countries
                .GroupBy(a => a.Name.Substring(0, 1))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.ToList());
        }

        public IList<Country> ListNameStartsWith(string name)
        {
            return countries.Where(c => c.Name.StartsWith(name))
                .ToList();
        }

        public decimal MedianOfSumsOfLatAnLongForNameStartsWith(string name)
        {
            throw new NotImplementedException();
        }

        public Country SingleByCode(string code)
        {
            return countries.SingleOrDefault(c => c.Code == code);
        }

        public decimal SumOfLatitudeForNameStartsWith(string name)
        {
            return (decimal)AllWithPosition().Where(c => c.Name.Substring(0, name.Length) == name).Sum(c => c.Latitude);
        }
    }
}
