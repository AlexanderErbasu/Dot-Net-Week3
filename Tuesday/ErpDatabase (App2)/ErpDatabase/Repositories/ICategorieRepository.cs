using ErpDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Repositories
{
    public interface ICategorieRepository
    {
        int Insert(Categorie entity);

        void Update(Categorie entity);

        void Delete(int id);

        Categorie GetById(int id);

        IList<Categorie> GetAll();
    }
}
