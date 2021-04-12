using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class NoteUpdateModel:BaseNote, INoteIdentity, IPatientContainer,IDoctorContainer, IDiseaseContainer
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        
        public int? DiseaseId { get; set; }
    }
}