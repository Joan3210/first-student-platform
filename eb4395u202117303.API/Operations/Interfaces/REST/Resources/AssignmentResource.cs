
namespace eb4395u202117303.API.Operations.Interfaces.REST.Resources
{
    public record AssignmentResource(
        int Id, 
        int StudentId, 
        int BusId, 
        DateTime AssignedAt
    );
}