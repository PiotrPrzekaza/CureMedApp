using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CureMed.Database.Entites
{
    public class Prescription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CraetedDate { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [NotMapped]
        public virtual List<Medicine> Medicines { get; set; }
    }
}
