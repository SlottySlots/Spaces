using Microsoft.AspNetCore.Components;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
///     The implementation of the search view model.
/// </summary>
public class SearchImpl : ISearchVm
{
    private readonly ISearchService _searchService;

    /// <summary>
    ///     The constructor of the search view model.
    /// </summary>
    /// <param name="searchService"></param>
    public SearchImpl(ISearchService searchService)
    {
        _searchService = searchService;
        SearchResults = new SearchDto();
    }

    /// <inheritdoc />
    public string? SearchPrompt { get; set; }

    ///inheritdoc />
    public SearchDto SearchResults { get; set; }

    /// <inheritdoc />
    public async Task GetSearchResults(ChangeEventArgs e, EventCallback<string?> promptValueChanged)
    {
        if (e.Value is not null)
        {
            var newValue = e.Value.ToString();
            SearchPrompt = newValue;
            await promptValueChanged.InvokeAsync(newValue);

            if (newValue is not null)
            {
                if (newValue.StartsWith("#"))
                    SearchResults = await _searchService.SearchByTopic(newValue, 1, 10);
                else if (newValue.StartsWith("@"))
                    SearchResults = await _searchService.SearchByUsername(newValue, 1, 10);
            }
        }
    }

    ///inheritdoc />
    public void ClearSearchResults()
    {
        SearchResults = new SearchDto();
        SearchPrompt = "";
    }
}