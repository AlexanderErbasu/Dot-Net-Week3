using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries.Parsers;
using Countries.Ef.RepositoriesImpl;
using Countries.Entities;
using System.Data.Entity;

namespace Countries.Ef
{
    public class AddToDatabase //: IEfRepository<Country> //using ICsvCountrieFileParser
    {
        IRepository<Country> repo;
        ICsvCountrieFileParser parser;

        public AddToDatabase(EfRepository<Country> repo, ICsvCountrieFileParser parser)
        {
            this.repo = repo;
            this.parser = parser;
        }

        public IList<Country> Add(string filePath)
        {
            IList<Country> list = parser.Read(filePath);

            foreach(var element in list)
            {
                repo.Insert(element);
            }

            return list;
        }
        
    }
}
