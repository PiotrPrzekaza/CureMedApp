using CureMed.Models;
using System.Collections.Generic;

namespace CureMed
{
    public static class FakeDatabase
    {
        public static List<DoctorViewModel> Doctors { get; set; } = new List<DoctorViewModel>
        {
            new DoctorViewModel
            {
                Name = "Piotr G",
                Prescriptions = new List<PrescriptionViewModel>
                {
                    new PrescriptionViewModel
                    {
                        Name="ERecepta 001",
                        Medicines = new List<MedicineViewModel>
                        {
                            new MedicineViewModel
                            {
                                Name="Duomox"
                            },
                            new MedicineViewModel
                            {
                                Name="Latex"
                            }
                        }
                    },
                    new PrescriptionViewModel
                    {
                        Name="ERecepta 021",
                        Medicines = new List<MedicineViewModel>
                        {
                            new MedicineViewModel
                            {
                                Name="Pawulon"
                            },
                            new MedicineViewModel
                            {
                                Name="Lakcit"
                            }
                        }
                    },
                    new PrescriptionViewModel
                    {
                        Name="ERecepta 023",
                        Medicines = new List<MedicineViewModel>
                        {
                            new MedicineViewModel
                            {
                                Name="Aciprex"
                            },
                            new MedicineViewModel
                            {
                                Name="Tritico"
                            }
                        }
                    }
                }

            },
            new DoctorViewModel
            {
                Name = "Wiesław W",
                Prescriptions = new List<PrescriptionViewModel>
                {
                    new PrescriptionViewModel
                    {
                        Name="ERecepta 003",
                        Medicines = new List<MedicineViewModel>
                        {
                            new MedicineViewModel
                            {
                                Name="Witamina S"
                            },
                            new MedicineViewModel
                            {
                                Name="TGripex"
                            },
                            new MedicineViewModel
                            {
                                Name="Panadol"
                            }
                        }
                    },
                    new PrescriptionViewModel
                    {
                        Name="ERecepta 005",
                        Medicines = new List<MedicineViewModel>
                        {
                            new MedicineViewModel
                            {
                                Name="Permen"
                            },
                            new MedicineViewModel
                            {
                                Name="Centrum"
                            }
                        }
                    }
                }
            },
            new DoctorViewModel
            {
                Name = "Marian H",
                Prescriptions = new List<PrescriptionViewModel>
                {
                    new PrescriptionViewModel
                    {
                        Name="ERecepta 002",
                        Medicines = new List<MedicineViewModel>
                        {
                            new MedicineViewModel
                            {
                                Name="Nospa"
                            },
                        }
                    },
                    new PrescriptionViewModel
                    {
                        Name="ERecepta 012",
                        Medicines = new List<MedicineViewModel>
                        {
                            new MedicineViewModel
                            {
                                Name="Magnez"
                            },
                            new MedicineViewModel
                            {
                                Name="Areomag"
                            }
                        }
                    },
                    new PrescriptionViewModel
                    {
                        Name="ERecepta 013",
                        Medicines = new List<MedicineViewModel>
                        {
                            new MedicineViewModel
                            {
                                Name="Annalex"
                            },
                            new MedicineViewModel
                            {
                                Name="Buretax"
                            },
                            new MedicineViewModel
                            {
                                Name="Ryvanol"
                            }
                        }
                    }
                }
            },
        };
    }
}
