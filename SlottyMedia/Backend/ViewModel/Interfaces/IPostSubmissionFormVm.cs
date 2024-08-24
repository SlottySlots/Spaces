using Microsoft.AspNetCore.Components;

namespace SlottyMedia.Backend.ViewModel.Interfaces;


/// <summary>
/// This ViewModel represents a form that is used to create a post.
/// It contains fields for the post's textual data and fields that
/// represent corresponding errors.
/// </summary>
public interface IPostSubmissionFormVm
{
    /// <summary>The post's textual content</summary>
    string? Text { get; set; }
    
    /// <summary>The prompt the user should input in order to select the space. This field is null if a space was selected.</summary>
    string? SpacePrompt { get; set; }
    
    /// <summary>The name of the space the user has selected. Null corresponds to no selection.</summary>
    string? SpaceName { get; set; }
    
    /// <summary>An optional error message related to the post's space</summary>
    string? SpaceErrorMessage { get; set; }
    
    /// <summary>An optional error message related to the post's textual content</summary>
    string? TextErrorMessage { get; set; }
    
    /// <summary>An optional error message that is caused by some internal server error</summary>
    string? ServerErrorMessage { get; set; }

    /// <summary>
    /// Handles an event that is triggered whenever the user changes the prompt to select a space.
    /// This updates the list of matching spaces in the tooltip above the prompt's input field.
    /// </summary>
    /// <param name="e">The input field's change event</param>
    /// <param name="promptValueChanged">A callback that is invoked asynchronously</param>
    Task HandleSpacePromptChange(ChangeEventArgs e, EventCallback<string?> promptValueChanged);

    /// <summary>
    /// Handles an event that is triggered when the user selects a space from the list of available spaces
    /// based on the entered prompt. This sets "SpacePrompt" to null and "SpaceName" to the selected space name.
    /// This method assumes that the provided space name is valid and does not check whether the provided space
    /// actually exists!
    /// </summary>
    /// <param name="spaceName">The name of the selected space (without hashtag!)</param>
    Task HandleSpaceSelection(string spaceName);

    /// <summary>
    /// Handles an event that is triggered when the currently selected space is deselected.
    /// This sets "SpaceName" to null.
    /// </summary>
    void HandleSpaceDeselection();

    /// <summary>
    /// Attempts to submit the form. If successful, the post was created.
    /// Otherwise, displays an appropriate error message regarding the submission's
    /// failure.
    /// </summary>
    Task SubmitForm();
}