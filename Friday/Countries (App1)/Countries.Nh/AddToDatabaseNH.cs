using Countries.Ef.RepositoriesImpl;
using Countries.Entities;
using Countries.Nh.RepositoriesImpl;
using Countries.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Nh
{
    public class AddToDatabaseNH
    {
        IRepository<Country> repo;
        ICsvCountrieFileParser parser;

        public AddToDatabaseNH(NhRepository<Country> repo, ICsvCountrieFileParser parser)
        {
            this.repo = repo;
            this.parser = parser;
        }

        public IList<Country> Add(string filePath)
        {
            IList<Country> list = parser.Read(filePath);

            foreach (var element in list)
            {
                repo.Insert(element);
            }

            return list;
        }

    }
}
