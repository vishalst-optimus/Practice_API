using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {

        public Task<T> GetByIdAsync(int id);
        public Task<bool> DeleteByIdAsync(int id);
        public Task<T> UpdateDataAsync(T entity);
        public Task<T> InsertDataAsync(T entity);
        public Task<IEnumerable<T>?> GetAllAsync();


    }
}
