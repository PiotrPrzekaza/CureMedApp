using CureMed.Database.Entites;
using Microsoft.EntityFrameworkCore;

namespace CureMed.Database
{
    public class MedicineRepository : BaseRepository<Medicine>, IMedicineRepository
    {
        protected override DbSet<Medicine> DbSet => _DbContext.Medicines;

        public MedicineRepository(CureMedAppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
