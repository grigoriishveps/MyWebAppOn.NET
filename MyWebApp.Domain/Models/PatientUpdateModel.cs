using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class PatientUpdateModel: BasePatient, IPatientIdentity, IStreetContainer
    {
        public int Id { get; set; }
        public int? StreetId { get; set; }
    }
}