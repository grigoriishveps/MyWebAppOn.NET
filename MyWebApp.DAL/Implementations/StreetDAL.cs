using MyWebApp.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using Street = MyWebApp.DAL.Entity.Street;

namespace MyWebApp.DAL.Implementations
{
    public class StreetDAL:IStreetDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public StreetDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<MyWebApp.Domain.Street> InsertAsync(StreetUpdateModel employee)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Street>(employee));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Street>(result.Entity);
        }

        public async Task<IEnumerable<MyWebApp.Domain.Street>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<MyWebApp.Domain.Street>>(
                await this.Context.Street.ToListAsync());
        }

        public async Task<MyWebApp.Domain.Street> GetAsync(IStreetIdentity employee)
        {
            var result = await this.Get(employee);

            return this.Mapper.Map<MyWebApp.Domain.Street>(result);
        }

        private async Task<Street> Get(IStreetIdentity employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            
            return await this.Context.Street.FirstOrDefaultAsync(x => x.Id == employee.Id);
        }

        public async Task<MyWebApp.Domain.Street> UpdateAsync(StreetUpdateModel employee)
        {
            var existing = await this.Get(employee);

            var result = this.Mapper.Map(employee, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Street>(result);
        }
    }
}