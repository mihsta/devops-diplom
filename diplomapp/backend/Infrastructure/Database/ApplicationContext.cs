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
            optionsBuilder.UseSqlServer("Server=tcp:diplomapp.database.windows.net,1433;Initial Catalog=diplomapp-db;Persist Security Info=False;User ID=asisorg;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
