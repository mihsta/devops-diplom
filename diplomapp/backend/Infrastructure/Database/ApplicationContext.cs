using backend.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

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
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("diplomappdb"));
        }
    }
}
