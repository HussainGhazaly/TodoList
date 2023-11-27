namespace CookieCookbook.DataAccess;

//  we use abstract as the template base class , the in the drived class we will write each different implementation
public abstract class StringsRepository : IStringsRepository
{
    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath);
            return TextToStrings(fileContents);
        }
        return new List<string>();
    }

    //protected: so the drived classes can see it
    protected abstract List<string> TextToStrings(string fileContents); // abstract method, thedrive class will do it's implementation

    public void Write(string filePath, List<string> strings)
    {
        File.WriteAllText(filePath, StringsToText(strings));
    }

    protected abstract string StringsToText(List<string> strings);
}
