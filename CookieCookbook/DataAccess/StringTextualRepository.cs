namespace CookieCookbook.DataAccess;

// Repositories class : will encapsulate (read / write) classes "logic required to access data source"
public class StringTextualRepository : StringsRepository
{
    private static string Separator = Environment.NewLine; // static = no one can create instances from it , readonly = we do not want to modifiy it

    protected override string StringsToText(List<string> strings) //write
    {
        return string.Join(Separator, strings);
    }

    protected override List<string> TextToStrings(string fileContents) //read
    {
        return fileContents.Split(Separator).ToList(); // (split-method) the multi line string to single lines
    }
}
