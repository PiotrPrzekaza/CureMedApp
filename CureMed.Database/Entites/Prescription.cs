using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CureMed.Database.Entites
{
    public class Prescription : BaseEntity
    {
       
        public string Name { get; set; }
        public DateTime CraetedDate { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [NotMapped]
        public virtual IEnumerable<Medicine> Medicines { get; set; }
    }
}
