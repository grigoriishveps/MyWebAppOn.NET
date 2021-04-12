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
    public class PatientService: IPatientService
    {
        private IPatientDAL PatientDAL { get; }
        private IStreetService StreetService { get; }
        
        public PatientService(IPatientDAL employeeDataAccess, IStreetService streetService)
        {
            this.PatientDAL = employeeDataAccess;
            this.StreetService = streetService;
        }
        
        public async Task<Patient> CreateAsync(PatientUpdateModel patient) {
            await this.StreetService.ValidateAsync(patient);
            return await this.PatientDAL.InsertAsync(patient);
        }
        
        public async Task<Patient> UpdateAsync(PatientUpdateModel patient) {
            await this.StreetService.ValidateAsync(patient);
            return await this.PatientDAL.UpdateAsync(patient);
        }
        
        public Task<IEnumerable<Patient>> GetAsync() {
            return this.PatientDAL.GetAsync();
        }
        
        public Task<Patient> GetAsync(IPatientIdentity id)
        {
            return this.PatientDAL.GetAsync(id);
        }
        
        public async Task ValidateAsync(IPatientContainer patientContainer)
        {
            if (patientContainer == null)
            {
                throw new ArgumentNullException(nameof(patientContainer));
            }
            if (patientContainer.PatientId.HasValue)
            {
                var department = await this.PatientDAL.GetAsync(new PatientIdentityModel(patientContainer.PatientId.Value));
                if( department == null)
                    throw new InvalidOperationException($"Department not found by id {patientContainer.PatientId}");
            }
        }
    }
}