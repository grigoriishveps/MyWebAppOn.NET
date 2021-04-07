using MyWebApp.Domain.Base;

namespace MyWebApp.Domain
{
    public class Street:BaseStreet
    {
        public int Id { get; }
        public Street(int id) {
            Id = id;
        }

    }
}