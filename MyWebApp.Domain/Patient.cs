using MyWebApp.Domain.Base;

namespace MyWebApp.Domain
{
    public class Patient:BasePatient
    {
        public Patient(int id) {
            Id = id;
        }

        public int Id { get; }
        
    }
}