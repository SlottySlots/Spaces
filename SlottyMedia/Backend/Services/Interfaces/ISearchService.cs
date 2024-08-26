using SlottyMedia.Backend.Dtos;

namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
///     This interface is used to define the Search Service.
/// </summary>
public interface ISearchService
{
    public Task<SearchDto> SearchByUsername(string searchTerm, int page, int pagesize);
    
    public Task<SearchDto> SearchByTopic(string searchTerm , int page, int pagesize);

}