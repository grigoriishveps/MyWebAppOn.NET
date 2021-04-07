using MyWebApp.Client.DTO.Create;

namespace MyWebApp.Client.DTO.Update
{
    public class PatientUpdateDTO: PatientCreateDTO
    {
        public int Id { get; set; }
    }
}