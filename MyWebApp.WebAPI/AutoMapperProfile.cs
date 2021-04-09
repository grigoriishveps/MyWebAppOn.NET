using AutoMapper;
using MyWebApp.Client.DTO;
using MyWebApp.Client.DTO.Create;
using MyWebApp.Client.DTO.Read;
using MyWebApp.Client.DTO.Update;
using MyWebApp.Domain.Models;

namespace MyWebApp.WebAPI
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DAL.Entity.Patient, Domain.Patient>();
            this.CreateMap<Domain.Patient, PatientDTO>();
            this.CreateMap<PatientCreateDTO, PatientUpdateModel>();
            this.CreateMap<PatientUpdateDTO, PatientUpdateModel>();
            this.CreateMap<PatientUpdateModel, DAL.Entity.Patient>();
            
            this.CreateMap<DAL.Entity.Street, Domain.Street>();
            this.CreateMap<Domain.Street, StreetDTO>();
            this.CreateMap<StreetCreateDTO, StreetUpdateModel>();
            this.CreateMap<StreetUpdateDTO, StreetUpdateModel>();
            this.CreateMap<StreetUpdateModel, DAL.Entity.Street>();
            
            this.CreateMap<DAL.Entity.Disease, Domain.Disease>();
            this.CreateMap<Domain.Disease, DiseaseDTO>();
            this.CreateMap<DiseaseCreateDTO, DiseaseUpdateModel>();
            this.CreateMap<DiseaseUpdateDTO, DiseaseUpdateModel>();
            this.CreateMap<DiseaseUpdateModel, DAL.Entity.Disease>();
            
            this.CreateMap<DAL.Entity.Doctor, Domain.Doctor>();
            this.CreateMap<Domain.Doctor, DoctorDTO>();
            this.CreateMap<DoctorCreateDTO, DoctorUpdateModel>();
            this.CreateMap<DoctorUpdateDTO, DoctorUpdateModel>();
            this.CreateMap<DoctorUpdateModel, DAL.Entity.Doctor>();
            
            this.CreateMap<DAL.Entity.Note, Domain.Note>();
            this.CreateMap<Domain.Note, NoteDTO>();
            this.CreateMap<NoteCreateDTO, NoteUpdateModel>();
            this.CreateMap<NoteUpdateDTO, NoteUpdateModel>();
            this.CreateMap<NoteUpdateModel, DAL.Entity.Note>();
        }
    }
}