
using System.Text.Json;

bool isFileRead = false;
var fileContents= default(string);
do
{
    try
    {
        Console.WriteLine("Enter the name of the file you want to read:");
        var fileName = Console.ReadLine();

        fileContents = File.ReadAllText(fileName);
        isFileRead = true;
    }
    catch (ArgumentNullException ex)
    {
        Console.WriteLine("the file name cannot be null.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine("the file name cannot be empty.");
    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine("the file does not exist.");
    }
} while (!isFileRead);

var videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContents); // deserializing (converting JSON to objects).

if (videoGames.Count > 0) 
{
    Console.WriteLine();
    Console.WriteLine("Loaded games are: ");
    foreach (var videoGame in videoGames) 
    {
        Console.WriteLine(videoGame);
    }
}
else 
{
    Console.WriteLine("No games are present in the input file. ");
}

Console.ReadKey();

public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public decimal Rating { get; init; }

    public override string ToString() => $"{Title}, released in {ReleaseYear}, rating: {Rating}";
}
