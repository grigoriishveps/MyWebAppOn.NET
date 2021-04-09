using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApp.DAL.Entity
{
    public class Patient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string PassportNumber{ get; set; }
        public int? StreetId { get; set; }
        public Street Street { get; set; }
        
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}