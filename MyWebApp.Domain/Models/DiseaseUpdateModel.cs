using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class DiseaseUpdateModel: BaseDisease, IDiseaseIdentity
    {
        public int Id { get; set; }
    }
}