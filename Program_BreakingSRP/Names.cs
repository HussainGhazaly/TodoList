
public class Names // This Class is NOT SRP , and has 5 Responsibilities  - so we need to make 5 classes instead of one
{
    public List<string> ALL { get; } = new List<string>(); // store list of names
    private readonly NamesValidator _namesValidator = new NamesValidator();

    public void AddNames(List<string> stringFromFile)
    {
        foreach (var name in stringFromFile)
        {
            AddName(name);
        }
    }
    public void AddName(string name) // Add name metthod
    {
        if (_namesValidator.IsValid(name)) // this method checks if a given string is a valid name?, and add it to the list
        {
            ALL.Add(name);
        }
    }
}