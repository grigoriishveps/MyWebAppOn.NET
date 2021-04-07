using System;

namespace MyWebApp.Domain.Base
{
    public class BaseNote
    {
        public Doctor DoctorId { get; set; }
        public Patient PatientId { get; set; }
        public DateTime DateVisit { get; set; }
    }
}