using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries.Entities;

namespace Countries.Operations
{
    public class CountriesOperation : ICountriesOperations
    {
        IList<Country> countries;
        public CountriesOperation(IList<Country> countries)
        {
            this.countries = countries;
        }
        public Dictionary<string, List<Country>> GroupByNameFirstLetter()
        {
            var dict = new Dictionary<string, List<Country>>();

            
            foreach (var country in countries)
            {
                if (!dict.ContainsKey(country.Name.Substring(0, 1)))
                    dict.Add(country.Name.Substring(0, 1), new List<Country>());

            }
            foreach(var country in countries)
            {
                dict[country.Name.Substring(0, 1)].Add(country);
            }
            return dict;
        }

        public IList<Country> ListNameStartsWith(string name)
        {
            var countriesWithLetter = new List<Country>();

            foreach (var country in countries)
            {
                if (country.Name.Substring(0, name.Length) == name)
                {
                    countriesWithLetter.Add(country);
                }
                
            }
            return countriesWithLetter;
           
        }

        public Country SingleByCode(string code)
        {
            foreach (var country in countries)
            {
                if (country.Code ==  code)
                {
                    return country;
                }

            }
            return null;
        }
    }
}
