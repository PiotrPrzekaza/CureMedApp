using System;
using System.Collections.Generic;
using System.Text;

namespace CureMed.Core
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CraetedDate { get; set; }
        public DoctorDto Doctor { get; set; }
        public List<MedicineDto> Medicines { get; set; }
    }
}
