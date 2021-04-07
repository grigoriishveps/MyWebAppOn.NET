using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.BLL.Contracts
{
    public interface IStreetService
    {
        Task<IEnumerable<Street>> GetAsync();
        Task<Street> GetAsync(IStreetIdentity id);
        Task<Street> CreateAsync(StreetUpdateModel street);
        Task<Street> UpdateAsync(StreetUpdateModel street);
    }
}