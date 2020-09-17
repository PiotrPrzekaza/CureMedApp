using CureMed.Core;
using CureMed.Core.Iterfaces;
using CureMed.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CureMed.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDoctorManager _DoctorManager;
        private readonly ViewModelMapper _ViewModelMapper;


        public HomeController(IDoctorManager doctorManager, ViewModelMapper viewModelMapper)
        {
            _DoctorManager = doctorManager;
            _ViewModelMapper = viewModelMapper;
        }
        public IActionResult Index(string filterString)
        {
          
            var doctorDtos = _DoctorManager.GetAllDoctors(filterString);
            var doctorViewModel = _ViewModelMapper.Map(doctorDtos);
            return View(doctorViewModel);
        }
        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DoctorViewModel doctorVM)
        {
            var dto = _ViewModelMapper.Map(doctorVM);

            _DoctorManager.AddNewDoctor(dto);

            return RedirectToAction("Index");
        }
        public IActionResult View(int doctorId)
        {
            return RedirectToAction("Index", "Prescription", new {doctorId = doctorId });
        }
        public IActionResult Delete(int doctorId)
        {
            _DoctorManager.DeleteDoctor(new DoctorDto{ Id=doctorId});
            var doctorDtos = _DoctorManager.GetAllDoctors(null);
            var doctorViewModel = _ViewModelMapper.Map(doctorDtos);
            return View(doctorViewModel);
        }
    }
}
