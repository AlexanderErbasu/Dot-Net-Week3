using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries.Entities;
using Countries.Ef;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace Countries.Operations
{
    public class NHCountriesOperationsDB : ICountriesOperations
    {

        //context
        private ISession session;

        public NHCountriesOperationsDB(ISession session)
        {
            this.session = session;
        }

        public IList<Country> AllWithPosition()
        {
            return session.Query<Country>()
                .Where(c => c.Latitude.HasValue && c.Longitude.HasValue)
                .ToList();
        }

        public IList<Country> FirstCountriesOrderedByName(int howMany, string name)
        {
            return
                session.Query<Country>()
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

        public IList<Country> GetAllCountryNames()
        {
            return session.Query<Country>()
                .Distinct(new myPrivateClass())
                .Select(c => new Country
                {
                    Code = c.Code,
                    Nume = c.Nume
                })
                    .Where(lc => lc.Code.StartsWith("d"))
                    .Select(lc => new Country { Code = lc.Code })
                    .Where(vlc => vlc.Code == "ss")
                    .ToList();
        }

        public IList<Country> GetPageFilterByNameOrderByName(int howMany, int pageNumber, string name)
        {
            return
                session.Query<Country>()
                    .Where(c => c.Nume.StartsWith(name))
                    .OrderBy(c => c.Nume)
                    .Skip(pageNumber * howMany)
                    .Take(howMany)
                    .ToList();
        }

        public Dictionary<string, List<Country>> GroupByNameFirstLetter()
        {
            return session.Query<Country>()
                .GroupBy(a => a.Nume.Substring(0, 1))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.ToList());
        }

        public IList<Country> ListNameStartsWith(string name)
        {
            return session.Query<Country>().Where(c => c.Nume.StartsWith(name)).ToList();
        }

        public decimal MedianOfSumsOfLatAnLongForNameStartsWith(string name)
        {
            var x = session.Query<Country>().Where(c =>
    c.Latitude.HasValue && c.Longitude.HasValue && c.Nume.StartsWith(name))
            .Average(c => (double) c.Latitude.Value + (double) c.Longitude.Value);

            return Convert.ToDecimal(x);
        }

        public Country SingleByCode(string code)
        {
            return session.Query<Country>().SingleOrDefault(c => c.Code == code);
        }

        public decimal SumOfLatitudeForNameStartsWith(string name)
        {
            var x = session.Query<Country>().Where(c =>
                c.Latitude.HasValue && c.Longitude.HasValue && c.Nume.StartsWith(name))
                        .Sum(c => (double) c.Latitude.Value);

            return Convert.ToDecimal(x);
        }

       
    }
}
