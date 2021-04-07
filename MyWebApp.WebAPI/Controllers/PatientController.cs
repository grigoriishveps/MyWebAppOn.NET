using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApp.BLL.Contracts;
using MyWebApp.Client.DTO;
using MyWebApp.Client.DTO.Create;
using MyWebApp.Client.DTO.Read;
using MyWebApp.Client.DTO.Update;
using MyWebApp.Domain.Models;

namespace MyWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/patient")]
    public class PatientController : ControllerBase
    {
        private IPatientService PatientService{ get;}
        private ILogger<PatientController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public PatientController(ILogger<PatientController> logger, IMapper mapper, IPatientService patientService)
        {
            this.Logger = logger;
            this.PatientService = patientService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<PatientDTO>> GetAsync(int patientId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {patientId}");
            return this.Mapper.Map<IEnumerable<PatientDTO>>(await this.PatientService.GetAsync(new PatientIdentityModel(patientId)));
        }
        
        [HttpGet("{id}")]
        public async Task<PatientDTO> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");
            return this.Mapper.Map<PatientDTO>(await this.PatientService.GetAsync());
        }
        
        [HttpPatch]
        public async Task<PatientDTO> PatchAsync(PatientUpdateDTO patient)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.PatientService.UpdateAsync(this.Mapper.Map<PatientUpdateModel>(patient));
            return this.Mapper.Map<PatientDTO>(result);
        }
        
        [HttpPut]
        public async Task<PatientDTO> PutAsync(PatientCreateDTO patient)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.PatientService.CreateAsync(this.Mapper.Map<PatientUpdateModel>(patient));
            return this.Mapper.Map<PatientDTO>(result);
        }
        
        // [HttpDelete("{id}")]
        // public async Task<PatientDTO> DeleteAsync(int id)
        // {
        //     
        // }
    }
}