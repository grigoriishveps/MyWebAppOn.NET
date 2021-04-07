using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class NoteUpdateModel:BaseNote, INoteIdentity
    {
        public int Id { get; set; }
    }
}