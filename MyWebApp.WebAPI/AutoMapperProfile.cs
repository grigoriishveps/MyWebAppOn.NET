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
            //this.CreateMap<DAL.Entity.Patient, Domain.Patient>();
            this.CreateMap<Domain.Patient, PatientDTO>();
            //this.CreateMap<Domain.Patient, PatientDTO>();
            this.CreateMap<PatientCreateDTO, PatientUpdateModel>();
            this.CreateMap<PatientUpdateDTO, PatientUpdateModel>();
            this.CreateMap<PatientUpdateModel, DAL.Entity.Patient>();
        }
    }
}