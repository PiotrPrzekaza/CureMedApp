using CureMed.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CureMed.Controllers
{
    public class PrescriptionController : Controller
    {
        private int IndexOfDoctor { get; set; } 

       
        public PrescriptionController()
        {

        }
        public IActionResult Index(int indexOfDoctor, string contentSearch)
        {
            IndexOfDoctor = indexOfDoctor;

            if (string.IsNullOrEmpty(contentSearch))
            {
                return View(FakeDatabase.Doctors.ElementAt(indexOfDoctor));
            }

            return View(new DoctorViewModel
            {
                Name = FakeDatabase.Doctors.ElementAt(indexOfDoctor).Name,
                Prescriptions = FakeDatabase.Doctors.ElementAt(indexOfDoctor).Prescriptions.Where(x=>x.Name.Contains(contentSearch)).ToList()
            });
            
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PrescriptionViewModel prescriptionVM)
        {
            FakeDatabase.Doctors.ElementAt(IndexOfDoctor).Prescriptions.Add(prescriptionVM);

            return RedirectToAction("Index");
        }

        public IActionResult View(int indexOfPrescription)
        {
            return RedirectToAction("Index", "Medicine", new { indexOfDoctor = IndexOfDoctor, indexOfPrescription = indexOfPrescription }) ;
        }
        public IActionResult Delete(int indexOfPrescription)
        {
            return View();
        }
    }
}
