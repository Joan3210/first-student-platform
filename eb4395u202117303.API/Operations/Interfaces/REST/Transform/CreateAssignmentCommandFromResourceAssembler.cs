using eb4395u202117303.API.Operations.Domain.Model.Aggregates;
using eb4395u202117303.API.Operations.Interfaces.REST.Resources;

namespace eb4395u202117303.API.Operations.Interfaces.REST.Transform
{
    public static class CreateAssignmentCommandFromResourceAssembler
    {
        public static Assignment ToEntityFromResource(int busId, CreateAssignmentResource resource)
        {
            return new Assignment(resource.StudentId, busId);
        }
    }
}