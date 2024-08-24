using System.Linq.Expressions;
using SlottyMedia.Database.Exceptions;
using Supabase.Postgrest;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database;

/// <summary>
///     Interface for database actions. Provides methods to interact with the database.
/// </summary>
public interface IDatabaseActions
{
    /// <summary>
    ///     Inserts an item into the database.
    /// </summary>
    /// <typeparam name="T">The model class of the item.</typeparam>
    /// <param name="item">The item to insert into the database.</param>
    /// <returns>Returns the inserted item.</returns>
    /// <exception cref="GeneralDatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    Task<T> Insert<T>(T item) where T : BaseModel, new();

    /// <summary>
    ///     Updates an item in the database.
    /// </summary>
    /// <typeparam name="T">The model class of the item.</typeparam>
    /// <param name="item">The item to update in the database.</param>
    /// <returns>Returns the updated item.</returns>
    /// <exception cref="GeneralDatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    Task<T> Update<T>(T item) where T : BaseModel, new();

    /// <summary>
    ///     Deletes an item from the database.
    /// </summary>
    /// <typeparam name="T">The type of the item object.</typeparam>
    /// <param name="item">The item to delete.</param>
    /// <returns>Returns true if the operation was successful.</returns>
    /// <exception cref="GeneralDatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    Task<bool> Delete<T>(T item) where T : BaseModel, new();

    /// <summary>
    ///     Returns an entity from the database based on the given field and value.
    /// </summary>
    /// <typeparam name="T">The type of the item object.</typeparam>
    /// <param name="field">The field to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>Returns the entity from the database.</returns>
    /// <exception cref="GeneralDatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    Task<T> GetEntityByField<T>(string field, string value) where T : BaseModel, new();

    /// <summary>
    ///     Returns an entity with a selector from the database based on the given field and value.
    /// </summary>
    /// <typeparam name="T">The type of the item object.</typeparam>
    /// <param name="selector">The selector expression to use.</param>
    /// <param name="field">The field to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>Returns the entity from the database.</returns>
    /// <exception cref="GeneralDatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    Task<T> GetEntitieWithSelectorById<T>(Expression<Func<T, object[]>> selector, string field, string value)
        where T : BaseModel, new();

    /// <summary>
    ///     Returns a list of entities with a selector from the database based on the given field and value.
    /// </summary>
    /// <typeparam name="T">The type of the item object.</typeparam>
    /// <param name="selector">The selector expression to use.</param>
    /// <param name="field">The field to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <param name="max">The maximum number of items to retrieve.</param>
    /// <param name="min">The minimum number of items to retrieve</param>
    /// <param name="orderByFields">The fields to order by.</param>
    /// <returns>Returns a list of entities from the database.</returns>
    /// <exception cref="GeneralDatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    Task<List<T>> GetEntitiesWithSelectorById<T>(Expression<Func<T, object[]>> selector, string field,
        string value,
        int max = -1,
        int min = -1,
        params (string field, Constants.Ordering ordering, Constants.NullPosition nullPosition)[] orderByFields)
        where T : BaseModel, new();

    /// <summary>
    ///     Returns a list of entities with a selector from the database based on the given search criteria.
    /// </summary>
    /// <typeparam name="T">The type of the item object.</typeparam>
    /// <param name="selector">The selector expression to use.</param>
    /// <param name="search">The search criteria.</param>
    /// <param name="max">The maximum number of items to retrieve.</param>
    /// <param name="min">The minimum number of items to retrieve</param>
    /// <param name="orderByFields">The fields to order by.</param>
    /// <returns>Returns a list of entities from the database.</returns>
    /// <exception cref="GeneralDatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    Task<List<T>> GetEntitiesWithSelectorById<T>(Expression<Func<T, object[]>> selector,
        List<(string, Constants.Operator, string)> search,
        int max = -1,
        int min = -1,
        params (string field, Constants.Ordering ordering, Constants.NullPosition nullPosition)[] orderByFields)
        where T : BaseModel, new();

    /// <summary>
    ///     Returns a list of all entities from the database.
    /// </summary>
    /// <typeparam name="T">The type of the item object.</typeparam>
    /// <returns>Returns a list of entities from the database.</returns>
    /// <exception cref="GeneralDatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    Task<List<T>> GetEntities<T>() where T : BaseModel, new();

    /// <summary>
    ///     Checks if an entity exists in the database based on the given field and value.
    /// </summary>
    /// <typeparam name="T">The type of the item object.</typeparam>
    /// <param name="field">The field to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>Returns true if the entity exists.</returns>
    /// <exception cref="GeneralDatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    public Task<bool> CheckIfEntityExists<T>(string field, string value) where T : BaseModel, new();

    /// <summary>
    ///     Retrieves the count of entities from the database by a specific field and value.
    /// </summary>
    /// <typeparam name="T">The type of the entities to count.</typeparam>
    /// <param name="field">The field to filter by.</param>
    /// <param name="value">The value to filter by.</param>
    /// <returns>The count of entities.</returns>
    /// <exception cref="GeneralDatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    
    public Task<int> GetCountByField<T>(string field, string value) where T : BaseModel, new();

    /// <summary>
    /// This method retrieves the count of Forums for a specific user.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    /// <exception cref="GeneralDatabaseException"></exception>
    public Task<int> GetCountForUserForums(string userId);

    public Task<int> GetTotalForumCount(string forumID);
    
}