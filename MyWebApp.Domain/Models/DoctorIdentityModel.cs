using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class DoctorIdentityModel:IDoctorIdentity
    {
        public int Id { get; }

        public DoctorIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}