using AfterSchoolClub.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace AfterSchoolClub.Api.Interfaces
{
    public interface IAfterSchoolClubDbContext
    {
        DbSet<Child> Children { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
