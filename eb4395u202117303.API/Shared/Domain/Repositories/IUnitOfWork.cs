namespace eb4395u202117303.API.Shared.Domain.Repositories;

/// <summary>
///     Defines the contract for a unit of work pattern, allowing for transactional operations across repositories.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    ///     Asynchronously completes the unit of work, committing all changes made within the transaction.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task CompleteAsync();
}