namespace MyWebApp.Client.DTO.Read
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string PassportNumber{ get; set; }
        
        public int StreetId { get; set; }
    }
}