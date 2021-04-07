using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class DiseaseIdentityModel:IDiseaseIdentity
    {
        public int Id { get; }

        public DiseaseIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}