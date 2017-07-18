using ErpDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Repositories
{
    public interface IProdusRepository
    {
        int Insert(Produs entity);

        void Update(Produs entity);

        void Delete(int id);

        Produs GetById(int id);

        IList<Produs> GetAll();
    }
}
