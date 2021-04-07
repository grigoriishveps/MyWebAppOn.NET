using MyWebApp.Client.DTO.Create;

namespace MyWebApp.Client.DTO.Update
{
    public class DiseaseUpdateDTO: DiseaseCreateDTO
    {
        public int Id { get; set; }
    }
}