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
        
        
        public StreetApiController(ILogger<StreetApiController> logger, IMapper mapper, IStreetService patientService)
        {
            this.Logger = logger;
            this.StreetService = patientService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<StreetDTO>> GetAsync(int patientId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {patientId}");
            return this.Mapper.Map<IEnumerable<StreetDTO>>(await this.StreetService.GetAsync(new StreetIdentityModel(patientId)));
        }
        
        [HttpGet("{id}")]
        public async Task<StreetDTO> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");
            return this.Mapper.Map<StreetDTO>(await this.StreetService.GetAsync());
        }
        
        [HttpPatch]
        public async Task<StreetDTO> PatchAsync(StreetUpdateDTO patient)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.StreetService.UpdateAsync(this.Mapper.Map<StreetUpdateModel>(patient));
            return this.Mapper.Map<StreetDTO>(result);
        }
        
        [HttpPut]
        public async Task<StreetDTO> PutAsync(StreetCreateDTO patient)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.StreetService.CreateAsync(this.Mapper.Map<StreetUpdateModel>(patient));
            return this.Mapper.Map<StreetDTO>(result);
        }
    }
}