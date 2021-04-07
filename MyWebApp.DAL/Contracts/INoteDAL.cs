using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.DAL.Contracts
{
    public interface INoteDAL
    {
        Task<Note> InsertAsync(NoteUpdateModel employee);
        Task<IEnumerable<Note>> GetAsync();
        Task<Note> GetAsync(INoteIdentity employeeId);
        Task<Note> UpdateAsync(NoteUpdateModel employee);
    }
}