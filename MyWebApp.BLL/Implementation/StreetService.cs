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
    public class StreetService:IStreetService
    {
        private IStreetDAL StreetDAL { get; }
        
        public StreetService(IStreetDAL streetDAL)
        {
            this.StreetDAL = streetDAL;
        }
        
        public async Task<Street> CreateAsync(StreetUpdateModel street) {
            return await this.StreetDAL.InsertAsync(street);
        }
        
        public async Task<Street> UpdateAsync(StreetUpdateModel street) {
            return await this.StreetDAL.UpdateAsync(street);
        }
        
        public Task<IEnumerable<Street>> GetAsync() {
            return this.StreetDAL.GetAsync();
        }
        
        public Task<Street> GetAsync(IStreetIdentity id)
        {
            return this.StreetDAL.GetAsync(id);
        }
        public async Task ValidateAsync(IStreetContainer streetContainer){
            if (streetContainer == null)
            {
                throw new ArgumentNullException(nameof(streetContainer));
            }
            else
            {
                if (streetContainer.StreetId.HasValue)
                {
                    var department = await this.StreetDAL.GetAsync(new StreetIdentityModel(streetContainer.StreetId.Value));
                    if (department == null)
                        throw new InvalidOperationException($"Street not found by id {streetContainer.StreetId}");
                }
            }
        }
    }
}