using Microsoft.EntityFrameworkCore;
using Shopping.DAL.Entities;

namespace Shopping.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vote>().HasIndex(v => v.VoterId).IsUnique(); 
                }

        #region Dbsets

        public DbSet<Voter> Voters { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<Candidate> Candidates { get; set; }


        #endregion
    }
}
