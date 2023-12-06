public class Logger
{
    private readonly string _logFileName;

    public Logger(string logFileName)
    {
        _logFileName = logFileName;
    }

    public void log(Exception ex) 
    {
        var entry =
        $@"[{DateTime.Now}]
        Execption message: {ex.Message}
        Stack trace: {ex.StackTrace}


        ";
        File.AppendAllText(_logFileName,entry);
    }
}