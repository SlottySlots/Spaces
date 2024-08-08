using System.ComponentModel;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Database.Daos;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
///     This class represents the Counter ViewModel.
/// </summary>
public class CounterVm : ICounterVm, INotifyPropertyChanged
{
    private readonly IUserService _userService;
    private UserDao _user;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CounterVm" /> class. It creates a new UserDao object and sets the
    ///     UserService.
    /// </summary>
    /// <param name="userService">The user service to interact with the database.</param>
    /// <param name="user">A new UserDao object</param>
    public CounterVm(IUserService userService, UserDao user)
    {
        _user = user;
        _userService = userService;
    }

    /// <summary>
    ///     Gets or sets the User object. This object can be accessed by the View. When the User object changes, the View will
    ///     be notified.
    /// </summary>
    public UserDao User
    {
        get => _user;
        set
        {
            _user = value;
            OnPropertyChanged(nameof(User));
        }
    }

    /// <summary>
    ///     Gets a user by their ID.
    /// </summary>
    /// <param name="userId">The ID of the user to retrieve.</param>
    /// <returns></returns>
    public async Task GetUserById(string userId)
    {
        var user = await _userService.GetUserById(Guid.Parse(userId));
        if (user is not null)
        {
            User = user;
        }
        //TODO: Handle the case where the user is not found.    
    }

    /// <summary>
    ///     Event that is triggered when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    ///     This method is called when a property value changes, to notify the View.
    /// </summary>
    /// <param name="propertyName">The name of the property</param>
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}