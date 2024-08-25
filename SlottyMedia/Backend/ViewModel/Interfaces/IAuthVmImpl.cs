using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

public interface IAuthVmImpl
{
    public Session? GetCurrentSession();
}