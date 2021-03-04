using Domain.Interfaces.Generics;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generic
{
    public class RepositoryGenerics<T>
        : IGenericCrud<T>, IDisposable
        where T : class
    {

        private readonly DbContextOptions<BaseContext> _optionsBuilder;

        public RepositoryGenerics()
        {
            this._optionsBuilder = new DbContextOptions<BaseContext>();
        }

        public async Task Add(T entity)
        {
            using (var data = new BaseContext(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(entity);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T entity)
        {
            using (var data = new BaseContext(_optionsBuilder))
            {
                data.Set<T>().Remove(entity);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityById(int id)
        {
            using (var data = new BaseContext(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new BaseContext(_optionsBuilder))
            {
                return await data.Set<T>()
                    .AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task Update(T entity)
        {
            using (var data = new BaseContext(_optionsBuilder))
            {
                data.Set<T>().Update(entity);
                await data.SaveChangesAsync();
            }
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
