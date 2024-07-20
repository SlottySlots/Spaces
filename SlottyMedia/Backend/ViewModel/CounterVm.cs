using System.ComponentModel;
using SlottyMedia.Backend.Interfaces;
using SlottyMedia.Backend.Models;

namespace SlottyMedia.Backend.ViewModel;

public class CounterVm : INotifyPropertyChanged
{
    private UserDto _user;
    private readonly IUserService _userService;
    public event PropertyChangedEventHandler PropertyChanged;

    public CounterVm(IUserService userService)
    {
        _userService = userService;
    }
    
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public UserDto User
    {
        get => _user;
        set
        {
            _user = value;
            OnPropertyChanged(nameof(User));
        }
    }
    
    public async Task GetUserById(string userId)
    {
        User = await _userService.GetUserById(userId);
    }
}