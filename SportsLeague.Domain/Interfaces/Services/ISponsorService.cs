using SportsLeague.Domain.Entities;

namespace SportsLeague.Domain.Interfaces.Services
{
    public interface ISponsorService
    {
        Task<IEnumerable<Sponsor>> GetAllAsync();
        Task<Sponsor?> GetByIdAsync(int id);
        Task<Sponsor> CreateAsync(Sponsor sponsor);
        Task UpdateAsync(int id, Sponsor sponsor);
        Task DeleteAsync(int id);

        // These methods must be defined in the interface; otherwise, they cannot be accessed
        // when using dependency injection through ISponsorService. If they are only implemented
        // in SponsorService, they won't be recognized when the service is injected via Program.cs.
        Task LinkToTournamentAsync(int sponsorId, int tournamentId, decimal contractAmount);
        Task<IEnumerable<TournamentSponsor>> GetTournamentsBySponsorAsync(int sponsorId);
        Task UnlinkFromTournamentAsync(int sponsorId, int tournamentId);
    }
}