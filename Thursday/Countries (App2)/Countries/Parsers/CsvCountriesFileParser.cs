using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries.Entities;
using System.IO;

namespace Countries.Parsers
{
    public class CsvCountriesFileParser : ICsvCountrieFileParser
    {
        public IList<Country> Read(string filePath)
        {
            var countries = new List<Country>();

            var text = File.ReadAllLines(filePath);

            //separation by lines

            for (int i= 1; i<text.Length; i++)
            {
                var elements = text[i].Split(',');

                var country = new Country();

                country.Code = elements[0];
                decimal result1;
                if(decimal.TryParse(elements[1],out result1)==true)
                    country.Latitude = Decimal.Parse(elements[1]);
                if (decimal.TryParse(elements[2], out result1) == true)
                    country.Longitude = Decimal.Parse(elements[2]);
                country.Name = elements[3];

                countries.Add(country);
            }

            return countries;
        }
    }
}
