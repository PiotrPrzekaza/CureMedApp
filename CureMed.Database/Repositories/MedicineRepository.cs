using CureMed.Database.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CureMed.Database
{
    public class MedicineRepository : BaseRepository<Medicine>, IMedicineRepository
    {
        protected override DbSet<Medicine> DbSet => _DbContext.Medicines;

        public MedicineRepository(CureMedAppDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Medicine> GetAllMedicines()
        {
            return DbSet.Select(x => x);
        }
    }
}
