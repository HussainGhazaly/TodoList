

namespace CookieCookbook.FileAccess;

public static class FileFormatExtentions
{
    public static string AsFileExtension(this FileFormat fileFormat) =>
    fileFormat == FileFormat.Json ? "json" : "txt";
}
