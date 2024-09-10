using Microsoft.AspNetCore.Components;
using SlottyMedia.Backend.Dtos;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     This Interface represents the viewmodel of the Search
/// </summary>
public interface ISearchVm
{
    /// <summary>
    ///     The prompt the user should input in order to search for a space or user
    /// </summary>
    public string? SearchPrompt { get; set; }

    /// <summary>
    ///     The search results
    /// </summary>
    public SearchDto SearchResults { get; set; }

    /// <summary>
    ///     This function searches for spaces or users based on the input of the user
    /// </summary>
    /// <param name="e"></param>
    /// <param name="promptValueChanged"></param>
    /// <returns></returns>
    public Task GetSearchResults(ChangeEventArgs e, EventCallback<string?> promptValueChanged);

    /// <summary>
    ///     This function clears the search results
    /// </summary>
    public void ClearSearchResults();
}