using SportsLeague.Domain.Entities;

namespace SportsLeague.Domain.Interfaces.Repositories
{
    public interface ITournamentSponsorRepository : IGenericRepository<TournamentSponsor>
    {
        Task<TournamentSponsor?> GetByTournamentAndSponsorAsync(int tournamentId, int sponsorId);
        Task<IEnumerable<TournamentSponsor>> GetByTournamentAsync(int tournamentId);

        
        Task<IEnumerable<TournamentSponsor>> GetBySponsorAsync(int sponsorId);//to allow a sponsor to have multiple tournaments

    }
}