using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

public interface IRegisterVm
{
    public Task<Session?> RegisterAsync(string email, string password);
    public Session? GetCurrentSession();
}