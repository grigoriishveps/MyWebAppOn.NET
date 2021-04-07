using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApp.DAL;

namespace MyWebApp.Controllers
{
    [ApiController]
    [Route("api/disease")]
    public class DiseaseController : ControllerBase
    {
        // public DiseaseController(ApplicationContext context)
        // {
        //     db = context;
        //     if (!db.Diseases.Any())
        //     {
        //         // db.Users.Add(new User { Name = "Tom", Age = 26 });
        //         // db.Users.Add(new User { Name = "Alice", Age = 31 });
        //         // db.SaveChanges();
        //     }
        // }
        //
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Disease>>> Get()
        // {
        //     return await db.Diseases.ToListAsync();
        // }
        //
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Disease>> Get(int id)
        // {
        //     Disease disease = await db.Diseases.FirstOrDefaultAsync(x => x.Id == id);
        //     if (disease == null)
        //         return NotFound();
        //     return new ObjectResult(disease);
        // }
        //
        // [HttpPost]
        // public async Task<ActionResult<Disease>> Post(Disease disease)
        // {
        //     if (disease == null)
        //     {
        //         return BadRequest();
        //     }
        //
        //     db.Diseases.Add(disease);
        //     await db.SaveChangesAsync();
        //     return Ok(disease);
        // }
        //
        // [HttpPut]
        // public async Task<ActionResult<Disease>> Put(Disease disease)
        // {
        //     if (disease == null)
        //     {
        //         return BadRequest();
        //     }
        //     if (!db.Diseases.Any(x => x.Id ==disease.Id))
        //     {
        //         return NotFound();
        //     }
        //
        //     db.Update(disease);
        //     await db.SaveChangesAsync();
        //     return Ok(disease);
        // }
        //
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<Disease>> Delete(int id)
        // {
        //     Disease disease = db.Diseases.FirstOrDefault(x => x.Id == id);
        //     if (disease == null)
        //     {
        //         return NotFound();
        //     }
        //     db.Diseases.Remove(disease);
        //     await db.SaveChangesAsync();
        //     return Ok(disease);
        // }
    }
}