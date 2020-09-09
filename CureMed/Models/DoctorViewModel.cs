﻿using System.Collections.Generic;

namespace CureMed.Models
{
    public class DoctorViewModel
    {
        public string Name { get; set; }
        public List<PrescriptionViewModel> Prescriptions { get; set; }
    }
}
