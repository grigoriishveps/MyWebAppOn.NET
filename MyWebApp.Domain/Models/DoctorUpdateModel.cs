using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class DoctorUpdateModel:BaseDoctor, IDoctorIdentity
    {
        public int Id { get; set; }
    }
}