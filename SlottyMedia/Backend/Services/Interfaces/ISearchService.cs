namespace SlottyMedia.Backend.Services.Interfaces;

public interface ISearchService
{
    public Task<List<Guid?>> SearchByUsernameOrTopic(string searchTerm);
}