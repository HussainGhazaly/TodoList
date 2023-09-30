



// Create Dog objects
Dog dog1 = new Dog("Buddy", "Golden Retriever", 30.5);
Dog dog2 = new Dog("Fido", "Mixed Breed");

// Call the Describe method
Console.WriteLine(dog1.Describe());
Console.WriteLine(dog2.Describe());





Console.ReadKey();

public class Dog
{
    private string _name;
    private string _breed;
    private double _weight; // Change _weight to double

    public Dog(string name, string breed, double weight) // Change the parameter type to double
    {
        _name = name;
        _breed = breed;
        _weight = weight;
    }

    public Dog(string name, string breed) : this(name, "mixed-breed", 0) // Set a default weight of 0
    {

    }

    public string Describe()
    {
        return $"This dog named {_name}, with the breed {_breed}, " +
            $"and weight {_weight} kilograms, so it's a {DescribeSize()} dog.";
    }

    private string DescribeSize()
    {
        if (_weight < 5)
        {
            return "tiny";
        }

        if (_weight < 30)
        {
            return "medium";
        }
        return "large";
    }
}