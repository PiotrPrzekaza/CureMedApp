using AutoMapper;
using CureMed.Database.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CureMed.Core
{
    public class DtoMapper
    {
        private IMapper _Mapper;

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
        public IEnumerable<MedicineDto> Map(IEnumerable<Medicine> medicines) => _Mapper.Map<IEnumerable<MedicineDto>>(medicines);

        public Medicine Map(MedicineDto medicine) => _Mapper.Map<Medicine>(medicine);
        public IEnumerable<Medicine> Map(IEnumerable<MedicineDto> medicines) => _Mapper.Map<IEnumerable<Medicine>>(medicines);

        #endregion

        #region Prescription Maps

        public PrescriptionDto Map(Prescription prescription) => _Mapper.Map<PrescriptionDto>(prescription);
        public IEnumerable<PrescriptionDto> Map(IEnumerable<Prescription> prescriptions) => _Mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);

        public Prescription Map(PrescriptionDto prescription) => _Mapper.Map<Prescription>(prescription);
        public IEnumerable<Prescription> Map(IEnumerable<PrescriptionDto> prescriptions) => _Mapper.Map<IEnumerable<Prescription>>(prescriptions);

        #endregion

        #region Doctor Maps

        public DoctorDto Map(Doctor doctor) => _Mapper.Map<DoctorDto>(doctor);
        public IEnumerable<DoctorDto> Map(IEnumerable<Doctor> doctors) => _Mapper.Map<IEnumerable<DoctorDto>>(doctors);

        public Doctor Map(DoctorDto doctor) => _Mapper.Map<Doctor>(doctor);
        public IEnumerable<Doctor> Map(IEnumerable<DoctorDto> doctors) => _Mapper.Map<IEnumerable<Doctor>>(doctors);

        #endregion
    }
}
