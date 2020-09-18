using System;
using System.Collections.Generic;

namespace CureMed.Models
{
    public class PrescriptionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CraetedDate { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public List<MedicineViewModel> Medicines { get; set; }
    }
}
