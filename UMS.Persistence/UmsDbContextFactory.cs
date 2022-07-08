using Microsoft.EntityFrameworkCore;
using PCP.Persistence.Infrastructure;
using UMS.Domain.Models;

namespace PCP.Persistence
{
    public class UmsDbContextFactory 
        : DesignTimeDbContextFactoryBase<UmsContext>
    {
        protected override UmsContext CreateNewInstance(DbContextOptions<UmsContext> options)
        {
            return new UmsContext(options);
        }
    }
}
