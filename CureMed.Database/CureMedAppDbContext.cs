using CureMed.Database.Entites;
using Microsoft.EntityFrameworkCore;

namespace CureMed.Database
{
    public class CureMedAppDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public CureMedAppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
