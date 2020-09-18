using CureMed.Core;
using CureMed.Core.Iterfaces;
using CureMed.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CureMed.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IDoctorManager _DoctorManager;
        private readonly ViewModelMapper _ViewModelMapper;
        private int DoctorId { get; set; }
      

        public MedicineController(IDoctorManager doctorManager, ViewModelMapper viewModelMapper)
        {
            _DoctorManager = doctorManager;
            _ViewModelMapper = viewModelMapper;
        }
        public IActionResult Index(int doctorId, int prescriptionId, string filterString)
        {

            TempData["PrescriptionId"] = prescriptionId;
            TempData["DoctorId"] = doctorId;
            var prescriptionDto = _DoctorManager.GetAllPrescriptionForADoctor(doctorId, null).FirstOrDefault(x => x.Id == prescriptionId);
            var medicineDtos = _DoctorManager.GetAllMedicineForAPrescription(prescriptionId, filterString);
            
            var prescriptionViewModel = _ViewModelMapper.Map(prescriptionDto);

            prescriptionViewModel.Medicines = _ViewModelMapper.Map(medicineDtos).ToList();

            return View(prescriptionViewModel) ;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MedicineViewModel medicineVM)
        {
            var dto = _ViewModelMapper.Map(medicineVM);

            _DoctorManager.AddNewMedicine(dto, int.Parse(TempData["PrescriptionId"].ToString()));

            return RedirectToAction("Index", new {doctorId = int.Parse(TempData["DoctorId"].ToString()) ,prescriptionId = int.Parse(TempData["PrescriptionId"].ToString()) });
        }

        public IActionResult Delete(int medicineId)
        {
            _DoctorManager.DeleteMedicine(new MedicineDto { Id = medicineId });
            return RedirectToAction("Index", new { doctorId = int.Parse(TempData["DoctorId"].ToString()), prescriptionId = int.Parse(TempData["PrescriptionId"].ToString()) });
        }
    }
}
