using CureMed.Database.Entites;
using Microsoft.EntityFrameworkCore;

namespace CureMed.Database
{
    public class PrescriptionRepository : BaseRepository<Prescription>, IPrescriptionRepository
    {
        protected override DbSet<Prescription> DbSet => _DbContext.Prescriptions;

        public PrescriptionRepository(CureMedAppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
