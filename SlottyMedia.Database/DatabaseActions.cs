using System.Linq.Expressions;
using SlottyMedia.Database.Exceptions;
using Supabase.Postgrest;
using Supabase.Postgrest.Models;
using Client = Supabase.Client;

namespace SlottyMedia.Database;

public class DatabaseActions : IDatabaseActions
{
    private readonly Client _supabaseClient;

    public DatabaseActions(Client supabaseClient)
    {
        _supabaseClient = supabaseClient;
    }

    /// <summary>
    ///     Inserts an item into the database.
    /// </summary>
    /// <typeparam name="T">The type of the item to insert.</typeparam>
    /// <param name="item">The item to insert.</param>
    /// <returns>The inserted item.</returns>
    /// <exception cref="DatabaseIudActionException">Thrown when the item could not be inserted into the database.</exception>
    /// <exception cref="DatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    public virtual async Task<T> Insert<T>(T item) where T : BaseModel, new()
    {
        try
        {
            var insertedItem = await _supabaseClient.From<T>().Insert(item);
            if (insertedItem.Model is null)
                throw new DatabaseIudActionException("The Item could not be inserted into the database.");
            return insertedItem.Model;
        }
        catch (DatabaseIudActionException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            throw new DatabaseException("A network error occurred while inserting the item.", ex);
        }
        catch (ArgumentNullException ex)
        {
            throw new DatabaseException("A required argument was null while inserting the item.", ex);
        }
        catch (InvalidOperationException ex)
        {
            throw new DatabaseException("An invalid operation occurred while inserting the item.", ex);
        }
        catch (TimeoutException ex)
        {
            throw new DatabaseException("A timeout occurred while inserting the item.", ex);
        }
        catch (TaskCanceledException ex)
        {
            throw new DatabaseException("The task was canceled while inserting the item.", ex);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("An unexpected error occurred while inserting the item.", ex);
        }
    }

    /// <summary>
    ///     Updates an item in the database.
    /// </summary>
    /// <typeparam name="T">The type of the item to update.</typeparam>
    /// <param name="item">The item to update.</param>
    /// <returns>The updated item.</returns>
    /// <exception cref="DatabaseIudActionException">Thrown when the item could not be updated in the database.</exception>
    /// <exception cref="DatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    public virtual async Task<T> Update<T>(T item) where T : BaseModel, new()
    {
        try
        {
            var updatedItem = await _supabaseClient.From<T>().Update(item);
            if (updatedItem.Model is null)
                throw new DatabaseIudActionException("The Item could not be updated in the database.");
            return updatedItem.Model;
        }
        catch (DatabaseIudActionException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            throw new DatabaseException("A network error occurred while updating the item.", ex);
        }
        catch (ArgumentNullException ex)
        {
            throw new DatabaseException("A required argument was null while updating the item.", ex);
        }
        catch (InvalidOperationException ex)
        {
            throw new DatabaseException("An invalid operation occurred while updating the item.", ex);
        }
        catch (TimeoutException ex)
        {
            throw new DatabaseException("A timeout occurred while updating the item.", ex);
        }
        catch (TaskCanceledException ex)
        {
            throw new DatabaseException("The task was canceled while updating the item.", ex);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("An unexpected error occurred while updating the item.", ex);
        }
    }

    /// <summary>
    ///     Deletes an item from the database.
    /// </summary>
    /// <typeparam name="T">The type of the item to delete.</typeparam>
    /// <param name="item">The item to delete.</param>
    /// <returns>True if the item was deleted successfully, otherwise false.</returns>
    /// <exception cref="DatabaseIudActionException">Thrown when the item could not be deleted from the database.</exception>
    /// <exception cref="DatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    public virtual async Task<bool> Delete<T>(T item) where T : BaseModel, new()
    {
        try
        {
            var result = await _supabaseClient.From<T>().Delete(item);
            if (result.ResponseMessage is not null)
                result.ResponseMessage.EnsureSuccessStatusCode();
            else
                throw new DatabaseIudActionException("The Item could not be deleted from the database.");

            return true;
        }
        catch (DatabaseIudActionException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            throw new DatabaseException("A network error occurred while deleting the item.", ex);
        }
        catch (ArgumentNullException ex)
        {
            throw new DatabaseException("A required argument was null while deleting the item.", ex);
        }
        catch (InvalidOperationException ex)
        {
            throw new DatabaseException("An invalid operation occurred while deleting the item.", ex);
        }
        catch (TimeoutException ex)
        {
            throw new DatabaseException("A timeout occurred while deleting the item.", ex);
        }
        catch (TaskCanceledException ex)
        {
            throw new DatabaseException("The task was canceled while deleting the item.", ex);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("An unexpected error occurred while deleting the item.", ex);
        }
    }

    /// <summary>
    ///     Retrieves an entity from the database by a specific field and value.
    /// </summary>
    /// <typeparam name="T">The type of the entity to retrieve.</typeparam>
    /// <param name="field">The field to filter by.</param>
    /// <param name="value">The value to filter by.</param>
    /// <returns>The retrieved entity.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity could not be found in the database.</exception>
    /// <exception cref="DatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    public virtual async Task<T> GetEntityByField<T>(string field, string value) where T : BaseModel, new()
    {
        try
        {
            var result = await _supabaseClient.From<T>().Filter(field, Constants.Operator.Equals, value).Single();
            if (result is null)
                throw new DatabaseMissingItemException(
                    $"The Entity with the Value {value} in the Field {field} in the " +
                    $"Table {typeof(T)} could not be found in the database.");
            return result;
        }
        catch (DatabaseMissingItemException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            throw new DatabaseException("A network error occurred while retrieving the entity.", ex);
        }
        catch (ArgumentNullException ex)
        {
            throw new DatabaseException("A required argument was null while retrieving the entity.", ex);
        }
        catch (InvalidOperationException ex)
        {
            throw new DatabaseException("An invalid operation occurred while retrieving the entity.", ex);
        }
        catch (TimeoutException ex)
        {
            throw new DatabaseException("A timeout occurred while retrieving the entity.", ex);
        }
        catch (TaskCanceledException ex)
        {
            throw new DatabaseException("The task was canceled while retrieving the entity.", ex);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("An unexpected error occurred while retrieving the entity.", ex);
        }
    }

    /// <summary>
    ///     Retrieves an entity from the database by a specific field and value with a selector.
    /// </summary>
    /// <typeparam name="T">The type of the entity to retrieve.</typeparam>
    /// <param name="selector">The selector expression.</param>
    /// <param name="field">The field to filter by.</param>
    /// <param name="value">The value to filter by.</param>
    /// <returns>The retrieved entity.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity could not be found in the database.</exception>
    /// <exception cref="DatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    public async Task<T> GetEntitieWithSelectorById<T>(Expression<Func<T, object[]>> selector, string field,
        string value) where T : BaseModel, new()
    {
        try
        {
            var result = await _supabaseClient.From<T>().Filter(field, Constants.Operator.Equals, value)
                .Select(selector).Single();
            if (result is null)
                throw new DatabaseMissingItemException("The Items could not be retrieved from the database.");
            return result;
        }
        catch (DatabaseMissingItemException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            throw new DatabaseException("A network error occurred while retrieving the entity.", ex);
        }
        catch (ArgumentNullException ex)
        {
            throw new DatabaseException("A required argument was null while retrieving the entity.", ex);
        }
        catch (InvalidOperationException ex)
        {
            throw new DatabaseException("An invalid operation occurred while retrieving the entity.", ex);
        }
        catch (TimeoutException ex)
        {
            throw new DatabaseException("A timeout occurred while retrieving the entity.", ex);
        }
        catch (TaskCanceledException ex)
        {
            throw new DatabaseException("The task was canceled while retrieving the entity.", ex);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("An unexpected error occurred while retrieving the entity.", ex);
        }
    }

    /// <summary>
    ///     Retrieves a list of entities from the database by a specific field and value with a selector.
    /// </summary>
    /// <typeparam name="T">The type of the entities to retrieve.</typeparam>
    /// <param name="selector">The selector expression.</param>
    /// <param name="field">The field to filter by.</param>
    /// <param name="value">The value to filter by.</param>
    /// <param name="max">The maximum number of entities to retrieve.</param>
    /// <param name="min">The minimum number of entities to retrieve.</param>
    /// <param name="orderByFields">The fields to order by.</param>
    /// <returns>The list of retrieved entities.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entities could not be found in the database.</exception>
    /// <exception cref="DatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    public async Task<List<T>> GetEntitiesWithSelectorById<T>(Expression<Func<T, object[]>> selector, string field,
        string value,
        int max = -1,
        int min = -1,
        params (string field, Constants.Ordering ordering, Constants.NullPosition nullPosition)[] orderByFields)
        where T : BaseModel, new()
    {
        try
        {
            var query = _supabaseClient.From<T>().Filter(field, Constants.Operator.Equals, value).Select(selector);
            if (max is not -1) query = query.Range(min, max);

            if (orderByFields.Length > 0)
                foreach (var (orderByField, ordering, nullPosition) in orderByFields)
                    query = query.Order(orderByField, ordering, nullPosition);

            var result = await query.Get();
            if (result is null || result.Models is null)
                throw new DatabaseMissingItemException("The Items could not be retrieved from the database.");
            return result.Models;
        }
        catch (DatabaseMissingItemException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            throw new DatabaseException("A network error occurred while retrieving the entities.", ex);
        }
        catch (ArgumentNullException ex)
        {
            throw new DatabaseException("A required argument was null while retrieving the entities.", ex);
        }
        catch (InvalidOperationException ex)
        {
            throw new DatabaseException("An invalid operation occurred while retrieving the entities.", ex);
        }
        catch (TimeoutException ex)
        {
            throw new DatabaseException("A timeout occurred while retrieving the entities.", ex);
        }
        catch (TaskCanceledException ex)
        {
            throw new DatabaseException("The task was canceled while retrieving the entities.", ex);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("An unexpected error occurred while retrieving the entities.", ex);
        }
    }

    /// <summary>
    ///     Retrieves a list of entities from the database by a specific field and value with a selector and search criteria.
    /// </summary>
    /// <typeparam name="T">The type of the entities to retrieve.</typeparam>
    /// <param name="selector">The selector expression.</param>
    /// <param name="search">The search criteria.</param>
    /// <param name="max">The maximum number of entities to retrieve.</param>
    /// <param name="min">The minimum number of entities to retrieve.</param>
    /// <param name="orderByFields">The fields to order by.</param>
    /// <returns>The list of retrieved entities.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entities could not be found in the database.</exception>
    /// <exception cref="DatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    public async Task<List<T>> GetEntitiesWithSelectorById<T>(Expression<Func<T, object[]>> selector,
        List<(string, Constants.Operator, string)> search,
        int max = -1,
        int min = -1,
        params (string field, Constants.Ordering ordering, Constants.NullPosition nullPosition)[] orderByFields)
        where T : BaseModel, new()
    {
        try
        {
            var query = _supabaseClient.From<T>().Select(selector);
            if (max is not -1) query = query.Range(min, max);

            if (orderByFields.Length > 0)
                foreach (var (orderByField, ordering, nullPosition) in orderByFields)
                    query = query.Order(orderByField, ordering, nullPosition);
            if (search.Count > 0)
                foreach (var searchVariable in search)
                    query.Filter(searchVariable.Item1, searchVariable.Item2, searchVariable.Item3);

            var result = await query.Get();
            if (result is null || result.Models is null)
                throw new DatabaseMissingItemException("The Items could not be retrieved from the database.");
            return result.Models;
        }
        catch (DatabaseMissingItemException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            throw new DatabaseException("A network error occurred while retrieving the entities.", ex);
        }
        catch (ArgumentNullException ex)
        {
            throw new DatabaseException("A required argument was null while retrieving the entities.", ex);
        }
        catch (InvalidOperationException ex)
        {
            throw new DatabaseException("An invalid operation occurred while retrieving the entities.", ex);
        }
        catch (TimeoutException ex)
        {
            throw new DatabaseException("A timeout occurred while retrieving the entities.", ex);
        }
        catch (TaskCanceledException ex)
        {
            throw new DatabaseException("The task was canceled while retrieving the entities.", ex);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("An unexpected error occurred while retrieving the entities.", ex);
        }
    }

    /// <summary>
    ///     Retrieves a list of entities from the database.
    /// </summary>
    /// <typeparam name="T">The type of the entities to retrieve.</typeparam>
    /// <returns>The list of retrieved entities.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entities could not be found in the database.</exception>
    /// <exception cref="DatabaseException">
    ///     Thrown when a network error, argument null, invalid operation, timeout, task
    ///     cancellation, or unexpected error occurs.
    /// </exception>
    public async Task<List<T>> GetEntities<T>() where T : BaseModel, new()
    {
        try
        {
            var result = await _supabaseClient.From<T>().Get();
            if (result is null)
                throw new DatabaseMissingItemException("The Items could not be retrieved from the database.");

            return result.Models;
        }
        catch (DatabaseMissingItemException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            throw new DatabaseException("A network error occurred while retrieving the entities.", ex);
        }
        catch (ArgumentNullException ex)
        {
            throw new DatabaseException("A required argument was null while retrieving the entities.", ex);
        }
        catch (InvalidOperationException ex)
        {
            throw new DatabaseException("An invalid operation occurred while retrieving the entities.", ex);
        }
        catch (TimeoutException ex)
        {
            throw new DatabaseException("A timeout occurred while retrieving the entities.", ex);
        }
        catch (TaskCanceledException ex)
        {
            throw new DatabaseException("The task was canceled while retrieving the entities.", ex);
        }
        catch (Exception ex)
        {
            throw new DatabaseException("An unexpected error occurred while retrieving the entities.", ex);
        }
    }
}