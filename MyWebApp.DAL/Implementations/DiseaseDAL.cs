using MyWebApp.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using Disease = MyWebApp.DAL.Entity.Disease;

namespace MyWebApp.DAL.Implementations
{
    public class DiseaseDAL:IDiseaseDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public DiseaseDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<MyWebApp.Domain.Disease> InsertAsync(DiseaseUpdateModel employee)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Disease>(employee));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Disease>(result.Entity);
        }

        public async Task<IEnumerable<MyWebApp.Domain.Disease>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<MyWebApp.Domain.Disease>>(
                await this.Context.Disease.ToListAsync());
        }

        public async Task<MyWebApp.Domain.Disease> GetAsync(IDiseaseIdentity employee)
        {
            var result = await this.Get(employee);

            return this.Mapper.Map<MyWebApp.Domain.Disease>(result);
        }

        private async Task<Disease> Get(IDiseaseIdentity employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            
            return await this.Context.Disease.FirstOrDefaultAsync(x => x.Id == employee.Id);
        }

        public async Task<MyWebApp.Domain.Disease> UpdateAsync(DiseaseUpdateModel employee)
        {
            var existing = await this.Get(employee);

            var result = this.Mapper.Map(employee, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Disease>(result);
        }
    }
}