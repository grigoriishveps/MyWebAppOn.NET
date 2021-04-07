using MyWebApp.Client.DTO.Create;

namespace MyWebApp.Client.DTO.Update
{
    public class DoctorUpdateDTO:DoctorCreateDTO
    {
        public int Id { get; set; }
    }
}