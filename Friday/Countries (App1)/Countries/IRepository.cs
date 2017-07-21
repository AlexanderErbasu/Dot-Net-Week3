using Countries.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries
{
    public interface IRepository<T>
        where T : IEntity, new()
    {
        string Insert(T entity);

        void Update(T entity);

        void Delete(string id);

        T GetById(string id);

        IList<T> GetAll();
    }
}
