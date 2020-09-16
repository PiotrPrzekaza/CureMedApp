using CureMed.Core.Iterfaces;
using CureMed.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CureMed.Core
{
   

    public class DoctorManager : IDoctorManager
    {
        private readonly IDoctorRepository _DoctorRepository;
        private readonly IPrescriptionRepository _PrescriptionRepository;
        private readonly IMedicineRepository _MedicineRepository;
        private readonly DtoMapper _DoctorsMapper;


        public DoctorManager(IDoctorRepository doctorRepository,
            IPrescriptionRepository prescriptionRepository,
            IMedicineRepository medicineRepository,
            DtoMapper doctorsMapper)
        {
            _DoctorRepository = doctorRepository;
            _PrescriptionRepository = prescriptionRepository;
            _MedicineRepository = medicineRepository;
            _DoctorsMapper = doctorsMapper;
        }

        public IEnumerable<DoctorDto> GetAllDoctors(string filterString)
        {
            var doctorEntities = _DoctorRepository.GetAllDoctors();

            if (!string.IsNullOrEmpty(filterString))
            {
                doctorEntities = doctorEntities
                    .Where(x => x.FirstName.Contains(filterString) || x.LastName.Contains(filterString));
            }

            return _DoctorsMapper.Map(doctorEntities);
        }

        public IEnumerable<PrescriptionDto> GetAllPrescriptionForADoctor(int doctorId, string filterString)
        {
            var prescriptionEntities = _PrescriptionRepository.GetAllPrescriptions().Where(x => x.DoctorId == doctorId);

            if (!string.IsNullOrEmpty(filterString))
            {
                prescriptionEntities = prescriptionEntities
                    .Where(x => x.Name.Contains(filterString));
            }

            return _DoctorsMapper.Map(prescriptionEntities);
        }

        public IEnumerable<MedicineDto> GetAllMedicineForAPrescription(int prescriptionId, string filterString)
        {
            var medicineEntities = _MedicineRepository.GetAllMedicines().Where(x => x.PrescriptionId == prescriptionId);

            if (!string.IsNullOrEmpty(filterString))
            {
                medicineEntities = medicineEntities
                    .Where(x => x.Name.Contains(filterString) ||
                                x.CompanyName.Contains(filterString) ||
                                x.ActiveSubstance.Contains(filterString));
            }

            return _DoctorsMapper.Map(medicineEntities);
        }

        public void AddNewMedicine(MedicineDto medicine, int prescriptionId)
        {
            var entity = _DoctorsMapper.Map(medicine);
            entity.PrescriptionId = prescriptionId;

            _MedicineRepository.AddNew(entity);
        }
        public void AddNewPrescription(PrescriptionDto prescription, int doctorId)
        {
            var entity = _DoctorsMapper.Map(prescription);
            entity.DoctorId = doctorId;

            _PrescriptionRepository.AddNew(entity);
        }

        public void AddNewDoctor(DoctorDto doctor)
        {
            var entity = _DoctorsMapper.Map(doctor);
            _DoctorRepository.AddNew(entity);
        }

        public bool DeleteMedicine(MedicineDto medicine)
        {
            var entity = _DoctorsMapper.Map(medicine);
            return _MedicineRepository.Delete(entity);
        }
        public bool DeletePrescription(PrescriptionDto prescription)
        {
            var entity = _DoctorsMapper.Map(prescription);
            return _PrescriptionRepository.Delete(entity);
        }

        public bool DeleteDoctor(DoctorDto doctor)
        {
            var entity = _DoctorsMapper.Map(doctor);
            return _DoctorRepository.Delete(entity);
        }
    }
}
