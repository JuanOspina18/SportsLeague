using SportsLeague.DataAccess.Context;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace SportsLeague.DataAccess.Seeders;

public static class DataSeeder
{
    public static async Task SeedAsync(LeagueDbContext context)
    {
        if (await context.Teams.AnyAsync()) return;

        // ═══ 1. EQUIPOS (Liga BetPlay 2026) ═══
        var teams = new List<Team>
        {
            new() { Name="Atlético Nacional", City="Medellín", Stadium="Atanasio Girardot" },
            new() { Name="Independiente Medellín", City="Medellín", Stadium="Atanasio Girardot" },
            new() { Name="América de Cali", City="Cali", Stadium="Pascual Guerrero" },
            new() { Name="Deportivo Cali", City="Cali", Stadium="Deportivo Cali" },
            new() { Name="Junior FC", City="Barranquilla", Stadium="Metropolitano" },
            new() { Name="Millonarios FC", City="Bogotá", Stadium="El Campín" },
            new() { Name="Independiente Santa Fe", City="Bogotá", Stadium="El Campín" },
            new() { Name="Deportes Tolima", City="Ibagué", Stadium="Manuel Murillo Toro" },
            new() { Name="Atlético Bucaramanga", City="Bucaramanga", Stadium="Alfonso López" },
            new() { Name="Once Caldas", City="Manizales", Stadium="Palogrande" },
            new() { Name="Deportivo Pasto", City="Pasto", Stadium="Departamental Libertad" },
            new() { Name="Deportivo Pereira", City="Pereira", Stadium="Hernán Ramírez Villegas" },
            new() { Name="Águilas Doradas", City="Rionegro", Stadium="Alberto Grisales" },
            new() { Name="Boyacá Chicó FC", City="Tunja", Stadium="La Independencia" },
            new() { Name="Jaguares de Córdoba", City="Montería", Stadium="Jaraguay" },
            new() { Name="Alianza Valledupar FC", City="Valledupar", Stadium="Armando Maestre" },
            new() { Name="Fortaleza FC", City="Bogotá", Stadium="Metropolitano de Techo" },
            new() { Name="Llaneros FC", City="Villavicencio", Stadium="Bello Horizonte" },
            new() { Name="Cúcuta Deportivo", City="Cúcuta", Stadium="General Santander" },
            new() { Name="Internacional de Bogotá", City="Bogotá", Stadium="Metropolitano de Techo" },
        };

        context.Teams.AddRange(teams);
        await context.SaveChangesAsync();

        // ═══ 2. JUGADORES (4 por equipo = 80 total) ═══
        var playersData = new (string First, string Last, PlayerPosition Pos, int Number)[][]
        {
            // 0. Atlético Nacional
            new[] {
                ("David", "Ospina", PlayerPosition.Goalkeeper, 1),
                ("William", "Tesillo", PlayerPosition.Defender, 3),
                ("Edwin", "Cardona", PlayerPosition.Midfielder, 10),
                ("Alfredo", "Morelos", PlayerPosition.Forward, 9),
            },
            // 1. Independiente Medellín
            new[] {
                ("Salvador", "Ichazo", PlayerPosition.Goalkeeper, 1),
                ("Andrés", "Cadavid", PlayerPosition.Defender, 4),
                ("Adrián", "Arregui", PlayerPosition.Midfielder, 5),
                ("Luciano", "Pons", PlayerPosition.Forward, 9),
            },
            // 2. América de Cali
            new[] {
                ("Joel", "Graterol", PlayerPosition.Goalkeeper, 1),
                ("Jorge", "Segura", PlayerPosition.Defender, 3),
                ("Rodrigo", "Ureña", PlayerPosition.Midfielder, 8),
                ("Adrián", "Ramos", PlayerPosition.Forward, 9),
            },
            // 3. Deportivo Cali
            new[] {
                ("Pedro", "Gallese", PlayerPosition.Goalkeeper, 1),
                ("Fernando", "Álvarez", PlayerPosition.Defender, 4),
                ("Kevin", "Velasco", PlayerPosition.Midfielder, 10),
                ("Juan", "Dinenno", PlayerPosition.Forward, 9),
            },
            // 4. Junior FC
            new[] {
                ("Mauro", "Silveira", PlayerPosition.Goalkeeper, 1),
                ("Edwin", "Herrera", PlayerPosition.Defender, 4),
                ("Fabián", "Ángel", PlayerPosition.Midfielder, 8),
                ("Carlos", "Bacca", PlayerPosition.Forward, 7),
            },
            // 5. Millonarios FC
            new[] {
                ("Guillermo", "De Amores", PlayerPosition.Goalkeeper, 1),
                ("Omar", "Bertel", PlayerPosition.Defender, 4),
                ("Daniel", "Cataño", PlayerPosition.Midfielder, 10),
                ("Leonardo", "Castro", PlayerPosition.Forward, 9),
            },
            // 6. Independiente Santa Fe
            new[] {
                ("Leandro", "Castellanos", PlayerPosition.Goalkeeper, 1),
                ("Elvis", "Mosquera", PlayerPosition.Defender, 3),
                ("Daniel", "Giraldo", PlayerPosition.Midfielder, 5),
                ("Hugo", "Rodallega", PlayerPosition.Forward, 9),
            },
            // 7. Deportes Tolima
            new[] {
                ("William", "Cuesta", PlayerPosition.Goalkeeper, 1),
                ("Jersson", "González", PlayerPosition.Defender, 3),
                ("Junior", "Hernández", PlayerPosition.Midfielder, 10),
                ("Tatay", "Torres", PlayerPosition.Forward, 9),
            },
            // 8. Atlético Bucaramanga
            new[] {
                ("Juan Camilo", "Chaverra", PlayerPosition.Goalkeeper, 1),
                ("José", "Ortiz", PlayerPosition.Defender, 4),
                ("Sherman", "Cárdenas", PlayerPosition.Midfielder, 10),
                ("Sebastián", "Pons", PlayerPosition.Forward, 9),
            },
            // 9. Once Caldas
            new[] {
                ("Gerardo", "Ortiz", PlayerPosition.Goalkeeper, 1),
                ("Edisson", "Palomino", PlayerPosition.Defender, 3),
                ("Sebastián", "Gómez", PlayerPosition.Midfielder, 5),
                ("Dayro", "Moreno", PlayerPosition.Forward, 9),
            },
            // 10. Deportivo Pasto
            new[] {
                ("Diego", "Martínez", PlayerPosition.Goalkeeper, 1),
                ("Camilo", "Ayala", PlayerPosition.Defender, 4),
                ("Ray", "Vanegas", PlayerPosition.Midfielder, 10),
                ("Jown", "Cardona", PlayerPosition.Forward, 9),
            },
            // 11. Deportivo Pereira
            new[] {
                ("Harlen", "Castillo", PlayerPosition.Goalkeeper, 1),
                ("David", "González", PlayerPosition.Defender, 3),
                ("Brayan", "León", PlayerPosition.Midfielder, 8),
                ("Jonier", "Mosquera", PlayerPosition.Forward, 9),
            },
            // 12. Águilas Doradas
            new[] {
                ("José Fernando", "Cuadrado", PlayerPosition.Goalkeeper, 1),
                ("Éder", "Chaux", PlayerPosition.Defender, 4),
                ("Juan Pablo", "Ramírez", PlayerPosition.Midfielder, 10),
                ("Cristian", "Subero", PlayerPosition.Forward, 9),
            },
            // 13. Boyacá Chicó FC
            new[] {
                ("Ernesto", "Hernández", PlayerPosition.Goalkeeper, 1),
                ("Carlos", "Henao", PlayerPosition.Defender, 3),
                ("Brayan", "Moreno", PlayerPosition.Midfielder, 8),
                ("Juan David", "Valencia", PlayerPosition.Forward, 9),
            },
            // 14. Jaguares de Córdoba
            new[] {
                ("Diego", "Novoa", PlayerPosition.Goalkeeper, 1),
                ("Geovan", "Montes", PlayerPosition.Defender, 4),
                ("Larry", "Vásquez", PlayerPosition.Midfielder, 5),
                ("Pablo", "Bueno", PlayerPosition.Forward, 9),
            },
            // 15. Alianza Valledupar FC
            new[] {
                ("Luis", "Delgado", PlayerPosition.Goalkeeper, 1),
                ("Marvin", "Vallecilla", PlayerPosition.Defender, 3),
                ("Juan", "Sánchez", PlayerPosition.Midfielder, 8),
                ("Jeison", "Medina", PlayerPosition.Forward, 9),
            },
            // 16. Fortaleza FC
            new[] {
                ("Carlos", "Mosquera", PlayerPosition.Goalkeeper, 1),
                ("Nicolás", "Giraldo", PlayerPosition.Defender, 4),
                ("Jhonier", "Viveros", PlayerPosition.Midfielder, 10),
                ("Óscar", "Vanegas", PlayerPosition.Forward, 9),
            },
            // 17. Llaneros FC
            new[] {
                ("José Huber", "Escobar", PlayerPosition.Goalkeeper, 1),
                ("Cristian", "Arrieta", PlayerPosition.Defender, 3),
                ("Jhon", "Pajoy", PlayerPosition.Midfielder, 8),
                ("Brayan", "Gil", PlayerPosition.Forward, 9),
            },
            // 18. Cúcuta Deportivo
            new[] {
                ("Norberto", "Araujo", PlayerPosition.Goalkeeper, 1),
                ("Jefry", "Díaz", PlayerPosition.Defender, 4),
                ("Juan Camilo", "Portilla", PlayerPosition.Midfielder, 10),
                ("Edwar", "López", PlayerPosition.Forward, 9),
            },
            // 19. Internacional de Bogotá
            new[] {
                ("Neto", "Volpi", PlayerPosition.Goalkeeper, 1),
                ("Nicolás", "Hernández", PlayerPosition.Defender, 3),
                ("Carlos Darwin", "Quintero", PlayerPosition.Midfielder, 10),
                ("Facundo", "Boné", PlayerPosition.Forward, 9),
            },
        };

        var players = new List<Player>();

        for (int i = 0; i < teams.Count; i++)
        {
            foreach (var pd in playersData[i])
            {
                players.Add(new Player
                {
                    FirstName = pd.First,
                    LastName = pd.Last,
                    Number = pd.Number,
                    Position = pd.Pos,
                    BirthDate = new DateTime(1995, 1, 1).AddMonths(players.Count),
                    TeamId = teams[i].Id
                });
            }
        }

        context.Players.AddRange(players);
        await context.SaveChangesAsync();

        // ═══ 3. ÁRBITROS ═══
        var referees = new List<Referee>
        {
            new() { FirstName="Wilmar",  LastName="Roldán",    Nationality="Colombia" },
            new() { FirstName="Andrés",  LastName="Rojas",     Nationality="Colombia" },
            new() { FirstName="Carlos",  LastName="Betancur",  Nationality="Colombia" },
            new() { FirstName="Jhon",    LastName="Hinestroza", Nationality="Colombia" },
        };

        context.Referees.AddRange(referees);
        await context.SaveChangesAsync();

        // ═══ 4. TORNEO ═══
        var tournament = new Tournament
        {
            Name = "Liga BetPlay 2026-I",
            Season = "2026-I",
            StartDate = new DateTime(2026, 1, 16),
            EndDate = new DateTime(2026, 6, 5),
            Status = TournamentStatus.InProgress
        };

        context.Tournaments.Add(tournament);
        await context.SaveChangesAsync();

        // ═══ 5. SPONSORS ═══
        var sponsors = new List<Sponsor>
        {
            new() { Name="BetPlay",         ContactEmail="contacto@betplay.com.co",  Phone="+57 3000000001", WebsiteUrl="https://betplay.com.co",          Category=SponsorCategory.Main   },
            new() { Name="Adidas Colombia", ContactEmail="marketing@adidas.com.co",  Phone="+57 3000000002", WebsiteUrl="https://www.adidas.co",           Category=SponsorCategory.Gold   },
            new() { Name="Coca-Cola",       ContactEmail="sports@coca-cola.com",     Phone="+57 3000000003", WebsiteUrl="https://www.coca-cola.com/co/es", Category=SponsorCategory.Gold   },
            new() { Name="Águila",          ContactEmail="patrocinios@aguila.com.co",Phone="+57 3000000004", WebsiteUrl="https://www.aguila.com.co",       Category=SponsorCategory.Silver },
            new() { Name="Movistar",        ContactEmail="alianzas@movistar.co",     Phone="+57 3000000005", WebsiteUrl="https://www.movistar.co",         Category=SponsorCategory.Silver },
            new() { Name="Gatorade",        ContactEmail="sports@gatorade.com",      Phone="+57 3000000006", WebsiteUrl="https://www.gatorade.com",        Category=SponsorCategory.Bronze },
        };

        context.Sponsors.AddRange(sponsors);
        await context.SaveChangesAsync();

        // ═══ 6. RELACIÓN TORNEO — SPONSORS ═══
        var tournamentSponsors = new List<TournamentSponsor>
        {
            new() { TournamentId=tournament.Id, SponsorId=sponsors[0].Id, ContractAmount=500000000, JoinedAt=DateTime.UtcNow },
            new() { TournamentId=tournament.Id, SponsorId=sponsors[1].Id, ContractAmount=250000000, JoinedAt=DateTime.UtcNow },
            new() { TournamentId=tournament.Id, SponsorId=sponsors[2].Id, ContractAmount=220000000, JoinedAt=DateTime.UtcNow },
            new() { TournamentId=tournament.Id, SponsorId=sponsors[3].Id, ContractAmount=150000000, JoinedAt=DateTime.UtcNow },
            new() { TournamentId=tournament.Id, SponsorId=sponsors[4].Id, ContractAmount=120000000, JoinedAt=DateTime.UtcNow },
            new() { TournamentId=tournament.Id, SponsorId=sponsors[5].Id, ContractAmount= 80000000, JoinedAt=DateTime.UtcNow },
        };

        context.TournamentSponsors.AddRange(tournamentSponsors);
        await context.SaveChangesAsync();

        // ═══ 7. INSCRIBIR LOS 20 EQUIPOS AL TORNEO ═══
        foreach (var team in teams)
        {
            context.TournamentTeams.Add(new TournamentTeam
            {
                TournamentId = tournament.Id,
                TeamId = team.Id
            });
        }

        await context.SaveChangesAsync();

        // ═══ 8. PARTIDOS ═══
        // matches[0..3] → Scheduled  (para probar MatchLineup)
        // matches[4]    → Finished   (para escenario negativo V6 del Evento #4)
        var matches = new List<Match>
        {
            new()
            {
                TournamentId = tournament.Id,
                HomeTeamId   = teams[0].Id,  // Atlético Nacional
                AwayTeamId   = teams[1].Id,  // Independiente Medellín
                RefereeId    = referees[0].Id,
                MatchDate    = new DateTime(2026, 5, 24, 15, 0, 0),
                Venue        = "Atanasio Girardot",
                Matchday     = 1,
                Status       = MatchStatus.Scheduled
            },
            new()
            {
                TournamentId = tournament.Id,
                HomeTeamId   = teams[2].Id,  // América de Cali
                AwayTeamId   = teams[3].Id,  // Deportivo Cali
                RefereeId    = referees[1].Id,
                MatchDate    = new DateTime(2026, 5, 24, 17, 0, 0),
                Venue        = "Pascual Guerrero",
                Matchday     = 1,
                Status       = MatchStatus.Scheduled
            },
            new()
            {
                TournamentId = tournament.Id,
                HomeTeamId   = teams[4].Id,  // Junior FC
                AwayTeamId   = teams[5].Id,  // Millonarios FC
                RefereeId    = referees[2].Id,
                MatchDate    = new DateTime(2026, 5, 25, 15, 0, 0),
                Venue        = "Metropolitano",
                Matchday     = 1,
                Status       = MatchStatus.Scheduled
            },
            new()
            {
                TournamentId = tournament.Id,
                HomeTeamId   = teams[6].Id,  // Independiente Santa Fe
                AwayTeamId   = teams[7].Id,  // Deportes Tolima
                RefereeId    = referees[3].Id,
                MatchDate    = new DateTime(2026, 5, 25, 17, 0, 0),
                Venue        = "El Campín",
                Matchday     = 1,
                Status       = MatchStatus.Scheduled
            },
            new()
            {
                TournamentId = tournament.Id,
                HomeTeamId   = teams[8].Id,  // Atlético Bucaramanga
                AwayTeamId   = teams[9].Id,  // Once Caldas
                RefereeId    = referees[0].Id,
                MatchDate    = new DateTime(2026, 5, 18, 15, 0, 0),
                Venue        = "Alfonso López",
                Matchday     = 1,
                Status       = MatchStatus.Finished
            },
        };

        context.Matches.AddRange(matches);
        await context.SaveChangesAsync();

        // ═══ 9. RESULTADO, GOLES Y TARJETAS (partido Finished) ═══
        // Solo matches[4] (Bucaramanga 2 - 1 Once Caldas) tiene eventos registrados.
        // Índices de jugadores: teams[8]=Bucaramanga → players[32..35]
        //                       teams[9]=Once Caldas  → players[36..39]
        var matchFinished = matches[4];

        // players por equipo (4 cada uno, en orden GK/DEF/MID/FWD):
        // Bucaramanga: [32] Chaverra GK | [33] Ortiz DEF | [34] Cárdenas MID | [35] Pons FWD
        // Once Caldas: [36] G.Ortiz GK  | [37] Palomino DEF | [38] S.Gómez MID | [39] Moreno FWD

        // ── MatchResult ──
        context.MatchResults.Add(new MatchResult
        {
            MatchId = matchFinished.Id,
            HomeGoals = 2,
            AwayGoals = 1,
            Observations = "Partido intenso de la jornada 1"
        });

        await context.SaveChangesAsync();

        // ── Goals ──
        context.Goals.AddRange(new List<Goal>
        {
            new() { MatchId=matchFinished.Id, PlayerId=players[35].Id, Minute=23, Type=GoalType.Normal  }, // Pons (Bucaramanga)
            new() { MatchId=matchFinished.Id, PlayerId=players[39].Id, Minute=55, Type=GoalType.Normal  }, // Moreno (Once Caldas)
            new() { MatchId=matchFinished.Id, PlayerId=players[34].Id, Minute=78, Type=GoalType.Normal  }, // Cárdenas (Bucaramanga)
        });

        await context.SaveChangesAsync();

        // ── Cards ──
        context.Cards.AddRange(new List<Card>
        {
            new() { MatchId=matchFinished.Id, PlayerId=players[37].Id, Minute=40, Type=CardType.Yellow }, // Palomino 1ª amarilla
            new() { MatchId=matchFinished.Id, PlayerId=players[37].Id, Minute=67, Type=CardType.Yellow }, // Palomino 2ª amarilla
        });

        await context.SaveChangesAsync();


        // ═══ 10. ALINEACIONES (partido Finished — Bucaramanga vs Once Caldas) ═══
        // Bucaramanga (teams[8]): players[32..35]
        // Once Caldas  (teams[9]): players[36..39]

        context.MatchLineups.AddRange(new List<MatchLineup>
{
    // Bucaramanga — 4 titulares
    new() { MatchId=matchFinished.Id, PlayerId=players[32].Id, IsStarter=true,  Position="GK"  }, // Chaverra
    new() { MatchId=matchFinished.Id, PlayerId=players[33].Id, IsStarter=true,  Position="CB"  }, // Ortiz
    new() { MatchId=matchFinished.Id, PlayerId=players[34].Id, IsStarter=true,  Position="CDM" }, // Cárdenas
    new() { MatchId=matchFinished.Id, PlayerId=players[35].Id, IsStarter=true,  Position="ST"  }, // Pons

    // Once Caldas — 3 titulares + 1 suplente
    new() { MatchId=matchFinished.Id, PlayerId=players[36].Id, IsStarter=true,  Position="GK"  }, // G. Ortiz
    new() { MatchId=matchFinished.Id, PlayerId=players[37].Id, IsStarter=true,  Position="CB"  }, // Palomino
    new() { MatchId=matchFinished.Id, PlayerId=players[38].Id, IsStarter=true,  Position="CM"  }, // S. Gómez
    new() { MatchId=matchFinished.Id, PlayerId=players[39].Id, IsStarter=false, Position="ST"  }, // Moreno (suplente)
});

        await context.SaveChangesAsync();
    }
}