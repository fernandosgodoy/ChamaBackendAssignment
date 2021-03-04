using ChamaUniversity.Dtos.Base;
using ChamaUniversity.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IGenericCrud<T>
        where T : class
    {

        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

        Task<T> GetEntityById(int id);
        Task<List<T>> List();

    }
}
