using AutoMapper;
using CureMed.Database.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CureMed.Core
{
    public class DtoMapper
    {
        private readonly IMapper _Mapper;

        public DtoMapper()
        {
            _Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Medicine, MedicineDto>()
                .ForMember(x => x.TotalPrice, option => option.MapFrom(y => y.Amount * y.Price))
                .ReverseMap();
                config.CreateMap<Prescription, PrescriptionDto>()
               .ReverseMap();
                config.CreateMap<Doctor, DoctorDto>()
               .ReverseMap();

            }).CreateMapper();
        }

        #region Medicine Maps

        public MedicineDto Map(Medicine medicine) => _Mapper.Map<MedicineDto>(medicine);
        public List<MedicineDto> Map(List<Medicine> medicines) => _Mapper.Map<List<MedicineDto>>(medicines);

        public Medicine Map(MedicineDto medicine) => _Mapper.Map<Medicine>(medicine);
        public List<Medicine> Map(List<MedicineDto> medicines) => _Mapper.Map<List<Medicine>>(medicines);

        #endregion

        #region Prescription Maps

        public PrescriptionDto Map(Prescription prescription) => _Mapper.Map<PrescriptionDto>(prescription);
        public List<PrescriptionDto> Map(List<Prescription> prescriptions) => _Mapper.Map<List<PrescriptionDto>>(prescriptions);

        public Prescription Map(PrescriptionDto prescription) => _Mapper.Map<Prescription>(prescription);
        public List<Prescription> Map(List<PrescriptionDto> prescriptions) => _Mapper.Map<List<Prescription>>(prescriptions);

        #endregion

        #region Doctor Maps

        public DoctorDto Map(Doctor doctor) => _Mapper.Map<DoctorDto>(doctor);
        public List<DoctorDto> Map(List<Doctor> doctors) => _Mapper.Map<List<DoctorDto>>(doctors);

        public Doctor Map(DoctorDto doctor) => _Mapper.Map<Doctor>(doctor);
        public List<Doctor> Map(List<DoctorDto> doctors) => _Mapper.Map<List<Doctor>>(doctors);

        #endregion
    }
}
