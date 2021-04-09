using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain
{
    public class Patient:BasePatient,IStreetContainer
    {
        
        public int Id { get; set; }
        public int? StreetId { get; set; }
    }
}