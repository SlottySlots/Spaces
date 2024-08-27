using SlottyMedia.Database.Exceptions;
using Supabase.Postgrest.Interfaces;

namespace SlottyMedia.Database.Helper;

/// <summary>
///     This class provides helper methods for database repositories.
/// </summary>
public class DatabaseRepositroyHelper
{
    /// <summary>
    ///     This method handles exceptions that occur during database operations.
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="operation"></param>
    /// <exception cref="GeneralDatabaseException"></exception>
    /// <exception cref="DatabaseMissingItemException"></exception>
    internal void HandleException(Exception ex, string operation)
    {
        switch (ex)
        {
            case HttpRequestException _:
                throw new GeneralDatabaseException($"A network error occurred while {operation} the entity.", ex);
            case ArgumentNullException _:
                throw new GeneralDatabaseException($"A required argument was null while {operation} the entity.", ex);
            case InvalidOperationException _:
                throw new GeneralDatabaseException($"An invalid operation occurred while {operation} the entity.", ex);
            case TimeoutException _:
                throw new GeneralDatabaseException($"A timeout occurred while {operation} the entity.", ex);
            case TaskCanceledException _:
                throw new GeneralDatabaseException($"The task was canceled while {operation} the entity.", ex);
            case DatabaseMissingItemException _:
                throw new DatabaseMissingItemException("The entity was not found in the database.", ex);
            case DatabaseIudActionException _:
                throw new DatabaseIudActionException($"An error occurred while {operation} the entity.", ex);
            default:
                throw new GeneralDatabaseException($"An unexpected error occurred while {operation} the entity.", ex);
        }
    }
}