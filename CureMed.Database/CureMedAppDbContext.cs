using Microsoft.EntityFrameworkCore;

namespace CureMed.Database
{
    public class CureMedAppDbContext : DbContext
    {
        public CureMedAppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
