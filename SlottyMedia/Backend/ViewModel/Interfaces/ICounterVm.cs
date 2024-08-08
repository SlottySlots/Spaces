using SlottyMedia.Database.Daos;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     This interface represents the CounterVm class.
/// </summary>
public interface ICounterVm
{
    /// <summary>
    ///     This is the User Object which can be accessed by the View.
    /// </summary>
    public UserDao User { get; set; }

    /// <summary>
    ///     This Method gets a user by their ID.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public Task GetUserById(string userId);
}