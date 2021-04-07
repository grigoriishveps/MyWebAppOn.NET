using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.BLL.Contracts
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAsync();
        Task<Doctor> GetAsync(IDoctorIdentity id);
        Task<Doctor> CreateAsync(DoctorUpdateModel doctor);
        Task<Doctor> UpdateAsync(DoctorUpdateModel doctor);
    }
}