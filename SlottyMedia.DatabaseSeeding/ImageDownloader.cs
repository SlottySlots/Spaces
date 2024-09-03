using System.Net;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.DatabaseSeeding;

/// <summary>
///     This class is used to download and encode images.
/// </summary>
public class ImageDownloader
{
    private static readonly WebClient Client = new();

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
            await Client.DownloadFileTaskAsync(imageUrl, "temp.png");
            var imageArray = File.ReadAllBytes("temp.png");
            var base64ImageRepresentation = Convert.ToBase64String(imageArray);
            File.Delete("temp.png");
            return base64ImageRepresentation;
        }
        catch (Exception e)
        {
            Logger.LogError(e, "Error while downloading and encoding image");
            return string.Empty;
        }
    }
}