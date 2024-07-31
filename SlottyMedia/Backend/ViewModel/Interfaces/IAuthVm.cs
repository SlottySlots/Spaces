using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

public interface IAuthVm
{
    public Task<Session?> RegisterAsync(string email, string password);
    public Task<Session?> LoginAsync(string email, string password);
    public Task<Session?> RestoreSessionAsync();
    public Task SaveSessionAsync(Session session);
    public Task LogoutAsync();
}