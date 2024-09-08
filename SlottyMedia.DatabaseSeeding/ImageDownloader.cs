using System.Net.Http;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.DatabaseSeeding;

/// <summary>
///     This class is used to download and encode images.
/// </summary>
public class ImageDownloader
{
    private static readonly HttpClient Client = new ();

    private static readonly Logging<ImageDownloader> Logger = new();

    /// <summary>
    ///     This method downloads an image from a URL and encodes it to a base64 string.
    /// </summary>
    /// <param name="imageUrl">The URL where the img is placed</param>
    /// <returns></returns>
    internal static async Task<string> DownloadAndEncodeImage(string imageUrl)
    {
        try
        {
            var response = await Client.GetAsync(imageUrl);
            response.EnsureSuccessStatusCode();

            var imageArray = await response.Content.ReadAsByteArrayAsync();
            var base64ImageRepresentation = Convert.ToBase64String(imageArray);
            return base64ImageRepresentation;
        }
        catch (Exception e)
        {
            Logger.LogError(e, "Error while downloading and encoding image");
            return string.Empty;
        }
    }
}