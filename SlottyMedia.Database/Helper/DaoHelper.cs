using Supabase.Postgrest.Attributes;

namespace SlottyMedia.Database.Helper;

/// <summary>
///     This class provides helper methods for DAOs.
/// </summary>
public class DaoHelper
{
    /// <summary>
    ///     This method returns the name of the primary key field of a DAO.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public string? GetPrimaryKeyField<T>() where T : class
    {
        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            var primaryKeyAttribute =
                property.GetCustomAttributes(typeof(PrimaryKeyAttribute), false)
                    .FirstOrDefault() as PrimaryKeyAttribute;
            if (primaryKeyAttribute != null) return primaryKeyAttribute.ColumnName;
        }

        return null;
    }
}