using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

public interface IAuthVm
{
    public Session? GetCurrentSession();
}