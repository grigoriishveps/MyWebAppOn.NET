using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class PatientUpdateModel: BasePatient, IPatientIdentity
    {
        public int Id { get; set; }
    }
}