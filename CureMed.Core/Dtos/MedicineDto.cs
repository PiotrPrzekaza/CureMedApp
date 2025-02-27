﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CureMed.Core
{
    public class MedicineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string ActiveSubstance { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime ExpirationDate { get; set; }
        public PrescriptionDto Prescription { get; set; }
    }
}
