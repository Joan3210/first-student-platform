namespace eb4395u202117303.API.Operations.Application.ACL
{
    public interface IBusContextFacade
    {
        Task<bool> ExistsBusAsync(int busId);
        Task<bool> HasAvailableSeatsAsync(int busId, int currentAssignmentsCount);
    }
}