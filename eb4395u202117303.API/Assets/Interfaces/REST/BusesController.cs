
using eb4395u202117303.API.Assets.Infrastructure.Persistence;
using eb4395u202117303.API.Assets.Interfaces.REST.Resources;
using eb4395u202117303.API.Assets.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eb4395u202117303.API.Assets.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/buses")]
    [Produces("application/json")]
    public class BusesController : ControllerBase
    {
        private readonly AssetsDbContext _context;

        public BusesController(AssetsDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(typeof(BusResource), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateBus([FromBody] CreateBusResource resource)
        {
            try
            {
                var bus = CreateBusCommandFromResourceAssembler.ToEntityFromResource(resource);
        
                if (await _context.Buses.AnyAsync(b => b.VehiclePlate == bus.VehiclePlate))
                    return BadRequest("Bus with same plate already exists.");

                _context.Buses.Add(bus);
                await _context.SaveChangesAsync();
                
                var result = BusResourceFromEntityAssembler.ToResourceFromEntity(bus);
        
                return CreatedAtAction(nameof(GetBusById), new { id = bus.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusById(int id)
        {
            var bus = await _context.Buses.FindAsync(id);
            if (bus == null) return NotFound();
            
            var resource = BusResourceFromEntityAssembler.ToResourceFromEntity(bus);
            return Ok(resource);
        }
    }
}