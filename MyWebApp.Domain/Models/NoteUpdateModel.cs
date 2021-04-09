using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class NoteUpdateModel:BaseNote, INoteIdentity, IPatientContainer,IDoctorContainer
    {
        public int Id { get; set; }
        public int? PatientId { get;}
        public int? DoctorId { get; }
    }
}