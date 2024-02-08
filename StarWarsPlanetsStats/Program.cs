
using StarWarsPlanetsStats.ApiDataAccess;
using StarWarsPlanetsStats.DTOs;
using System.Text.Json;

try 
{
  await new StarWarsPlanetsStatsApp(new ApiDataReader(), new MockStarWarsApiDataReader()).Run();
}
catch(Exception ex)
{
    Console.WriteLine("An error occurred. " + "Exception message:" + ex.Message);
}


Console.WriteLine("Press any key to close. ");
Console.ReadKey();

public class StarWarsPlanetsStatsApp 
{
    private readonly IApiDataReader _apiDataReader;
    private readonly IApiDataReader _secondaryApiDataReader;

    public StarWarsPlanetsStatsApp(IApiDataReader apiDataReader, IApiDataReader secondaryApiDataReader)
    {
        _apiDataReader = apiDataReader;
        _secondaryApiDataReader = secondaryApiDataReader;
    }

    
    public async Task Run() 
    {

        string? json = null;

        try
        {
            // Dependency Inversion: Do not implement the class ,
            // Receive those Implementaions as the constructor parameters & not create them in the Run method

            // 1) Calling Read data online-class API
            json = await _apiDataReader.Read("https://swapi.dev/", "api/planets");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("API request was unsuccessful. "
                                + "Switching to mock data. "
                                + "Exception message: " + ex.Message);
        }
        if (json is null)
        {
            // 1) Calling Read data offline-class API
            json = await _secondaryApiDataReader.Read("https://swapi.dev/", "api/planets");
        }

        // 2) Deserialize this Data into C# Object
        var root = JsonSerializer.Deserialize<Root>(json);

        var planets = ToPlanets(root);
        foreach(var planet in planets)
        {
            Console.WriteLine(planet);
        }
        Console.WriteLine();
        Console.WriteLine("The statistics of which property would you " + "like to see?");
        Console.WriteLine("population");
        Console.WriteLine("diameter");
        Console.WriteLine("surface water");

        var userChoice = Console.ReadLine();

        if (userChoice == "population") 
        {
            ShowStatistics(planets, "population", planet => planet.Population);
        }

        else if (userChoice == "diameter")
        {
            ShowStatistics(planets, "diameter", planet => planet.Diameter);
        }

        else if (userChoice == "SurfaceWater")
        {
            ShowStatistics(planets, "SurfaceWater", planet => planet.SurfaceWater);
        }

        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    private void ShowStatistics(IEnumerable<Planet> planets, string propertyName, Func<Planet, int?> propertySelector)
    {
        var planetWithMaxPropertyValue = planets.MaxBy(propertySelector); // MaxBy : the whole Object of planet , Max: the max intger of population 
        Console.WriteLine($"Max {propertyName} is: " +
            $"{propertySelector(planetWithMaxPropertyValue)} " +
            $"planet: {planetWithMaxPropertyValue.Name}");

        var planetWithMinPropertyValue = planets.MinBy(propertySelector); // MinBy : the whole Object of planet , Max: the max intger of population 
        Console.WriteLine($"Min {propertyName} is: " +
            $"{propertySelector(planetWithMinPropertyValue)}) " +
            $"planet: {planetWithMinPropertyValue.Name} )");
    }

    private IEnumerable<Planet> ToPlanets(Root? root)
    {
       if (root is null) 
       {
            throw new ArgumentNullException(nameof(root)); 
       }
       
        var planets = new List<Planet>();
        foreach (var planetDto in root.results) 
        {
            Planet planet = (Planet)planetDto;
                planets.Add(planet);
        }
        return planets;
    }
}

public readonly record struct Planet
{
    public string Name { get; }
    public int Diameter { get; }
    public int? SurfaceWater { get; }
    public int? Population { get; }

    public Planet(

        string name,
        int dianeter,
        int? surfaceWater,
        int? population
        )
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        Name = name;
        Diameter = dianeter;
        SurfaceWater = surfaceWater;
        Population = population;
    }

    public static explicit operator Planet(Result planetDto)
    {
        var name = planetDto.name;
        var diameter = int.Parse(planetDto.diameter);

        int? population = planetDto.population.ToIntOrNull();
        int? surfaceWater = planetDto.surface_water.ToIntOrNull();

        return new Planet(name, diameter,surfaceWater, population);
    }
}

public static class StringExtensions
{
    public static int? ToIntOrNull(this string? input)
    {
        int? result = null;
        if (int.TryParse(input, out int resultParesed))
        {
            result = resultParesed;
        }
        return result;
    }
}