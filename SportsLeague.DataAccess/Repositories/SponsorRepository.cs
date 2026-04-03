using SportsLeague.DataAccess.Context;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace SportsLeague.DataAccess.Repositories
{
    public class SponsorRepository : GenericRepository<Sponsor>, ISponsorRepository
    {
        public SponsorRepository(LeagueDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Sponsor>> GetByNationalityAsync(string nationality)
        {
            return await _dbSet
                .Where(r => r.Nationality.ToLower() == nationality.ToLower())
                .ToListAsync();
        }
    }
}