using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapoDeDev.Domain.Entities;

namespace PapoDeDevAPI.Controllers
{
    [Route("api/v1/devs")]
    [ApiController]
    [Produces("application/json")]
    public class DeveloperController : ControllerBase
    {
        private readonly DevContext _devContext;

        public DeveloperController(DevContext context)
        {
            _devContext = context;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Developer), 200)]
        public async Task<ActionResult<Developer>> GetById(Guid id)
        {
            var dev = await _devContext.Developers.FindAsync(id);

            if (dev == null) return NotFound("Nenhum dev encontrado!");

            return Ok(dev);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Developer>), 200)]
        public async Task<ActionResult<List<Developer>>> Get()
        {
            return Ok(await _devContext.Developers.ToListAsync());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Developer), 201)]
        public async Task<ActionResult<Developer>> Insert(Developer dev)
        {
            await _devContext.AddAsync(dev);
            await _devContext.SaveChangesAsync();
            return Ok(dev);
        }

        [HttpPut]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Update(Developer request)
        {
            var dev = await _devContext.Developers.FindAsync(request.Id);

            if (dev == null) 
                return NotFound("Nenhum dev encontrado!");

            dev.Name = request.Name;
            dev.Company = request.Company;
            dev.Role = request.Role;

            await _devContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Developer>> Delete(Guid id)
        {
            var dev = await _devContext.Developers.FindAsync(id);

            if (dev == null) 
                return NotFound("Nenhum dev encontrado!");

            _devContext.Remove(dev);
            await _devContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
