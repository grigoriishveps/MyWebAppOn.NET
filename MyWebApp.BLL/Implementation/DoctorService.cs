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
    public class DoctorService:IDoctorService
    {
        private IDoctorDAL DoctorDAL { get; }
        
        public DoctorService(IDoctorDAL employeeDataAccess)
        {
            this.DoctorDAL = employeeDataAccess;
        }
        
        public async Task<Doctor> CreateAsync(DoctorUpdateModel doctor) {
            return await this.DoctorDAL.InsertAsync(doctor);
        }
        
        public async Task<Doctor> UpdateAsync(DoctorUpdateModel doctor) {
            return await this.DoctorDAL.UpdateAsync(doctor);
        }
        
        public Task<IEnumerable<Doctor>> GetAsync() {
            return this.DoctorDAL.GetAsync();
        }
        
        public Task<Doctor> GetAsync(IDoctorIdentity id)
        {
            return this.DoctorDAL.GetAsync(id);
        }
        
        public async Task ValidateAsync(IDoctorContainer doctorContainer)
        {
            if (doctorContainer == null)
            {
                throw new ArgumentNullException(nameof(doctorContainer));
            }
            
            //var department = await this.DoctorDAL.GetAsync(new DoctorIdentityModel((int) doctorContainer.DoctorId));
            
            if (doctorContainer.DoctorId.HasValue)
            {
                var department = await this.DoctorDAL.GetAsync(new DoctorIdentityModel((int) doctorContainer.DoctorId));
                if(department == null) 
                    throw new InvalidOperationException($"Doctor not found by id {doctorContainer.DoctorId}");
            }
        }
    }
}