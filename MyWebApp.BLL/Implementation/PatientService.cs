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
        
        public PatientService(IPatientDAL employeeDataAccess)
        {
            this.PatientDAL = employeeDataAccess;
        }
        
        public async Task<Patient> CreateAsync(PatientUpdateModel patient) {
            return await this.PatientDAL.InsertAsync(patient);
        }
        
        public async Task<Patient> UpdateAsync(PatientUpdateModel patient) {
            return await this.PatientDAL.UpdateAsync(patient);
        }
        
        public Task<IEnumerable<Patient>> GetAsync() {
            return this.PatientDAL.GetAsync();
        }
        
        public Task<Patient> GetAsync(IPatientIdentity id)
        {
            return this.PatientDAL.GetAsync(id);
        }
    }
}