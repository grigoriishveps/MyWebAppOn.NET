using MyWebApp.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using Note = MyWebApp.DAL.Entity.Note;

namespace MyWebApp.DAL.Implementations
{
    public class NoteDAL:INoteDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public NoteDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<MyWebApp.Domain.Note> InsertAsync(NoteUpdateModel employee)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Note>(employee));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Note>(result.Entity);
        }

        public async Task<IEnumerable<MyWebApp.Domain.Note>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<MyWebApp.Domain.Note>>(
                await this.Context.Note.ToListAsync());
        }

        public async Task<MyWebApp.Domain.Note> GetAsync(INoteIdentity employee)
        {
            var result = await this.Get(employee);

            return this.Mapper.Map<MyWebApp.Domain.Note>(result);
        }

        private async Task<Note> Get(INoteIdentity employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            
            return await this.Context.Note.FirstOrDefaultAsync(x => x.Id == employee.Id);
        }

        public async Task<MyWebApp.Domain.Note> UpdateAsync(NoteUpdateModel employee)
        {
            var existing = await this.Get(employee);

            var result = this.Mapper.Map(employee, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Note>(result);
        }
    }
}