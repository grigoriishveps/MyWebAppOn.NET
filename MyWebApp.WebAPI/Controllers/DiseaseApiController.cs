using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApp.BLL.Contracts;
using MyWebApp.Client.DTO.Create;
using MyWebApp.Client.DTO.Read;
using MyWebApp.Client.DTO.Update;
using MyWebApp.Domain.Models;

namespace MyWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/disease")]
    public class DiseaseApiController: ControllerBase
    {
        private IDiseaseService DiseaseService{ get;}
        private ILogger<DiseaseApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public DiseaseApiController(ILogger<DiseaseApiController> logger, IMapper mapper, IDiseaseService patientService)
        {
            this.Logger = logger;
            this.DiseaseService = patientService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<DiseaseDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<DiseaseDTO>>(await this.DiseaseService.GetAsync());
        }
        
        [HttpGet("{diseaseId}")]
        public async Task<DiseaseDTO> GetAsync(int diseaseId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {diseaseId}");
            return this.Mapper.Map<DiseaseDTO>(await this.DiseaseService.GetAsync(new DiseaseIdentityModel(diseaseId)));
        }
        
        [HttpPatch]
        public async Task<DiseaseDTO> PatchAsync(DiseaseUpdateDTO patient)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.DiseaseService.UpdateAsync(this.Mapper.Map<DiseaseUpdateModel>(patient));
            return this.Mapper.Map<DiseaseDTO>(result);
        }
        
        [HttpPut]
        public async Task<DiseaseDTO> PutAsync(DiseaseCreateDTO patient)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.DiseaseService.CreateAsync(this.Mapper.Map<DiseaseUpdateModel>(patient));
            return this.Mapper.Map<DiseaseDTO>(result);
        }
    }
}