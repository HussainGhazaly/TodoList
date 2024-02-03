
using System.Text.Json;
using System.Text.Json.Serialization;

var baseAddress = "https://datausa.io/api/";
var requestUri = "data?drilldowns=Nation&measures=Population";

IApiDataReader apiDataReader = new ApiDataReader();
var jsion = await apiDataReader.Read(baseAddress, requestUri); // Cuz the method is Async, we need to add await 

var root = JsonSerializer.Deserialize<Root>(jsion);

foreach (var yearlyData in root.data)  // load data from public api
{
    Console.WriteLine($"Year: {yearlyData.Year}, "+
        $"population: {yearlyData.Population}" );
}

Console.ReadKey();

public interface IApiDataReader
{
    Task<string> Read(string baseAddress, string requestUri);
}

public class ApiDataReader : IApiDataReader
{

    public async Task<string> Read(string baseAddress, string requestUri)
    {

        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseAddress); //uri = Uniform Resource Identifier
        HttpResponseMessage response = await client.GetAsync(requestUri); // 1) HttpResponseMessage used to get the data form the jason
                                                                          // 2) providing the rest of the url
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();

    }
}


public record Annotations(
       [property: JsonPropertyName("source_name")] string source_name,
       [property: JsonPropertyName("source_description")] string source_description,
       [property: JsonPropertyName("dataset_name")] string dataset_name,
       [property: JsonPropertyName("dataset_link")] string dataset_link,
       [property: JsonPropertyName("table_id")] string table_id,
       [property: JsonPropertyName("topic")] string topic,
       [property: JsonPropertyName("subtopic")] string subtopic
   );

public record Datum(
    [property: JsonPropertyName("ID Nation")] string IDNation,
    [property: JsonPropertyName("Nation")] string Nation,
    [property: JsonPropertyName("ID Year")] int IDYear,
    [property: JsonPropertyName("Year")] string Year,
    [property: JsonPropertyName("Population")] int Population,
    [property: JsonPropertyName("Slug Nation")] string SlugNation
);

public record Root(
    [property: JsonPropertyName("data")] IReadOnlyList<Datum> data,
    [property: JsonPropertyName("source")] IReadOnlyList<Source> source
);

public record Source(
    [property: JsonPropertyName("measures")] IReadOnlyList<string> measures,
    [property: JsonPropertyName("annotations")] Annotations annotations,
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("substitutions")] IReadOnlyList<object> substitutions
);
