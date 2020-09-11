using CureMed.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CureMed.Controllers
{
    public class HomeController : Controller
    {
      
        public HomeController()
        {

        }
        public IActionResult Index(string contentSearch)
        {
            if (string.IsNullOrEmpty(contentSearch))
            {
                return View(FakeDatabase.Doctors);
            }

            return View(FakeDatabase.Doctors.Where(x => x.Name.Contains(contentSearch)).ToList());
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DoctorViewModel doctorVM)
        {
            FakeDatabase.Doctors.Add(doctorVM);

            return RedirectToAction("Index");
        }
        public IActionResult View(int indexOfDoctor)
        {
            return RedirectToAction("Index", "Prescription", new {indexOfDoctor = indexOfDoctor });
        }
        public IActionResult Delete(int indexOfDoctor)
        {
            return View(FakeDatabase.Doctors);
        }
    }
}
