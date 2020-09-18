using CureMed.Core;
using CureMed.Core.Iterfaces;
using CureMed.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CureMed.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IDoctorManager _DoctorManager;
        private readonly ViewModelMapper _ViewModelMapper;
      


        public PrescriptionController(IDoctorManager doctorManager, ViewModelMapper viewModelMapper)
        {
            _DoctorManager = doctorManager;
            _ViewModelMapper = viewModelMapper;
        }
        public IActionResult Index(int doctorId, string filterString)
        {
            TempData["DoctorId"]  = doctorId;

            var doctorDto = _DoctorManager.GetAllDoctors(null).FirstOrDefault(x => x.Id == doctorId);
            var prescriptionDtos = _DoctorManager.GetAllPrescriptionForADoctor(doctorId, filterString);

            var doctorViewModel = _ViewModelMapper.Map(doctorDto);

           doctorViewModel.Prescriptions = _ViewModelMapper.Map(prescriptionDtos).ToList();

            return View(doctorViewModel);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PrescriptionViewModel prescriptionVM)
        {
            var dto = _ViewModelMapper.Map(prescriptionVM);

            _DoctorManager.AddNewPrescription(dto, int.Parse(TempData["DoctorId"].ToString()));

            return RedirectToAction("Index", new { doctorId = int.Parse(TempData["DoctorId"].ToString()) });
        }

        public IActionResult View(int prescriptionId)
        {
            return RedirectToAction("Index", "Medicine", new { doctorId = int.Parse(TempData["DoctorId"].ToString()), prescriptionId = prescriptionId })  ;
        }
        public IActionResult Delete(int prescriptionId)
        {
            _DoctorManager.DeletePrescription(new PrescriptionDto {Id = prescriptionId });
            return RedirectToAction("Index", new { doctorId = int.Parse(TempData["DoctorId"].ToString()) });
        }
    }
}
