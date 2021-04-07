using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class PatientIdentityModel:IPatientIdentity
    {
        public int Id { get; }

        public PatientIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}