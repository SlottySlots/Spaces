using Supabase.Postgrest.Models;

namespace SlottyMedia.Backend.Repositories.Impl;


/// <summary>
/// This class represents a repository where the managed entity is assignable from the type
/// <see cref="BaseModel"/>. This repository implements default CRUD methods specifically using
/// the Supabase API. This takes away a lot of clutter from implementing repositories.
/// The only method that still needs to be implemented is <c>IRepository::GetById</c>.
/// <seealso cref="IRepository{TEntity}"/>
/// </summary>
/// <typeparam name="TEntity">The Supabase entity that should be managed by this repository</typeparam>
public abstract class SupabaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseModel, new()
{
    /// <summary>The <see cref="Supabase.Client"/> which exposes the Supabase API</summary>
    protected readonly Supabase.Client Supabase;

    /// <summary>
    /// Instantiates a <see cref="SupabaseRepository{TEntity}"/> with the specified <see cref="Supabase.Client"/>.
    /// </summary>
    /// <param name="supabase">An object that exposes the Supabase API</param>
    protected SupabaseRepository(Supabase.Client supabase)
    {
        Supabase = supabase;
    }

    /// <inheritdoc />
    public abstract Task<TEntity?> GetById(Guid entityId);

    /// <inheritdoc />
    public virtual async Task<List<TEntity>> GetAll()
    {
        var query = await Supabase
            .From<TEntity>()
            .Get();
        
        // throw exception if any other http errors occur
        query.ResponseMessage?.EnsureSuccessStatusCode();
        
        // else: return entities
        return query.Models;
    }

    /// <inheritdoc />
    public virtual async Task Add(TEntity entity)
    {
        var query = await Supabase
            .From<TEntity>()
            .Insert(entity);
        
        // throw exception if any other http errors occur
        query.ResponseMessage?.EnsureSuccessStatusCode();
    }

    /// <inheritdoc />
    public virtual async Task Update(TEntity entity)
    {
        var query = await Supabase
            .From<TEntity>()
            .Update(entity);
        
        // throw exception if any other http errors occur
        query.ResponseMessage?.EnsureSuccessStatusCode();
    }

    /// <inheritdoc />
    public virtual async Task Delete(TEntity entity)
    {
        var query = await Supabase
            .From<TEntity>()
            .Delete(entity);
        
        // throw exception if any other http errors occur
        query.ResponseMessage?.EnsureSuccessStatusCode();
    }
}