using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Client.DTO.Create
{
    public class StreetCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Annotation { get; set;}
    }
}