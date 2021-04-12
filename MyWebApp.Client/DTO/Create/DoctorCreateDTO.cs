using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Client.DTO.Create
{
    public class DoctorCreateDTO
    {
        [Required(ErrorMessage = "Initials is required")]
        public string Initials { get; set; }
        public string Room { get; set; }
    }
}