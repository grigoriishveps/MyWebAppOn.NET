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

        public async Task<MyWebApp.Domain.Street> InsertAsync(StreetUpdateModel street)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Street>(street));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Street>(result.Entity);
        }

        public async Task<IEnumerable<MyWebApp.Domain.Street>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<MyWebApp.Domain.Street>>(
                await this.Context.Street.ToListAsync());
        }

        public async Task<MyWebApp.Domain.Street> GetAsync(IStreetIdentity street)
        {
            var result = await this.Get(street);

            return this.Mapper.Map<MyWebApp.Domain.Street>(result);
        }

        private async Task<Street> Get(IStreetIdentity street)
        {
            if (street == null)
            {
                throw new ArgumentNullException(nameof(street));
            }
            
            return await this.Context.Street.FirstOrDefaultAsync(x => x.Id == street.Id);
        }

        public async Task<MyWebApp.Domain.Street> UpdateAsync(StreetUpdateModel street)
        {
            var existing = await this.Get(street);

            var result = this.Mapper.Map(street, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Street>(result);
        }
    }
}