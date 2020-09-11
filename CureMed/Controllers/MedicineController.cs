using CureMed.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CureMed.Controllers
{
    public class MedicineController : Controller
    {
        private int IndexOfDoctor { get; set; }
        private int IndexOfPrescription { get; set; }

        public MedicineController()
        {

        }
        public IActionResult Index(int indexOfDoctor, int indexOfPrescription, string contentSearch)
        {
            IndexOfDoctor = indexOfDoctor;
            IndexOfPrescription = indexOfPrescription;

            if (string.IsNullOrEmpty(contentSearch))
            {
                return View(FakeDatabase.Doctors.ElementAt(indexOfDoctor).Prescriptions.ElementAt(indexOfPrescription));
            }
            return View(new PrescriptionViewModel
            {
                Name = FakeDatabase.Doctors.ElementAt(indexOfDoctor).Prescriptions.ElementAt(indexOfPrescription).Name,
                Medicines = FakeDatabase.Doctors.ElementAt(indexOfDoctor).Prescriptions.ElementAt(indexOfPrescription).Medicines.Where(x => x.Name.Contains(contentSearch)).ToList()
            }) ;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MedicineViewModel medicineVM)
        {
            FakeDatabase.Doctors.ElementAt(IndexOfDoctor).Prescriptions.ElementAt(IndexOfPrescription).Medicines.Add(medicineVM);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int indexOfMedicine)
        {
            return View();
        }
    }
}
