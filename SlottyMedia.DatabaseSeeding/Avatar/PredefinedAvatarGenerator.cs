namespace SlottyMedia.DatabaseSeeding.Avatar;

public class PredefinedAvatarGenerator : IAvatarGenerator
{
    private const int NumOfPics = 5;

    private static string GetImagePath()
    {
        return Directory.GetCurrentDirectory() + "/wwwroot/static/avatars/";
    }
    
    public string RandomAvatarB64()
    {
        var index = new Random().Next(0, NumOfPics);
        var bytes = File.ReadAllBytes(GetImagePath() + index + ".png");
        return Convert.ToBase64String(bytes);
    }
}