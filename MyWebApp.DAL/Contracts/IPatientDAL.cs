using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using Patient = MyWebApp.Domain.Patient;

namespace MyWebApp.DAL.Contracts
{
    public interface IPatientDAL
    {
        Task<Patient> InsertAsync(PatientUpdateModel employee);
        Task<IEnumerable<Patient>> GetAsync();
        Task<Patient> GetAsync(IPatientIdentity employeeId);
        Task<Patient> UpdateAsync(PatientUpdateModel employee);
    }
}