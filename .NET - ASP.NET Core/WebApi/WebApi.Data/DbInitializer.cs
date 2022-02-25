using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entities;

namespace WebApi.Data
{
    public class DbInitializer
    {
        private readonly TODODbContext _dbContext;

        public DbInitializer(TODODbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitializeAsync()
        {
            await ApplyMigrationsAsync();
            await SeedAsync();
        }

        private async Task ApplyMigrationsAsync()
        {
            var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
            {
                await _dbContext.Database.MigrateAsync();
            }
        }

        private async Task SeedAsync()
        {
            await SeedStatusesAsync();
            await SeedPrioritiesAsync();
            await SeedTODOsAsync();
        }

        private async Task SeedTODOsAsync()
        {
            if (await _dbContext.TODOs.AnyAsync())
            {
                return;
            }

            var priorityLow = await _dbContext.Priorities.FirstAsync(p => p.Title == "Low");
            var priorityMedium = await _dbContext.Priorities.FirstAsync(p => p.Title == "Medium");
            var priorityHigh = await _dbContext.Priorities.FirstAsync(p => p.Title == "High");

            var statusPending = await _dbContext.Statuses.FirstAsync(p => p.Title == "Pending");
            var statusProgress = await _dbContext.Statuses.FirstAsync(p => p.Title == "In Progress");
            var statusComplete = await _dbContext.Statuses.FirstAsync(p => p.Title == "Complete");

            var TODOs = new List<TODO>
            {
                new TODO() 
                { 
                    Title = "Learn .NET", 
                    Description = "Watch lecture, do homework, be happy", 
                    PriorityId = priorityHigh.PriorityId, 
                    StatusId = statusProgress.StatusId
                },
                new TODO()
                {
                    Title = "Learn ASP.NET Core",
                    Description = "Watch lecture, do homework, be happy",
                    PriorityId = priorityHigh.PriorityId,
                    StatusId = statusComplete.StatusId
                },
                new TODO()
                {
                    Title = "Learn EFCore",
                    Description = "Watch lecture, do homework, be sad",
                    PriorityId = priorityMedium.PriorityId,
                    StatusId = statusPending.StatusId
                },
                new TODO()
                {
                    Title = "Learn Angular",
                    Description = "Watch lecture, do homework, don't cry",
                    PriorityId = priorityMedium.PriorityId,
                    StatusId = statusComplete.StatusId
                },
                new TODO()
                {
                    Title = "Learn Ruby",
                    Description = "Watch lecture, do homework, be indifferent",
                    PriorityId = priorityLow.PriorityId,
                    StatusId = statusPending.StatusId
                },
                new TODO()
                {
                    Title = "Learn React",
                    Description = "Watch lecture, do homework, try to hold it together",
                    PriorityId = priorityHigh.PriorityId,
                    StatusId = statusProgress.StatusId
                },
            };

            _dbContext.TODOs.AddRange(TODOs);
            await _dbContext.SaveChangesAsync();
        }

        private async Task SeedPrioritiesAsync()
        {
            if (await _dbContext.Priorities.AnyAsync())
            {
                return;
            }

            var priorities = new List<Priority>
            {
                new Priority { Title = "Low" },
                new Priority { Title = "Medium" },
                new Priority { Title = "High" },
            };

            _dbContext.Priorities.AddRange(priorities);
            await _dbContext.SaveChangesAsync();
        }

        private async Task SeedStatusesAsync()
        {
            if (await _dbContext.Statuses.AnyAsync())
            {
                return;
            }

            var statuses = new List<Status>
            {
                new Status { Title = "Pending" },
                new Status { Title = "In Progress" },
                new Status { Title = "Complete" },
            };

            _dbContext.Statuses.AddRange(statuses);
            await _dbContext.SaveChangesAsync();
        }
    }
}
