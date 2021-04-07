using MyWebApp.Domain.Base;

namespace MyWebApp.Domain
{
    public class Disease:BaseDisease
    {
        public int Id { get; }
        public Disease(int id) {
            Id = id;
        }
    }
}