using SlottyMedia.Backend.Dtos;
using SlottyMedia.Components.Pages;

namespace SlottyMedia.Backend.ViewModel.Interfaces
{
    /// <summary>
    ///     This ViewModel represents the state of the Space Page.
    /// </summary>
    public interface ISpaceVm
    {
        /// <summary>
        /// Gets ForumDTO based on provided name
        /// </summary>
        /// <param name="name">
        /// Forumname to look up in db
        /// </param>
        /// <returns>
        /// ForumDto?
        /// </returns>
      
        public Task<ForumDto?> GetSpaceInformation(string name);

        /// <summary>
        ///     Fetches the details of a specific space based on its name
        ///     and populates the <see cref="Space" /> property.
        /// </summary>
        /// <param name="name">The name of the space to load information for.</param>
        public Task LoadSpaceDetails(string name);
        string Topic { get; }
        int PostCount { get; }
        DateTime CreatedAt { get; }
        /// <summary>
        /// Gets forums of a user by their id and enables slicing via offsets
        /// </summary>
        /// <param name="forumId">
        /// Forum that the posts belong to
        /// </param>
        /// <param name="startOfSet">
        /// Startindex of the posts sorted by date
        /// </param>
        /// <param name="endOfSet">
        /// Endindex of the posts sorted by data
        /// </param>
        /// <returns>
        /// List of PostDtos
        /// </returns>
        public Task<List<PostDto>> GetPostsByForumId(Guid forumId, int startOfSet, int endOfSet);
        
        
    }
}