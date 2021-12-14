using backend.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<MusicTrackDto> MusicTracks { get; set; }
        public ApplicationContext()
        {
            //    Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
    }
}
