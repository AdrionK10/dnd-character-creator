namespace CharacterCreator.Web;

public static class ImageDataUrl
{
    public static string FromBytes(byte[]? bytes)
    {
        if (bytes is null || bytes.Length == 0)
        {
            return string.Empty;
        }

        var mimeType = bytes.Length >= 4 && bytes[0] == 0x89 && bytes[1] == 0x50
            ? "image/png"
            : "image/jpeg";

        return $"data:{mimeType};base64,{Convert.ToBase64String(bytes)}";
    }
}
