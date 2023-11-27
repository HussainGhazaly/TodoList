

using System.Text.Json;

namespace CookieCookbook.DataAccess;

public class StringJsonRepository : StringsRepository
{
    protected override string StringsToText(List<string> strings) //write
    {
        return JsonSerializer.Serialize(strings);
    }

    protected override List<string> TextToStrings(string fileContents) //read
    {
        return JsonSerializer.Deserialize<List<string>>(fileContents);
    }
}
