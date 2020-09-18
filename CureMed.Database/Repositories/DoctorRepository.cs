using CureMed.Database.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CureMed.Database
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        protected override DbSet<Doctor> DbSet => _DbContext.Doctors;

        public DoctorRepository(CureMedAppDbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Doctor> GetAllDoctors()
        {
            return DbSet.Select(x => x);
        }

        
    }
}
