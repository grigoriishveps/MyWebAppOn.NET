using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.DAL.Contracts
{
    public interface IStreetDAL
    {
        Task<Street> InsertAsync(StreetUpdateModel employee);
        Task<IEnumerable<Street>> GetAsync();
        Task<Street> GetAsync(IStreetIdentity employeeId);
        Task<Street> UpdateAsync(StreetUpdateModel employee);
    }
}