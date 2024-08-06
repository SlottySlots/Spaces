using System.Linq.Expressions;
using Supabase.Postgrest.Models;

namespace SlottyMedia.Database;

public interface IDatabaseActions
{
    public Task<T> Insert<T>(T item) where T : BaseModel, new();
    public Task<T> Update<T>(T item) where T : BaseModel, new();
    public Task<bool> Delete<T>(T item) where T : BaseModel, new();

    public Task<T?> GetEntityByField<T>(string field, string value) where T : BaseModel, new();

    public Task<T> GetEntitieWithSelectorById<T>(Expression<Func<T, object[]>> selector, string field, string value)
        where T : BaseModel, new();

    public Task<List<T>> GetEntitiesWithSelectorById<T>(Expression<Func<T, object[]>> selector, string field,
        string value) where T : BaseModel, new();
}