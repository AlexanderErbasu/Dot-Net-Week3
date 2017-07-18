using ErpDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Repositories
{
    public interface IClientRepository
    {
        int Insert(Client entity);

        void Update(Client entity);

        void Delete(int id);

        Client GetById(int id);

        IList<Client> GetAll();
    }
}
