using Supabase.Postgrest.Models;

namespace SlottyMedia.Database.Models;

public abstract class BaseDto : BaseModel
{
    protected IDatabaseActions DatabaseActions;

    protected BaseDto()
    {
        
    }
    
    protected BaseDto(IDatabaseActions databaseActions)
    {
        DatabaseActions = databaseActions;
    }

    public async Task<T> Insert<T>(T item) where T : BaseModel, new()
    {
        return await DatabaseActions.Insert(item);
    }
    
    public async Task<T> Update<T>(T item) where T : BaseModel, new()
    {
        return await DatabaseActions.Update(item);
    }
    
    public async Task<bool> Delete<T>(T item) where T : BaseModel, new()
    {
        return await DatabaseActions.Delete(item);
    }
    
    public async Task<T?> GetEntityByField<T>(string field, string value) where T : BaseModel, new()
    {
        return await DatabaseActions.GetEntityByField<T>(field, value);
    }
}