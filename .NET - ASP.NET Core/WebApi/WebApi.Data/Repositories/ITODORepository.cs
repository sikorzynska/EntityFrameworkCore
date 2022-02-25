using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Entities;

namespace WebApi.Data.Repositories
{
    public interface ITODORepository
    {
        Task<IEnumerable<TODO>> GetAllAsync();
        Task<TODO> GetByIdAsync(int todoId);
        Task AddAsync(TODO entity);
        Task DeleteAsync(TODO entity);
        Task UpdateAsync(TODO entity);
    }
}
