using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RentACar.Application.Interfaces;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RentaCarContext _context;

        public Repository(RentaCarContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
           _context.Set<T>().Add(entity);
           await _context.SaveChangesAsync();   
        }

        public async Task<List<T>> GetAllAsync(
     Expression<Func<T, bool>>? predicate = null,
     Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
     Func<IQueryable<T>, IOrderedQueryable<T>>? order = null,
     int? takecount = null)
        {
            IQueryable<T> queryrable = _context.Set<T>();

            if (include is not null)
                queryrable = include(queryrable);

            if (order is not null)
                queryrable = order(queryrable);

            if (predicate is not null)
                queryrable = queryrable.Where(predicate);

            if (takecount is not null)
                queryrable = queryrable.Take((int)takecount);

            return await queryrable.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate , Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            IQueryable<T> queryrable = _context.Set<T>();
            if (include is not null) queryrable = include(queryrable);



            return await queryrable.FirstAsync(predicate);
            
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
          _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
