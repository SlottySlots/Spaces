# ImageDownloader

Namespace: SlottyMedia.DatabaseSeeding

This class is used to download and encode images.

```csharp
public class ImageDownloader
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ImageDownloader](./slottymedia.databaseseeding.imagedownloader.md)

## Constructors

### **ImageDownloader()**

```csharp
public ImageDownloader()
```

## Methods

### **DownloadAndEncodeImage(String)**

This method downloads an image from a URL and encodes it to a base64 string.

```csharp
public static Task<string> DownloadAndEncodeImage(string imageUrl)
```

#### Parameters

`imageUrl` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The URL where the img is placed

#### Returns

[Task&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
