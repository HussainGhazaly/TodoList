
//var pizza = new Pizza();
//pizza.AddIngredient(new Cheddar());
//pizza.AddIngredient(new Mozarella());
//pizza.AddIngredient(new Cheddar());

//Console.WriteLine(pizza.Describe());

var ingredient = new Ingredient();
ingredient.PublicField = 10;

var Cheddar = new Cheddar();
Cheddar.PublicField = 20;

Console.WriteLine("Value in Cheddar: " + Cheddar.PublicField);
Console.WriteLine("Value in Ingredient: " + ingredient.PublicField);

//Console.WriteLine(Cheddar.PublicMethod());
//Console.WriteLine(Cheddar.PrivateMethod());
//Console.WriteLine(Cheddar.ProtectedMethod());

Console.ReadKey();

public class Pizza
{
    private List<Ingredient> _ingredients = new List<Ingredient>();

    public void AddIngredient(Ingredient ingredient) =>
        _ingredients.Add(ingredient);

    public string Describe() =>
        $"This is a pizza with {string.Join("," , _ingredients)}";
}

public class Ingredient
{
    public int PublicField;

    public string PublicMethod() =>
         "This method is Public in the Ingredient class.";
    protected string ProtectedMethod() => // can be used in the drived classes + Base class , but not outside  
      "This method is Protected in the Ingredient class.";

    private string PrivateMethod() => // for Private : we can only use it inside the base class (No Drive ,No Outside)
        "This method is Private in the Ingredient class.";
}

public class Cheddar : Ingredient
{
    public string Name => "Cheddar cheese";
    public int AgedForMonths { get; }

    public void UseMethodsFromBaseClass()
    {
        Console.WriteLine(PublicMethod());
        Console.WriteLine(ProtectedMethod());
       // Console.WriteLine(PrivateMethod());
    }

}


public class TomatoSauce : Ingredient
{
    public string Name => "Tomato Sauce";
    public int TomatoIn100Grams { get; }
}


public class Mozarella : Ingredient
{
    public string Name => "Mozarella";
    public int IsLight { get; }
}
