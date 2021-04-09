using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain
{
    public class Note:BaseNote, IPatientContainer,IDoctorContainer
    {
        public int Id { get; set; }
        public int? PatientId { get;}
        public int? DoctorId { get; }
    }
}