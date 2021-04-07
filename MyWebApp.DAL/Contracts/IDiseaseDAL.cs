using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.DAL.Contracts
{
    public interface IDiseaseDAL
    {
        Task<Disease> InsertAsync(DiseaseUpdateModel employee);
        Task<IEnumerable<Disease>> GetAsync();
        Task<Disease> GetAsync(IDiseaseIdentity employeeId);
        Task<Disease> UpdateAsync(DiseaseUpdateModel employee);
    }
}