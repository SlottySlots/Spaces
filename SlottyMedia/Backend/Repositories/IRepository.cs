namespace SlottyMedia.Backend.Repositories;

/// <summary>
///     This interface represents a repository, which is an intermediary between the application's
///     business logic and data storage. It provides consistent functionalities to perform CRUD
///     actions on a database while encapsulating the complexities of data access.
/// </summary>
/// <typeparam name="TEntity">The entity that should be managed by this repository</typeparam>
public interface IRepository<TEntity>
{
    /// <summary>
    ///     Fetches an entity by their designated primary key. Returns <c>null</c> if
    ///     no matching entity was found in the database.
    /// </summary>
    /// <param name="entityId">The entity's primary key</param>
    /// <returns>The corresponding entity or <c>null</c> if not found</returns>
    /// <exception cref="HttpRequestException">
    ///     If an HTTP error occurs while fetching the entity from the database
    ///     (except for 404, in which case <c>null</c> is returned)
    /// </exception>
    Task<TEntity?> GetById(Guid entityId);

    /// <summary>
    ///     Fetches all entities in the database and collects them in a list.
    /// </summary>
    /// <returns>The entities</returns>
    /// <exception cref="HttpRequestException">
    ///     If an HTTP error occurs while fetching the entities from the database
    /// </exception>
    Task<List<TEntity>> GetAll();

    /// <summary>
    ///     Inserts an entity into the database.
    /// </summary>
    /// <param name="entity">The entity to insert</param>
    /// <exception cref="HttpRequestException">
    ///     If an HTTP error occurs while inserting the entity into the database
    /// </exception>
    Task Add(TEntity entity);

    /// <summary>
    ///     Updates an already existing entity in the database.
    /// </summary>
    /// <param name="entity">The entity to update</param>
    /// <exception cref="HttpRequestException">
    ///     If an HTTP error occurs while updating the entity in the database
    /// </exception>
    Task Update(TEntity entity);

    /// <summary>
    ///     Deletes an entity from the database.
    /// </summary>
    /// <param name="entity">The entity to delete</param>
    /// <exception cref="HttpRequestException">
    ///     If an HTTP error occurs while deleting the entity from the database
    /// </exception>
    Task Delete(TEntity entity);
}