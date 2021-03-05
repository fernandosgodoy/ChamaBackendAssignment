using ChamaUniversity.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.Data.Repositories
{
    public interface IRepository<T>
        where T : BaseEntity
    {

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        T GetEntityById(int id);
        List<T> List();

    }
}
