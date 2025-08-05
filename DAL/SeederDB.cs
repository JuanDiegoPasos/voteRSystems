using Shopping.DAL.Entities;

namespace Shopping.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await PopulateCandidatesAsync();
            await PopulateVotersAsync();

            await _context.SaveChangesAsync();
        }

        private async Task PopulateCandidatesAsync()
        {
            if (!_context.Candidates.Any())
            {
                _context.Candidates.AddRange(
                    new Candidate
                    {
                        Name = "Ana Torres",
                        Party = "Partido Verde",

                    },
                    new Candidate
                    {
                        Name = "Luis Martínez",
                        Party = "Partido Azul",
                    },
                    new Candidate
                    {
                        Name = "Carlos Rodríguez",
                        Party = "Independiente",
                    }
                );
            }
        }

        private async Task PopulateVotersAsync()
        {
            if (!_context.Voters.Any())
            {
                _context.Voters.AddRange(
                    new Voter
                    {
                        Name = "María López",
                        Email = "maria@example.com",
                    },
                    new Voter
                    {
                        Name = "Juan Pérez",
                        Email = "juan@example.com",
                    }
                );
            }
        }
    }
}