using Microsoft.Extensions.Logging;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;

namespace SportsLeague.Domain.Services
{
    public class SponsorService : ISponsorService
    {
        private readonly ISponsorRepository _sponsorRepository;
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITournamentSponsorRepository _tournamentSponsorRepository;
        private readonly ILogger<SponsorService> _logger;

        public SponsorService(
            ISponsorRepository sponsorRepository,
            ITournamentRepository tournamentRepository,
            ITournamentSponsorRepository tournamentSponsorRepository,
            ILogger<SponsorService> logger)
        {
            _sponsorRepository = sponsorRepository;
            _tournamentRepository = tournamentRepository;
            _tournamentSponsorRepository = tournamentSponsorRepository;
            _logger = logger;
        }
        public async Task<IEnumerable<Sponsor>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all sponsors");
            return await _sponsorRepository.GetAllAsync();
        }

        public async Task<Sponsor?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Retrieving sponsor with ID: {SponsorId}", id);
            var sponsor = await _sponsorRepository.GetByIdAsync(id);
            if (sponsor == null)
                _logger.LogWarning("Sponsor with ID {SponsorId} not found", id);

            return sponsor;
        }
        public async Task<Sponsor> CreateAsync(Sponsor sponsor)
        {
            var exists = await _sponsorRepository.ExistsByNameAsync(sponsor.Name);
            if (exists)
                throw new InvalidOperationException("Ya existe un sponsor con ese nombre");
            _logger.LogInformation("Creating sponsor: {SponsorName}", sponsor.Name);

            return await _sponsorRepository.CreateAsync(sponsor);
        }
        public async Task UpdateAsync(int id, Sponsor sponsor)
        {
            var existing = await _sponsorRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"No se encontró el sponsor con ID: {id}");

            if (!existing.Name.Equals(sponsor.Name, StringComparison.OrdinalIgnoreCase))
            {
                var exists = await _sponsorRepository.ExistsByNameAsync(sponsor.Name);
                if (exists)
                    throw new InvalidOperationException("Ya existe un sponsor con ese nombre en la base de datos");
            }

            existing.Name = sponsor.Name;
            existing.ContactEmail = sponsor.ContactEmail;
            existing.Phone = sponsor.Phone;
            existing.WebsiteUrl = sponsor.WebsiteUrl;
            existing.Category = sponsor.Category;

            _logger.LogInformation("Updating sponsor with ID: {SponsorId}", id);
            await _sponsorRepository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _sponsorRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"No se encontró el sponsor con ID {id}");

            _logger.LogInformation("Deleting sponsor with ID: {SponsorId}", id);
            await _sponsorRepository.DeleteAsync(id);
        }
        public async Task LinkToTournamentAsync(int sponsorId, int tournamentId, decimal contractAmount)
        {
            if (contractAmount <= 0)
                throw new InvalidOperationException("El ContractAmount debe ser mayor a 0 para que sea valido");
            var sponsor = await _sponsorRepository.GetByIdAsync(sponsorId);
            if (sponsor == null)
                throw new KeyNotFoundException($"No se encontró el sponsor con ID {sponsorId}");

            var tournament = await _tournamentRepository.GetByIdAsync(tournamentId);
            if (tournament == null)
                throw new KeyNotFoundException($"No se encontró el torneo con ID {tournamentId}");

            var existing = await _tournamentSponsorRepository
                .GetByTournamentAndSponsorAsync(tournamentId, sponsorId);
            if (existing != null)
                throw new InvalidOperationException($"Este sponsor ya está vinculado al torneo con ID: {tournamentId}");
            var tournamentSponsor = new TournamentSponsor
            {
                SponsorId = sponsorId,
                TournamentId = tournamentId,
                ContractAmount = contractAmount,
                JoinedAt = DateTime.UtcNow
            };

            _logger.LogInformation(
                "Linking sponsor {SponsorId} to tournament {TournamentId}",
                sponsorId, tournamentId);

            await _tournamentSponsorRepository.CreateAsync(tournamentSponsor);
        }

        public async Task<IEnumerable<TournamentSponsor>> GetTournamentsBySponsorAsync(int sponsorId)
        {
            var sponsor = await _sponsorRepository.GetByIdAsync(sponsorId);

            if (sponsor == null)
                throw new KeyNotFoundException($"No se encontró el sponsor con ID {sponsorId}");

            var allRelations = await _tournamentSponsorRepository.GetAllAsync();

            return allRelations
                .Where(ts => ts.SponsorId == sponsorId);
        }

        public async Task UnlinkFromTournamentAsync(int sponsorId, int tournamentId)
        {
            var existing = await _tournamentSponsorRepository
                .GetByTournamentAndSponsorAsync(tournamentId, sponsorId);

            if (existing == null)
                throw new KeyNotFoundException(
                    "La relación entre sponsor y torneo no existe");

            _logger.LogInformation(
                "Unlinking sponsor {SponsorId} from tournament {TournamentId}",
                sponsorId, tournamentId);

            await _tournamentSponsorRepository.DeleteAsync(existing.Id);
        }
    }
}