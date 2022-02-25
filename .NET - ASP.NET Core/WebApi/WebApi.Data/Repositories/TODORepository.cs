using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entities;

namespace WebApi.Data.Repositories
{
    public class TODORepository : ITODORepository
    {
        private readonly TODODbContext _dbContext;

        public TODORepository(TODODbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TODO entity)
        {
            _dbContext.TODOs.Add(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TODO entity)
        {
            _dbContext.TODOs.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TODO>> GetAllAsync() =>
            await _dbContext.TODOs.ToListAsync();

        public async Task<TODO> GetByIdAsync(int todoId) =>
            await _dbContext.TODOs.FirstOrDefaultAsync(td => td.Id == todoId);

        public async Task UpdateAsync(TODO entity)
        {
            _dbContext.TODOs.Update(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
