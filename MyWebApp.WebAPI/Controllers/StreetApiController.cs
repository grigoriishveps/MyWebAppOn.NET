using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApp.BLL.Contracts;
using MyWebApp.Client.DTO.Create;
using MyWebApp.Client.DTO.Update;
using MyWebApp.Domain.Models;

namespace MyWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/street")]
    public class StreetApiController: ControllerBase
    {
        private IStreetService StreetService{ get;}
        private ILogger<StreetApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public StreetApiController(ILogger<StreetApiController> logger, IMapper mapper, IStreetService streetService)
        {
            this.Logger = logger;
            this.StreetService = streetService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<StreetDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<StreetDTO>>(await this.StreetService.GetAsync());
        }
        
        [HttpGet("{streetId}")]
        public async Task<StreetDTO> GetAsync(int streetId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {streetId}");
            return this.Mapper.Map<StreetDTO>(await this.StreetService.GetAsync(new StreetIdentityModel(streetId)));
        }
        
        [HttpPatch]
        public async Task<StreetDTO> PatchAsync(StreetUpdateDTO street)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.StreetService.UpdateAsync(this.Mapper.Map<StreetUpdateModel>(street));
            return this.Mapper.Map<StreetDTO>(result);
        }
        
        [HttpPut]
        public async Task<StreetDTO> PutAsync(StreetCreateDTO street)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.StreetService.CreateAsync(this.Mapper.Map<StreetUpdateModel>(street));
            return this.Mapper.Map<StreetDTO>(result);
        }
    }
}