using AfterSchoolClub.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace AfterSchoolClub.Api.Interfaces
{
    public interface IAfterSchoolClubDbContext
    {
        DbSet<Child> Children { get; }
        DbSet<Parent> Parents { get; }
        DbSet<Event> Events { get; }
        DbSet<Location> Locations { get; }
        DbSet<DigitalAsset> DigitalAssets { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
