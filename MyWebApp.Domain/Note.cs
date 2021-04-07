using MyWebApp.Domain.Base;

namespace MyWebApp.Domain
{
    public class Note:BaseNote
    {
        public int Id { get; }
        public Note(int id) {
            Id = id;
        }
    }
}