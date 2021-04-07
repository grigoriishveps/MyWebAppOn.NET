using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.BLL.Contracts;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.BLL.Implementation
{
    public class NoteService:INoteService
    {
        private INoteDAL NoteDAL { get; }
        
        public NoteService(INoteDAL employeeDataAccess)
        {
            this.NoteDAL = employeeDataAccess;
        }
        
        public async Task<Note> CreateAsync(NoteUpdateModel note) {
            return await this.NoteDAL.InsertAsync(note);
        }
        
        public async Task<Note> UpdateAsync(NoteUpdateModel note) {
            return await this.NoteDAL.UpdateAsync(note);
        }
        
        public Task<IEnumerable<Note>> GetAsync() {
            return this.NoteDAL.GetAsync();
        }
        
        public Task<Note> GetAsync(INoteIdentity id)
        {
            return this.NoteDAL.GetAsync(id);
        }
    }
}