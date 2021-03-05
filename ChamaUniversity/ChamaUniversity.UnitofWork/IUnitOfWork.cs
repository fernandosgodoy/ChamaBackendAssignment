using ChamaUniversity.Data.Repositories;
using ChamaUniversity.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.UnitofWork
{
    public interface IUnitOfWork
    {

        IRepository<T> Repository<T>() where T : BaseEntity;

    }
}
