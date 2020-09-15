using CureMed.Database.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CureMed.Database
{
    public class PrescriptionRepository : BaseRepository<Prescription>, IPrescriptionRepository
    {
        protected override DbSet<Prescription> DbSet => _DbContext.Prescriptions;

        public PrescriptionRepository(CureMedAppDbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            return DbSet.Include(x => x.Medicines).Select(x => x);
        }
    }
}
