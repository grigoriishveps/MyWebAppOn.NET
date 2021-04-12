using MyWebApp.Domain;

namespace MyWebApp.Client.DTO.Create
{
    public class NoteCreateDTO
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int DiseaseId { get; set; }
    }
}