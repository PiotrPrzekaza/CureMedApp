using CureMed.Database.Entites;
using System.Collections;
using System.Collections.Generic;

namespace CureMed.Database
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        IEnumerable<Prescription> GetAllPrescriptions();
    }
}
