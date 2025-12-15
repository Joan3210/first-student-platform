using eb4395u202117303.API.Operations.Domain.Model.Aggregates;
using eb4395u202117303.API.Operations.Interfaces.REST.Resources;

namespace eb4395u202117303.API.Operations.Interfaces.REST.Transform
{
    public static class AssignmentResourceFromEntityAssembler
    {
        public static AssignmentResource ToResourceFromEntity(Assignment entity)
        {
            return new AssignmentResource(entity.Id, entity.StudentId, entity.BusId, entity.AssignedAt);
        }
    }
}