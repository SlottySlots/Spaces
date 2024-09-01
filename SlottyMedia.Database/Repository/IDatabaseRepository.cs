using System.Linq.Expressions;
using SlottyMedia.Database.Exceptions;
using Supabase.Postgrest.Interfaces;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database.Repository;

/// <summary>
///     This interface defines the contract for a generic database repository.
/// </summary>
/// <typeparam name="T">The type of the entity that the repository will manage.</typeparam>
public interface IDatabaseRepository<T> where T : BaseModel, new()
{
    /// <summary>
    ///     Retrieves an element by its unique identifier.
    /// </summary>
    /// <param name="entityId">The unique identifier of the entity.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the entity.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="TableHasNoPrimaryKeyException">Thrown when the table has no primary key.</exception>
    /// <exception cref="Exception">Thrown when an unexpected error occurs.</exception>
    public Task<T> GetElementById(Guid entityId);

    /// <summary>
    ///     Retrieves all elements.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of all entities.</returns>
    /// <exception cref="Exception">Thrown when an unexpected error occurs.</exception>
    public Task<List<T>> GetAllElements();

    /// <summary>
    ///     Creates a new element.
    /// </summary>
    /// <param name="element">The entity to create.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created entity.</returns>
    /// <exception cref="DatabaseIudActionException">Thrown when an error occurs while inserting the entity.</exception>
    /// <exception cref="Exception">Thrown when an unexpected error occurs.</exception>
    public Task<T> AddElement(T element);

    /// <summary>
    ///     Updates an existing element.
    /// </summary>
    /// <param name="element">The entity to update.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated entity.</returns>
    /// <exception cref="DatabaseIudActionException">Thrown when an error occurs while updating the entity.</exception>
    /// <exception cref="Exception">Thrown when an unexpected error occurs.</exception>
    public Task UpdateElement(T element);

    /// <summary>
    ///     Deletes an element by its object.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="DatabaseIudActionException">Thrown when an error occurs while deleting the entity.</exception>
    /// <exception cref="Exception">Thrown when an unexpected error occurs.</exception>
    public Task DeleteElement(T entity);

    /// <summary>
    ///     Retrieves an element by a specific field.
    /// </summary>
    /// <param name="fieldName">The name of the field.</param>
    /// <param name="fieldValue">The value of the field.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the entity.</returns>
    public Task<T> GetElementByField(string fieldName, string fieldValue);

    /// <summary>
    ///     Retrieves an element by its unique identifier with a specific selector.
    /// </summary>
    /// <param name="entityId">The unique identifier of the entity.</param>
    /// <param name="selector">The selector expression.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the entity.</returns>
    public Task<T> GetElementById(Guid entityId, Expression<Func<T, object[]>> selector);

    /// <summary>
    ///     Executes a query on the specified table.
    /// </summary>
    /// <param name="query">The query to execute.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of entities.</returns>
    protected Task<List<T>> ExecuteQuery(IPostgrestTable<T> query);
}