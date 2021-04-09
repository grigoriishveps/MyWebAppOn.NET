using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApp.DAL.Entity
{
    public class Doctor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Initials { get; set; }

        public string Room { get; set; }
        
        public List<Doctor> Users { get; set; } = new List<Doctor>();
    }
}