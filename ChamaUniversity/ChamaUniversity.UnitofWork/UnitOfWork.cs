using ChamaUniversity.Data.Configuration;
using ChamaUniversity.Data.Repositories;
using ChamaUniversity.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.UnitofWork
{
    public class UnitOfWork
        : IUnitOfWork
    {

        private readonly DbContext _dbContext;
        private Hashtable _repositories;
        public UnitOfWork(ChamaUniversityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)_repositories[type];
        }
    }
}
