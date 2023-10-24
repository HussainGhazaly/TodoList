
namespace Program_BreakingSRP.DataAccess;

// Repositories class : will encapsulate (read / write) classes "logic required to access data source"
class StringTextualRepository
{
    private static string Separator = Environment.NewLine; // static = no one can create instances from it , readonly = we do not want to modifiy it

    public List<string> Read(string filePath) // Read Names from text file , return list of strings
    {
        Console.WriteLine("Reading a file");
        var fileContents = File.ReadAllText(filePath); // take file path and read the content in single strings
        return fileContents.Split(Separator).ToList(); // (split-method) the multi line string to single lines

    }

    public void Write(string filePath, List<string> strings) =>   // take a list of strings as a parameter
        File.WriteAllText(filePath, string.Join(Separator, strings)); // format the multi lines to single & then save it to a text file



}
