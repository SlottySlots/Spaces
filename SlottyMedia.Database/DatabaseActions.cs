using SlottyMedia.Database.Models;
using Supabase.Postgrest;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database;

// TODO Implement Exception Handling and Logging and comments
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
    public virtual async Task<T> Insert<T>(T item) where T : BaseModel, new ()
    {
        var insertedItem = await _supabaseClient.From<T>().Insert(item);
        if (insertedItem.Model is null) return null;
        return insertedItem.Model;
    }

    /// <summary>
    /// This method updates an item in the database.
    /// </summary>
    /// <param name="item">The Item to Update in the Database</param>
    /// <typeparam name="T">The Model Class of the item</typeparam>
    /// <returns>Returns the Updated Item</returns>
    public virtual async Task<T> Update<T>(T item) where T : BaseModel, new ()
    {
        var updatedItem = await _supabaseClient.From<T>().Update(item);
        if (updatedItem.Model is null) return null;
        return updatedItem.Model;
    }
    
    /// <summary>
    /// This method deletes an item from the database.
    /// </summary>
    /// <param name="item">The Item to delete</param>
    /// <typeparam name="T">The Type of the Item object</typeparam>
    /// <returns>Returns true if the Operation was succesfull, false when it wasn't</returns>
    public virtual async Task<bool> Delete<T>(T item) where T : BaseModel, new()
    {
        await _supabaseClient.From<T>().Delete(item);
        return true; 
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
        var result = await _supabaseClient.From<T>().Filter(field, Constants.Operator.Equals, value).Single();
        if (result is null) return null;
        return result;
    }
}