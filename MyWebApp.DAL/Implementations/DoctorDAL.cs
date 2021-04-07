using MyWebApp.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using Doctor = MyWebApp.DAL.Entity.Doctor;


namespace MyWebApp.DAL.Implementations
{
    public class DoctorDAL:IDoctorDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public DoctorDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<MyWebApp.Domain.Doctor> InsertAsync(DoctorUpdateModel employee)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Doctor>(employee));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Doctor>(result.Entity);
        }

        public async Task<IEnumerable<MyWebApp.Domain.Doctor>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<MyWebApp.Domain.Doctor>>(
                await this.Context.Doctor.ToListAsync());
        }

        public async Task<MyWebApp.Domain.Doctor> GetAsync(IDoctorIdentity employee)
        {
            var result = await this.Get(employee);

            return this.Mapper.Map<MyWebApp.Domain.Doctor>(result);
        }

        private async Task<Doctor> Get(IDoctorIdentity employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            
            return await this.Context.Doctor.FirstOrDefaultAsync(x => x.Id == employee.Id);
        }

        public async Task<MyWebApp.Domain.Doctor> UpdateAsync(DoctorUpdateModel employee)
        {
            var existing = await this.Get(employee);

            var result = this.Mapper.Map(employee, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Doctor>(result);
        }
    }
}