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
        private IPatientDAL _patientDalImplementation;
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public PatientDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<MyWebApp.Domain.Patient> InsertAsync(PatientUpdateModel employee)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Patient>(employee));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Patient>(result.Entity);
        }

        public async Task<IEnumerable<MyWebApp.Domain.Patient>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<MyWebApp.Domain.Patient>>(
                await this.Context.Patient.ToListAsync());
        }

        public async Task<MyWebApp.Domain.Patient> GetAsync(IPatientIdentity employee)
        {
            var result = await this.Get(employee);

            return this.Mapper.Map<MyWebApp.Domain.Patient>(result);
        }

        private async Task<Patient> Get(IPatientIdentity employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            
            return await this.Context.Patient.FirstOrDefaultAsync(x => x.Id == employee.Id);
        }

        public async Task<MyWebApp.Domain.Patient> UpdateAsync(PatientUpdateModel employee)
        {
            var existing = await this.Get(employee);

            var result = this.Mapper.Map(employee, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Patient>(result);
        }
    }
}