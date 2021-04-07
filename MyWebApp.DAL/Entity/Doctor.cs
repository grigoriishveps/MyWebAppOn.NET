using System.Collections.Generic;

namespace MyWebApp.DAL.Entity
{
    public class Doctor
    {
        public int Id { get; set; }
        
        public string Initials { get; set; }

        public string Room { get; set; }
        
        public List<Doctor> Users { get; set; } = new List<Doctor>();
    }
}