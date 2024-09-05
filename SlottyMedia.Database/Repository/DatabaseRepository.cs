using System.Linq.Expressions;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Helper;
using SlottyMedia.Database.Pagination;
using SlottyMedia.LoggingProvider;
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
    private static readonly Logging<DatabaseRepository<T>> _logger = new();

    /// <summary>
    ///     This field is used to access the _daoHelper class.
    /// </summary>
    private readonly DaoHelper _daoHelper;

    /// <summary>
    ///     This field is used to access the DatabaseRepositroyHelper class.
    /// </summary>
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
    public virtual Task<IPage<T>> GetAllElements(PageRequest pageRequest)
    {
        return ApplyPagination(() => Supabase.From<T>(), pageRequest);
    }

    /// <inheritdoc />
    public virtual async Task<T> AddElement(T entity)
    {
        try
        {
            var result = await Supabase.From<T>().Insert(entity);
            if (!result.ResponseMessage!.IsSuccessStatusCode)
                throw new DatabaseIudActionException("An error occurred while inserting the entity.");
            return result.Model!;
        }
        catch (Exception e)
        {
            DatabaseRepositroyHelper.HandleException(e, "inserting");
            return null!;
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
    ///     Executes a query on the specified table.
    /// </summary>
    /// <param name="query">The query to execute.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of entities.</returns>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    protected async Task<List<T>> ExecuteQuery(IPostgrestTable<T> query)
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
            return null!;
        }
    }


    /// <summary>
    ///     Executes a single query on the specified table.
    /// </summary>
    /// <param name="query">The query to execute.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a single entity.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
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
            return null!;
        }
    }

    /// <summary>
    ///     Executes a single query on the specified table.
    /// </summary>
    /// <param name="query">The query to execute.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a single entity.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the entity is not found in the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    public async Task<int> ExecuteCountQuery(IPostgrestTable<T> query, Constants.CountType countType)
    {
        try
        {
            var response = await query.Count(countType);

            return response;
        }
        catch (Exception ex)
        {
            DatabaseRepositroyHelper.HandleException(ex, "retrieving Count");
            return 0;
        }
    }

    /// <summary>
    ///     Executes a function on the database.
    /// </summary>
    /// <param name="nameOfFunction">The name of the function to execute.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the function.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the items could not be retrieved from the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    protected virtual async Task<object> ExecuteFunction(string nameOfFunction)
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
            return null!;
        }
    }

    /// <summary>
    ///     Executes a function on the database with parameters.
    /// </summary>
    /// <param name="nameOfFunction">The name of the function to execute.</param>
    /// <param name="parameters">The parameters to pass to the function.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the function.</returns>
    /// <exception cref="DatabaseMissingItemException">Thrown when the items could not be retrieved from the database.</exception>
    /// <exception cref="GeneralDatabaseException">Thrown when an unexpected error occurs.</exception>
    protected virtual async Task<object> ExecuteFunction(string nameOfFunction, Dictionary<string, object> parameters)
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
            return null!;
        }
    }

    /// <summary>
    ///     This method applies pagination to a query.
    /// </summary>
    /// <param name="queryBuilder">
    ///     A function that builds the needed query. This function needs to return a different
    ///     object on each invocation, otherwise the pagination will break!
    /// </param>
    /// <param name="pageRequest">The page request</param>
    /// <param name="totalElements">The total number of queried elements</param>
    /// <returns>The <see cref="IPage{T}" /> that corresponds to the given request</returns>
    /// <exception cref="DatabasePaginationFailedException">This exception will be thrown, when an error occurs during the Process of Applying the Pagination</exception>
    protected async Task<IPage<T>> ApplyPagination(Func<IPostgrestTable<T>> queryBuilder, PageRequest pageRequest)
    {
        try
        {
        var start = pageRequest.PageNumber * pageRequest.PageSize;
        var end = start + pageRequest.PageSize - 1;

        _logger.LogDebug($"Paginating query: Fetching entries {start}-{end}");
        
        var totalElements = await queryBuilder().Count(Constants.CountType.Exact);
        var content = await ExecuteQuery(queryBuilder().Range(start, end));

        return new PageImpl<T>(
            content,
            pageRequest.PageNumber,
            pageRequest.PageSize,
            (int)Math.Ceiling((double)totalElements / pageRequest.PageSize),
            pageNumber => ApplyPagination(queryBuilder, PageRequest.Of(pageNumber, pageRequest.PageSize)));
        }
        catch (Exception ex)
        {
            throw new DatabasePaginationFailedException($"An error occurred while paginating the query {queryBuilder}", ex);
        }

    }
}