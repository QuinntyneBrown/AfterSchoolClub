using AfterSchoolClub.Api.Models;
using AfterSchoolClub.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AfterSchoolClub.Api.Data
{
    public class AfterSchoolClubDbContext: DbContext, IAfterSchoolClubDbContext
    {
        public DbSet<Child> Children { get; private set; }
        public DbSet<Parent> Parents { get; private set; }
        public DbSet<Event> Events { get; private set; }
        public DbSet<Location> Locations { get; private set; }
        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public AfterSchoolClubDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AfterSchoolClubDbContext).Assembly);
        }
        
    }
}
