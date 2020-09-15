using CureMed.Database.Entites;
using System.Collections.Generic;

namespace CureMed.Database
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<Doctor> GetAllDoctors();
    }
}
