using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practice.Application.Interfaces;

namespace Practice.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PracticeDbContext _context;
        private DbSet<T> _dbSet;
        public GenericRepository(PracticeDbContext _context)
        {
            this._context = _context;
            _dbSet = _context.Set<T>();
        }
        public async Task<bool> DeleteByIdAsync(int id)
        {
            //FOR Removing multiple records (Eg: Delete all employees with departmentId = 1)
            //var data = GetByIdAsync(id);
            ////Convert Task<IEnumerable<T>> to IEnumerable<T>, to iterate it
            //var record = (await data).ToList();

            //if(record.Count > 0)
            //{
            //    foreach(var item in record)
            //    {
            //        _dbSet.Remove(item);
            //    }
            //    await _context.SaveChangesAsync();
            //    return true;
            //}

            //return false;

            //For removing single record
            var data = await GetByIdAsync(id);
            if (data != null)
            {
                _dbSet.Remove(data);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            //To get multiple outputs (Eg: Get all employees with departmentId = 1)
            //var res = await _dbSet.Where(opt => EF.Property<int>(opt, "Id") == id).ToListAsync();

            //To get single output
            var data = await _dbSet.FindAsync(id);

            return data;
        }

        public async Task<T> InsertDataAsync(T entity)
        {
            _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateDataAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
