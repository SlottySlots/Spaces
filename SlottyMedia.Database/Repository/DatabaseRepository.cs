using System.Linq.Expressions;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Helper;
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

    protected readonly DatabaseRepositroyHelper DatabaseRepositroyHelper;

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
    protected DatabaseRepository(Client supabase, DaoHelper daoHelper,
        DatabaseRepositroyHelper databaseRepositroyHelper)
    {
        Supabase = supabase;
        _daoHelper = daoHelper;
        DatabaseRepositroyHelper = databaseRepositroyHelper;
    }

    /// <summary>
    ///     This method executes a query and returns the result.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<List<T>> ExecuteQuery(IPostgrestTable<T> query)
    {
        try
        {
            var response = await query.Get();

            response.ResponseMessage?.EnsureSuccessStatusCode();

            return response.Models;
        }
        catch (Exception ex)
        {
            DatabaseRepositroyHelper.HandleException(ex, "retrieving Multiple");
            return null;
        }
    }

    /// <inheritdoc />
    public virtual async Task<T> GetElementById(Guid entityId)
    {
        var primaryKeyField = _daoHelper.GetPrimaryKeyField<T>();
        if (primaryKeyField == null) throw new TableHasNoPrimaryKeyException("The table has no primary key.");

        return await ExecuteSingleQuery(Supabase.From<T>()
            .Filter(primaryKeyField, Constants.Operator.Equals, entityId.ToString()));
    }

    /// <inheritdoc />
    public virtual async Task<T> GetElementById(Guid entityId, Expression<Func<T, object[]>> selector)
    {
        var primaryKeyField = _daoHelper.GetPrimaryKeyField<T>();
        if (primaryKeyField == null) throw new TableHasNoPrimaryKeyException("The table has no primary key.");

        return await ExecuteSingleQuery(Supabase.From<T>()
            .Filter(primaryKeyField, Constants.Operator.Equals, entityId.ToString())
            .Select(selector));
    }


    /// <inheritdoc />
    public virtual async Task<T> GetElementByField(string fieldName, string fieldValue)
    {
        return await ExecuteSingleQuery(Supabase.From<T>()
            .Filter(fieldName, Constants.Operator.Equals, fieldValue));
    }

    /// <inheritdoc />
    public virtual async Task<List<T>> GetAllElements()
    {
        return await ExecuteQuery(Supabase.From<T>());
    }

    /// <inheritdoc />
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
            DatabaseRepositroyHelper.HandleException(e, "inserting");
        }
    }

    /// <inheritdoc />
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
            DatabaseRepositroyHelper.HandleException(e, "updating");
        }
    }

    /// <inheritdoc />
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
            DatabaseRepositroyHelper.HandleException(e, "deleting");
        }
    }

    /// <summary>
    ///     This method executes a single query and returns the result.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    /// <exception cref="DatabaseMissingItemException"></exception>
    public async Task<T> ExecuteSingleQuery(IPostgrestTable<T> query)
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
            DatabaseRepositroyHelper.HandleException(ex, "retrieving Single");
            return null;
        }
    }

    /// <inheritdoc />
    public virtual async Task<object> ExecuteFunction(string nameOfFunction)
    {
        try
        {
            var result = await Supabase.Rpc<object>(nameOfFunction, null);
            if (result is null)
                throw new DatabaseMissingItemException("The Items could not be retrieved from the database.");
            {
            }
            return result;
        }
        catch (Exception e)
        {
            DatabaseRepositroyHelper.HandleException(e, "executing function");
            return null;
        }
    }

    /// <inheritdoc />
    public virtual async Task<object> ExecuteFunction(string nameOfFunction, Dictionary<string, object> parameters)
    {
        try
        {
            var result = await Supabase.Rpc<object>(nameOfFunction, parameters);
            if (result is null)
                throw new DatabaseMissingItemException("The Items could not be retrieved from the database.");
            {
            }
            return result;
        }
        catch (Exception e)
        {
            DatabaseRepositroyHelper.HandleException(e, "executing function");
            return null;
        }
    }
}