using MyWebApp.Domain.Base;

namespace MyWebApp.Domain
{
    public class Doctor:BaseDoctor
    {
        public int Id { get; }
        public Doctor(int id) {
            Id = id;
        }
    }
}