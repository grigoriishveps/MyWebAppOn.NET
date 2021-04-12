using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Client.DTO.Create
{
    public class DiseaseCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Description { get; set;}
        public string Treatment { get; set;}
        public string Annotation { get; set;}
    }
}