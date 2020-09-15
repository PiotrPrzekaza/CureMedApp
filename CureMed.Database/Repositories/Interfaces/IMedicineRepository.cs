using CureMed.Database.Entites;
using System.Collections;
using System.Collections.Generic;

namespace CureMed.Database
{
    public interface IMedicineRepository : IRepository<Medicine>
    {
        IEnumerable<Medicine> GetAllMedicines();
    }
}
