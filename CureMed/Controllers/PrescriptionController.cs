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
        private int DoctorId { get; set; }


        public PrescriptionController(IDoctorManager doctorManager, ViewModelMapper viewModelMapper)
        {
            _DoctorManager = doctorManager;
            _ViewModelMapper = viewModelMapper;
        }
        public IActionResult Index(int doctorId, string filterString)
        {
            DoctorId = doctorId;

            var doctorDto = _DoctorManager.GetAllDoctors(null).FirstOrDefault(x => x.Id == doctorId);
            var prescriptionDtos = _DoctorManager.GetAllPrescriptionForADoctor(doctorId, filterString);

            var doctorViewModel = _ViewModelMapper.Map(doctorDto);

           doctorViewModel.Prescriptions = _ViewModelMapper.Map(prescriptionDtos);

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

            _DoctorManager.AddNewPrescription(dto, DoctorId);

            return RedirectToAction("Index");
        }

        public IActionResult View(int prescriptionId)
        {
            return RedirectToAction("Index", "Medicine", new { doctorId = DoctorId, prescriptionId = prescriptionId }) ;
        }
        public IActionResult Delete(int prescriptionId)
        {
            _DoctorManager.DeletePrescription(new PrescriptionDto { Id = prescriptionId });
            return View();
        }
    }
}
