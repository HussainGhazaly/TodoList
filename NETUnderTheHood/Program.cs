
const string path = @"C:\Users\HUM014\Downloads\sampleData.csv";

var data =new CsvReader().Read(path);

Console.ReadKey();

public class CsvReader
{

    public CsvData Read(string path)
    {

        using var streamReader = new StreamReader(path);

        const string Seprator = ",";
        var columns = streamReader.ReadLine().Split(Seprator);

        var rows = new List<string>();
        while (!streamReader.EndOfStream) 
        {
            var cellsInRow = streamReader.ReadLine().Split(Seprator);
            rows.Add(cellsInRow[0]);
        }

        return new CsvData(columns,rows);
    }

}

public class CsvData
{

    public string[] Columns { get; }
    public IEnumerable<string> Rows { get; }

    public CsvData(string[] columns, IEnumerable<string> rows)
    {
        Columns = columns;
        Rows = rows;
    }
}