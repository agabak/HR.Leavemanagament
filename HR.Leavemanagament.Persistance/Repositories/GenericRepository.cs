using HR.Leavemanagament.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LeaveManagamentDBContext _dBContext;

        public GenericRepository(LeaveManagamentDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<T> Add(T entity)
        {
            await _dBContext.AddAsync(entity);
            await _dBContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dBContext.Set<T>().Remove(entity);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(int id)
        {
            return await _dBContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dBContext.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _dBContext.Entry(entity).State = EntityState.Modified;
            await _dBContext.SaveChangesAsync();
        }
    }
}
