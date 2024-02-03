namespace CsvDataAccess.NewSolution;

public class FastRow
{
    // OLD-Bad Ex on Object for all types   private Dictionary<string, object> _data;  
    

    // Dictionary that stores all Data as Objects, we will create a single dictionary for each data type
    private Dictionary<string, int> _intsdata = new(); 
    private Dictionary<string, bool> _boolsdata = new();
    private Dictionary<string, decimal> _decimaldata = new();
    private Dictionary<string, string> _stringdata = new();

    public void AssignCell(string columnName, bool value) 
    {
        _boolsdata[columnName] = value;
    }

    public void AssignCell(string columnName, int value)
    {
        _intsdata[columnName] = value;
    }
    public void AssignCell(string columnName, decimal value)
    {
        _decimaldata[columnName] = value;
    }
    public void AssignCell(string columnName, string value)
    {
        _stringdata[columnName] = value;
    }

    public object GetAtColumn(string columnName) // Check if the row  doesn't have a value for the given column, 
                                                // Return null in each dictionary
    {
        if (_boolsdata.ContainsKey(columnName)) 
        {
            return _boolsdata[columnName];
        }

        if (_intsdata.ContainsKey(columnName))
        {
            return _intsdata[columnName];
        }

        if (_decimaldata.ContainsKey(columnName))
        {
            return _decimaldata[columnName];
        }

        if (_stringdata.ContainsKey(columnName))
        {
            return _stringdata[columnName];
        }

        return null;
    }
}