using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyWebApp.Controllers
{
    // [ApiController]
    // [Route("api/[controller]")]
    // public class DiseaseApiController: ControllerBase
    // {
    //     private ILogger<DiseaseApiController> Logger { get; }
    //     // private IEmployeeCreateService EmployeeCreateService { get; }
    //     // private IEmployeeGetService EmployeeGetService { get; }
    //     // private IEmployeeUpdateService EmployeeUpdateService { get; }
    //     // private IMapper Mapper { get; }
    //
    //     public DiseaseApiController(ILogger<DiseaseApiController> logger, IMapper mapper, IEmployeeCreateService employeeCreateService, IEmployeeGetService employeeGetService, IEmployeeUpdateService employeeUpdateService)
    //     {
    //         this.Logger = logger;
    //         this.EmployeeCreateService = employeeCreateService;
    //         this.EmployeeGetService = employeeGetService;
    //         this.EmployeeUpdateService = employeeUpdateService;
    //         this.Mapper = mapper;
    //     }
    //
    //     [HttpPut]
    //     [Route("")]
    //     public async Task<EmployeeDTO> PutAsync(EmployeeCreateDTO employee)
    //     {
    //         this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
    //
    //         var result = await this.EmployeeCreateService.CreateAsync(this.Mapper.Map<EmployeeUpdateModel>(employee));
    //
    //         return this.Mapper.Map<EmployeeDTO>(result);
    //     }
    //
    //     [HttpPatch]
    //     [Route("")]
    //     public async Task<EmployeeDTO> PatchAsync(EmployeeUpdateDTO employee)
    //     {
    //         this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
    //
    //         var result = await this.EmployeeUpdateService.UpdateAsync(this.Mapper.Map<EmployeeUpdateModel>(employee));
    //
    //         return this.Mapper.Map<EmployeeDTO>(result);
    //     }
    //
    //     [HttpGet]
    //     [Route("")]
    //     public async Task<IEnumerable<EmployeeDTO>> GetAsync()
    //     {
    //         this.Logger.LogTrace($"{nameof(this.GetAsync)} called");
    //
    //         return this.Mapper.Map<IEnumerable<EmployeeDTO>>(await this.EmployeeGetService.GetAsync());
    //     }
    //
    //     [HttpGet]
    //     [Route("{employeeId}")]
    //     public async Task<EmployeeDTO> GetAsync(int employeeId)
    //     {
    //         this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {employeeId}");
    //
    //         return this.Mapper.Map<EmployeeDTO>(await this.EmployeeGetService.GetAsync(new EmployeeIdentityModel(employeeId)));
    //     }
    // }
}