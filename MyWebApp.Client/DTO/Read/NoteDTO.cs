using System;
using MyWebApp.Domain;

namespace MyWebApp.Client.DTO.Read
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public Doctor DoctorId { get; set; }
        public Patient PatientId { get; set; }
        public DateTime DateVisit { get; set; }
    }
}