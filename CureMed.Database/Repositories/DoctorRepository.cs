using CureMed.Database.Entites;
using Microsoft.EntityFrameworkCore;

namespace CureMed.Database
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        protected override DbSet<Doctor> DbSet => _DbContext.Doctors;

        public DoctorRepository(CureMedAppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
