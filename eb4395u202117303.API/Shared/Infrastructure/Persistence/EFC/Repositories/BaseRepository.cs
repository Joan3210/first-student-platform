using eb4395u202117303.API.Shared.Domain.Repositories;
using eb4395u202117303.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace eb4395u202117303.API.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Base implementation of the repository pattern using Entity Framework Core.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext Context;

    /// <summary>
    ///     Initializes a new instance of the <see cref="BaseRepository{TEntity}" /> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    protected BaseRepository(AppDbContext context)
    {
        Context = context;
    }

    /// <summary>
    ///     Asynchronously adds a new entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    /// <summary>
    ///     Asynchronously finds an entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity.</param>
    /// <returns>A task that represents the asynchronous operation, containing the entity if found; otherwise, null.</returns>
    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    /// <summary>
    ///     Asynchronously retrieves a list of all entities.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing an enumerable of entities.</returns>
    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }

    /// <summary>
    ///     Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    /// <summary>
    ///     Removes an entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }
}