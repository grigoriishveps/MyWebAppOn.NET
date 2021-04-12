using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.DAL.Contracts
{
    public interface IDoctorDAL
    {
        Task<Doctor> InsertAsync(DoctorUpdateModel doctor);
        Task<IEnumerable<Doctor>> GetAsync();
        Task<Doctor> GetAsync(IDoctorIdentity doctorId);
        Task<Doctor> UpdateAsync(DoctorUpdateModel doctor);
    }
}