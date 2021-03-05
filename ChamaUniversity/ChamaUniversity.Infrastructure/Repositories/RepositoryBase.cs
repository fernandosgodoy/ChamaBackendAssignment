using ChamaUniversity.Data.Configuration;
using ChamaUniversity.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChamaUniversity.Data.Repositories
{
    public class RepositoryBase<T>
        : IRepository<T>, IDisposable
        where T : BaseEntity
    {

        private readonly DbContextOptions<ChamaUniversityContext> _optionsBuilder;

        public RepositoryBase()
        {
            this._optionsBuilder = new DbContextOptions<ChamaUniversityContext>();
        }

        public async void Add(T entity)
        {
            using (var data = new ChamaUniversityContext(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(entity);
                await data.SaveChangesAsync();
            }
        }

        public async void Delete(T entity)
        {
            using (var data = new ChamaUniversityContext(_optionsBuilder))
            {
                data.Set<T>().Remove(entity);
                await data.SaveChangesAsync();
            }
        }

        public T GetEntityById(int id)
        {
            using (var data = new ChamaUniversityContext(_optionsBuilder))
            {
                return data.Set<T>().Find(id);
            }
        }

        public List<T> List()
        {
            using (var data = new ChamaUniversityContext(_optionsBuilder))
            {
                return data.Set<T>()
                    .AsNoTracking()
                    .ToList();
            }
        }

        public async void Update(T entity)
        {
            using (var data = new ChamaUniversityContext(_optionsBuilder))
            {
                data.Set<T>().Update(entity);
                await data.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            
        }
    }
}
