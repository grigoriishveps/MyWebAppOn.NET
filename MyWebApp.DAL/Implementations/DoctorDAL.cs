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

        public async Task<MyWebApp.Domain.Doctor> InsertAsync(DoctorUpdateModel doctor)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Doctor>(doctor));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Doctor>(result.Entity);
        }

        public async Task<IEnumerable<MyWebApp.Domain.Doctor>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<MyWebApp.Domain.Doctor>>(
                await this.Context.Doctor.ToListAsync());
        }

        public async Task<MyWebApp.Domain.Doctor> GetAsync(IDoctorIdentity doctor)
        {
            var result = await this.Get(doctor);

            return this.Mapper.Map<MyWebApp.Domain.Doctor>(result);
        }

        private async Task<Doctor> Get(IDoctorIdentity doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }
            
            return await this.Context.Doctor.FirstOrDefaultAsync(x => x.Id == doctor.Id);
        }

        public async Task<MyWebApp.Domain.Doctor> UpdateAsync(DoctorUpdateModel doctor)
        {
            var existing = await this.Get(doctor);

            var result = this.Mapper.Map(doctor, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Doctor>(result);
        }
    }
}