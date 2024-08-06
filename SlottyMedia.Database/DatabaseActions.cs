using System.Linq.Expressions;
using Supabase.Postgrest;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database;

// TODO Implement and Logging
/// <summary>
/// This class represents the Database Actions. It is used to interact with the database.
/// </summary>
public class DatabaseActions : IDatabaseActions
{
    private readonly Supabase.Client _supabaseClient;

    public DatabaseActions(Supabase.Client supabaseClient)
    {
        _supabaseClient = supabaseClient;
    }

    /// <summary>
    /// This method inserts an item into the database.
    /// </summary>
    /// <param name="item">The Item to Insert into the database</param>
    /// <typeparam name="T">The Model Class of the Item</typeparam>
    /// <returns>Returns the Inserted Item</returns>
    public virtual async Task<T> Insert<T>(T item) where T : BaseModel, new()
    {
        try
        {
            var insertedItem = await _supabaseClient.From<T>().Insert(item);
            if (insertedItem.Model is null)
                throw new Exception("The Item could not be inserted into the database.");
            return insertedItem.Model;
        }
        catch (Exception e)
        {
            throw new DatabaseExceptions(e.Message);
        }
    }

    /// <summary>
    /// This method updates an item in the database.
    /// </summary>
    /// <param name="item">The Item to Update in the Database</param>
    /// <typeparam name="T">The Model Class of the item</typeparam>
    /// <returns>Returns the Updated Item</returns>
    public virtual async Task<T> Update<T>(T item) where T : BaseModel, new()
    {
        try
        {
            var updatedItem = await _supabaseClient.From<T>().Update(item);
            if (updatedItem.Model is null)
                throw new Exception("The Item could not be updated in the database.");
            return updatedItem.Model;
        }
        catch (Exception e)
        {
            throw new DatabaseExceptions(e.Message);
        }
    }

    /// <summary>
    /// This method deletes an item from the database.
    /// </summary>
    /// <param name="item">The Item to delete</param>
    /// <typeparam name="T">The Type of the Item object</typeparam>
    /// <returns>Returns true if the Operation was succesfull</returns>
    public virtual async Task<bool> Delete<T>(T item) where T : BaseModel, new()
    {
        try
        {
            var result = await _supabaseClient.From<T>().Delete(item);
            if (result.ResponseMessage is not null)
                result.ResponseMessage.EnsureSuccessStatusCode();
            else
                throw new Exception("The Item could not be deleted from the database.");

            return true;
        }
        catch (Exception e)
        {
            throw new DatabaseExceptions(e.Message);
        }
    }

    /// <summary>
    /// This method returns an Entity from the database based on the given field and value.
    /// </summary>
    /// <param name="field">Which field should be searched</param>
    /// <param name="value">The Value from which Element should be returnd</param>
    /// <typeparam name="T">The Type of the item object</typeparam>
    /// <returns>Returns the Entity from the Database</returns>
    public virtual async Task<T?> GetEntityByField<T>(string field, string value) where T : BaseModel, new()
    {
        try
        {
            var result = await _supabaseClient.From<T>().Filter(field, Constants.Operator.Equals, value).Single();
            if (result is null)
                throw new Exception($"The Entity with the Value {value} in the Field {field} in the " +
                                    $"Table {typeof(T)} could not be found in the database.");
            return result;
        }
        catch (Exception e)
        {
            throw new DatabaseExceptions(e.Message);
        }
    }

    public async Task<T> GetEntitieWithSelectorById<T>(Expression<Func<T, object[]>> selector, string field,
        string value) where T : BaseModel, new()
    {
        try
        {
            var result = await _supabaseClient.From<T>().Filter(field, Constants.Operator.Equals, value)
                .Select(selector).Single();
            if (result is null)
                throw new Exception("The Items could not be retrieved from the database.");
            return result;
        }
        catch (Exception e)
        {
            throw new DatabaseExceptions(e.Message);
        }
    }


    public async Task<List<T>> GetEntitiesWithSelectorById<T>(Expression<Func<T, object[]>> selector, string field,
        string value) where T : BaseModel, new()
    {
        try
        {
            var result = await _supabaseClient.From<T>().Filter(field, Constants.Operator.Equals, value)
                .Select(selector).Get();
            if (result is null)
                throw new Exception("The Items could not be retrieved from the database.");
            return result.Models;
        }
        catch (Exception e)
        {
            throw new DatabaseExceptions(e.Message);
        }
    }
}