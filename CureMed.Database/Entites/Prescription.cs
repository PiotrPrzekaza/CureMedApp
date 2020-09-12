using System;
using System.Collections.Generic;
using System.Text;

namespace CureMed.Database.Entites
{
    public class Prescription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CraetedDate { get; set; }
    }
}
