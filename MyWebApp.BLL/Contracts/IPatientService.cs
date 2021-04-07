using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.BLL.Contracts
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAsync();
        Task<Patient> GetAsync(IPatientIdentity id);
        Task<Patient> CreateAsync(PatientUpdateModel patient);
        Task<Patient> UpdateAsync(PatientUpdateModel patient);
    }
}