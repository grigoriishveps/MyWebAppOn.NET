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
    public class DiseaseService:IDiseaseService
    {
        private IDiseaseDAL DiseaseDAL { get; }
        
        public DiseaseService(IDiseaseDAL diseaseDAL)
        {
            this.DiseaseDAL = diseaseDAL;
        }
        
        public async Task<Disease> CreateAsync(DiseaseUpdateModel disease) {
            return await this.DiseaseDAL.InsertAsync(disease);
        }
        
        public async Task<Disease> UpdateAsync(DiseaseUpdateModel disease) {
            return await this.DiseaseDAL.UpdateAsync(disease);
        }
        
        public Task<IEnumerable<Disease>> GetAsync() {
            return this.DiseaseDAL.GetAsync();
        }
        
        public Task<Disease> GetAsync(IDiseaseIdentity id)
        {
            return this.DiseaseDAL.GetAsync(id);
        }
        
        public async Task ValidateAsync(IDiseaseContainer diseaseContainer)
        {
            if (diseaseContainer == null)
            {
                throw new ArgumentNullException(nameof(diseaseContainer));
            }
            if (diseaseContainer.DiseaseId.HasValue )
            {
                var department = await this.DiseaseDAL.GetAsync(new DiseaseIdentityModel(diseaseContainer.DiseaseId.Value));
                if(department == null)
                    throw new InvalidOperationException($"Department not found by id {diseaseContainer.DiseaseId}");
            }
        }
    }
}