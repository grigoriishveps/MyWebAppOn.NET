using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using Patient = MyWebApp.DAL.Entity.Patient;

namespace MyWebApp.DAL.Implementations
{
    public class PatientDAL:IPatientDAL 
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public PatientDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<MyWebApp.Domain.Patient> InsertAsync(PatientUpdateModel patient)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Patient>(patient));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Patient>(result.Entity);
        }

        public async Task<IEnumerable<MyWebApp.Domain.Patient>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<MyWebApp.Domain.Patient>>(
                await this.Context.Patient.ToListAsync());
        }

        public async Task<MyWebApp.Domain.Patient> GetAsync(IPatientIdentity patient)
        {
            var result = await this.Get(patient);

            return this.Mapper.Map<MyWebApp.Domain.Patient>(result);
        }

        private async Task<Patient> Get(IPatientIdentity patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }
            
            return await this.Context.Patient.FirstOrDefaultAsync(x => x.Id == patient.Id);
        }

        public async Task<MyWebApp.Domain.Patient> UpdateAsync(PatientUpdateModel patient)
        {
            var existing = await this.Get(patient);

            var result = this.Mapper.Map(patient, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Patient>(result);
        }
    }
}