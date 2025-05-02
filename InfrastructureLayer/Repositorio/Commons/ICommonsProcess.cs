using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositorio.Commons
{
    public interface ICommonsProcess<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<(bool isCompleted, string Message)> AddAsync(T entity);
        Task<(bool isCompleted, string Message)> UpdateAsync(T entity);
        Task<(bool isCompleted, string Message)> DeleteAsync(int id);
        Task<IEnumerable<string>> AddAsync();
    }
}
