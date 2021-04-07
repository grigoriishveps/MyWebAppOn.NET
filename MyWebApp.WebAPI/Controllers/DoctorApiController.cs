using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApp.BLL.Contracts;
using MyWebApp.Client.DTO.Create;
using MyWebApp.Client.DTO.Read;
using MyWebApp.Client.DTO.Update;
using MyWebApp.DAL;
using MyWebApp.Domain.Models;

namespace MyWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorApiController : ControllerBase
    {
        private IDoctorService DoctorService{ get;}
        private ILogger<DoctorApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public DoctorApiController(ILogger<DoctorApiController> logger, IMapper mapper, IDoctorService patientService)
        {
            this.Logger = logger;
            this.DoctorService = patientService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<DoctorDTO>> GetAsync(int patientId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {patientId}");
            return this.Mapper.Map<IEnumerable<DoctorDTO>>(await this.DoctorService.GetAsync(new DoctorIdentityModel(patientId)));
        }
        
        [HttpGet("{id}")]
        public async Task<DoctorDTO> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");
            return this.Mapper.Map<DoctorDTO>(await this.DoctorService.GetAsync());
        }
        
        [HttpPatch]
        public async Task<DoctorDTO> PatchAsync(DoctorUpdateDTO patient)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.DoctorService.UpdateAsync(this.Mapper.Map<DoctorUpdateModel>(patient));
            return this.Mapper.Map<DoctorDTO>(result);
        }
        
        [HttpPut]
        public async Task<DoctorDTO> PutAsync(DoctorCreateDTO patient)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.DoctorService.CreateAsync(this.Mapper.Map<DoctorUpdateModel>(patient));
            return this.Mapper.Map<DoctorDTO>(result);
        }
    }
}