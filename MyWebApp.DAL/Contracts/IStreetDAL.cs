using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.DAL.Contracts
{
    public interface IStreetDAL
    {
        Task<Street> InsertAsync(StreetUpdateModel street);
        Task<IEnumerable<Street>> GetAsync();
        Task<Street> GetAsync(IStreetIdentity streetId);
        Task<Street> UpdateAsync(StreetUpdateModel street);
    }
}