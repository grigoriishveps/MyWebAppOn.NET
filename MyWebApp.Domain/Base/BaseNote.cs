using System;

namespace MyWebApp.Domain.Base
{
    public class BaseNote
    {
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        
        public int? DiseaseId { get; set; }
    
    }
}