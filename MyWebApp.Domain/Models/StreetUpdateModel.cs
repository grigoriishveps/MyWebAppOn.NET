using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class StreetUpdateModel:BaseStreet, IStreetIdentity
    {
        public int Id { get; set; }
    }
}