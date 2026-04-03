using SportsLeague.Domain.Entities;

namespace SportsLeague.Domain.Interfaces.Repositories
{
    public interface ISponsorRepository : IGenericRepository<Sponsor>
    {
        Task<bool> ExistsByNameAsync(string name); //This method is used to avoid retrieving all the data.

    }
}