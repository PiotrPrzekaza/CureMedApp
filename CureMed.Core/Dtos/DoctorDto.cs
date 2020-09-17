using System;
using System.Collections.Generic;
using System.Text;

namespace CureMed.Core
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public int WorkYears { get; set; }
        public bool IsAbleToMakePrescriptions { get; set; }
        public IEnumerable<PrescriptionDto> Prescriptions { get; set; }
    }
}
