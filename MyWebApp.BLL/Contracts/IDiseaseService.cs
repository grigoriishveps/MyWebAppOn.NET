using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.BLL.Contracts
{
    public interface IDiseaseService
    {
        Task<IEnumerable<Disease>> GetAsync();
        Task<Disease> GetAsync(IDiseaseIdentity id);
        Task<Disease> CreateAsync(DiseaseUpdateModel disease);
        Task<Disease> UpdateAsync(DiseaseUpdateModel disease);
    }
}