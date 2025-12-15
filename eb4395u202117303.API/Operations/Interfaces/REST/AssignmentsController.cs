using eb4395u202117303.API.Operations.Application.ACL;
using eb4395u202117303.API.Operations.Infrastructure.Persistence;
using eb4395u202117303.API.Operations.Interfaces.REST.Resources;
using eb4395u202117303.API.Operations.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eb4395u202117303.API.Operations.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/buses/{busId}/assignments")]
    public class AssignmentsController : ControllerBase
    {
        private readonly OperationsDbContext _context;
        private readonly IBusContextFacade _busFacade;

        public AssignmentsController(OperationsDbContext context, IBusContextFacade busFacade)
        {
            _context = context;
            _busFacade = busFacade;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssignment(int busId, [FromBody] CreateAssignmentResource resource)
        {
            if (!await _busFacade.ExistsBusAsync(busId))
                return BadRequest($"Bus {busId} does not exist.");
            
            var student = await _context.Students.FindAsync(resource.StudentId);
            if (student == null)
                return BadRequest($"Student {resource.StudentId} does not exist.");
            
            if (await _context.Assignments.AnyAsync(a => a.StudentId == resource.StudentId))
                return BadRequest("Student is already assigned to a bus.");
            
            var currentCount = await _context.Assignments.CountAsync(a => a.BusId == busId);
            if (!await _busFacade.HasAvailableSeatsAsync(busId, currentCount))
                return BadRequest("Bus is full.");
            
            var siblingIds = await _context.Students
                .Where(s => s.ParentId == student.ParentId && s.Id != student.Id)
                .Select(s => s.Id)
                .ToListAsync();

            if (siblingIds.Any())
            {
                var siblingAssignment = await _context.Assignments
                    .FirstOrDefaultAsync(a => siblingIds.Contains(a.StudentId));

                if (siblingAssignment != null && siblingAssignment.BusId != busId)
                {
                    return BadRequest($"Student has a sibling assigned to Bus {siblingAssignment.BusId}. They must travel together.");
                }
            }
            
            var assignment = CreateAssignmentCommandFromResourceAssembler.ToEntityFromResource(busId, resource);
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
            
            var result = AssignmentResourceFromEntityAssembler.ToResourceFromEntity(assignment);
            
            return StatusCode(201, result);
        }
    }
}