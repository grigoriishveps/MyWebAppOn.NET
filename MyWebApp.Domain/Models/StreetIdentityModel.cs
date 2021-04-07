using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class StreetIdentityModel:IStreetIdentity
    {
        public int Id { get; }

        public StreetIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}