using backend.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Collections;

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
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
        }
    }
}
