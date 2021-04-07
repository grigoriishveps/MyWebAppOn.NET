using Microsoft.AspNetCore.Mvc;
using MyWebApp.DAL;

namespace MyWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        // public DoctorController(ApplicationContext context)
        // {
        //     db = context;
        //     if (!db.Doctors.Any())
        //     {
        //         db.Doctors.Add(new Doctor { Initials = "Tom" });
        //         db.Doctors.Add(new Doctor { Initials = "Alice"});
        //         db.SaveChanges();
        //     }
        // }
        
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Doctor>>> Get()
        // {
        //     return await db.Doctors.ToListAsync();
        // }
        //
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Doctor>> Get(int id)
        // {
        //     Doctor doctor = await db.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        //     if (doctor == null)
        //         return NotFound();
        //     return new ObjectResult(doctor);
        // }
        //
        // [HttpPost]
        // public async Task<ActionResult<Doctor>> Post(Doctor doctor)
        // {
        //     if (doctor == null)
        //     {
        //         return BadRequest();
        //     }
        //     db.Doctors.Add(doctor);
        //     await db.SaveChangesAsync();
        //     return Ok(doctor);
        // }
        //
        // [HttpPut]
        // public async Task<ActionResult<Doctor>> Put(Doctor doctor)
        // {
        //     if (doctor == null)
        //     {
        //         return BadRequest();
        //     }
        //     if (!db.Doctors.Any(x => x.Id ==doctor.Id))
        //     {
        //         return NotFound();
        //     }
        //
        //     db.Update(doctor);
        //     await db.SaveChangesAsync();
        //     return Ok(doctor);
        // }
        //
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<Doctor>> Delete(int id)
        // {
        //     Doctor doctor = db.Doctors.FirstOrDefault(x => x.Id == id);
        //     if (doctor == null)
        //     {
        //         return NotFound();
        //     }
        //     db.Doctors.Remove(doctor);
        //     await db.SaveChangesAsync();
        //     return Ok(doctor);
        // }
    }
}