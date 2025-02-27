﻿using System;

namespace CureMed.Models
{
    public class MedicineViewModel
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
        public PrescriptionViewModel Prescription { get; set; }
    }
}
