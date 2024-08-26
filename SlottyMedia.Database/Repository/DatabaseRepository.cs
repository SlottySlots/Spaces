using SlottyMedia.Database.Exceptions;
using Supabase.Postgrest;
using Supabase.Postgrest.Interfaces;
using Supabase.Postgrest.Models;
using Client = Supabase.Client;

namespace SlottyMedia.Database.Repository;

/// <summary>
///     This interface provides the basic CRUD operations for a database repository.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class DatabaseRepository<T> : IDatabaseRepository<T> where T : BaseModel, new()
{
    /// <summary>
    ///     This field is used to access the _daoHelper class.
    /// </summary>
    private readonly DaoHelper _daoHelper;
    
    private readonly DatabaseRepositroyHelper _databaseRepositroyHelper;

    /// <summary>
    ///     This field is used to access the Supabase client.
    /// </summary>
    protected readonly Client Supabase;


    /// <summary>
    ///     The default constructor.
    /// </summary>
    /// <param name="supabase"></param>
    /// <param name="daoHelper"></param>
    /// <param name="databaseRepositroyHelper"></param>
    protected DatabaseRepository(Client supabase, DaoHelper daoHelper, DatabaseRepositroyHelper databaseRepositroyHelper)
    {
        Supabase = supabase;
        _daoHelper = daoHelper;
        _databaseRepositroyHelper = databaseRepositroyHelper;
    }

    /// <summary>
    ///     This method executes a single query and returns the result.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    /// <exception cref="DatabaseMissingItemException"></exception>
    private async Task<T> ExecuteSingleQuery(IPostgrestTable<T> query)
    {
        try
        {
            var response = await query.Single();

            if (response != null)
                return response;
            throw new DatabaseMissingItemException("The entity was not found in the database.");
        }
        catch (Exception ex)
        {
            _databaseRepositroyHelper.HandleException(ex, "retrieving Single");
            return null;
        }
    }

    /// <summary>
    ///     This method executes a query and returns the result.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    private async Task<List<T>> ExecuteQuery(IPostgrestTable<T> query)
    {
        try
        {
            var response = await query.Get();

            response.ResponseMessage?.EnsureSuccessStatusCode();

            return response.Models;
        }
        catch (Exception ex)
        {
            _databaseRepositroyHelper.HandleException(ex, "retrieving Multiple");
            return null;
        }
    }


    /// <summary>
    ///     This method fetches an entity by their designated primary key.
    /// </summary>
    /// <param name="entityId"></param>
    /// <returns></returns>
    /// <exception cref="TableHasNoPrimaryKeyException">When the Table has no Primary Key, this exception will be returned</exception>
    public virtual async Task<T> GetElementById(Guid entityId)
    {
        var primaryKeyField = _daoHelper.GetPrimaryKeyField<T>();
        if (primaryKeyField == null) throw new TableHasNoPrimaryKeyException("The table has no primary key.");

        return await ExecuteSingleQuery(Supabase.From<T>()
            .Filter(primaryKeyField, Constants.Operator.Equals, entityId));
    }
    
    /// <summary>
    /// This method fetches an entity by their field name and value.
    /// </summary>
    /// <param name="fieldName"></param>
    /// <param name="fieldValue"></param>
    /// <returns></returns>
    public virtual async Task<T> GetElementByField(string fieldName, string fieldValue)
    {
        return await ExecuteSingleQuery(Supabase.From<T>()
            .Filter(fieldName, Constants.Operator.Equals, fieldValue));
    }

    /// <summary>
    ///     This method fetches all entities of the designated type.
    /// </summary>
    /// <returns></returns>
    public virtual async Task<List<T>> GetAllElements()
    {
        return await ExecuteQuery(Supabase.From<T>());
    }

    /// <summary>
    ///     This method adds an entity to the database.
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="DatabaseIudActionException">This Exception is thrown when we weren't able to insert the item</exception>
    public virtual async Task AddElement(T entity)
    {
        try
        {
            var result = await Supabase.From<T>().Insert(entity);
            if (!result.ResponseMessage!.IsSuccessStatusCode)
                throw new DatabaseIudActionException("An error occurred while inserting the entity.");
        }
        catch (Exception e)
        {
            _databaseRepositroyHelper.HandleException(e, "inserting");
        }
    }

    /// <summary>
    ///     This method updates an entity in the database.
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="DatabaseIudActionException">This Exception is thrown when we weren't able to update the item</exception>
    public virtual async Task UpdateElement(T entity)
    {
        try
        {
            var result = await Supabase.From<T>().Update(entity);
            if (!result.ResponseMessage!.IsSuccessStatusCode)
                throw new DatabaseIudActionException("An error occurred while updating the entity.");
        }
        catch (Exception e)
        {
            _databaseRepositroyHelper.HandleException(e, "updating");
        }
    }

    /// <summary>
    ///     This method deletes an entity in the database.
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="DatabaseIudActionException">This Exception is thrown when we weren't able to delete the item</exception>
    public virtual async Task DeleteElement(T entity)
    {
        try
        {
            var result = await Supabase.From<T>().Delete(entity);
            if (!result.ResponseMessage!.IsSuccessStatusCode)
                throw new DatabaseIudActionException("An error occurred while deleting the entity.");
        }
        catch (Exception e)
        {
            _databaseRepositroyHelper.HandleException(e, "deleting");
        }
    }
}