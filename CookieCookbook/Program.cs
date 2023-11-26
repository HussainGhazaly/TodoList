


using CookieCookbook.Recipes;
using CookieCookbook.Recipes.Ingredients;
using System.Text.Json;

var ingredientsRegister = new IngredientsRegister();
var cookiesRecipesApp = new CookiesRecipesApp( new RecipesRepository(new StringJsonRepository(), ingredientsRegister) , new RecipesConsoleUserInteraction(ingredientsRegister));


cookiesRecipesApp.Run("recipes.json");



public class CookiesRecipesApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    /*
         Constructor to take Objectes from each class + to initialize them with values
         
        Dependency Inversion Princilpe -> (High-level modules should not depend on low level modules , Both should depend on abstraction (Interfaces) ) 
                                \Types should depend on abstractions, not a concrete types

         Dependency Injection -> means the class is given the Dependency it need, it dosen't create them itself 
          to pass the object using constructor data as this is interface we cannot pass data 
     */

    public CookiesRecipesApp(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run(string filePath)
    {
        // 1- Reading Recipes from file
        var allRecipes = _recipesRepository.Read(filePath);

        // 2- Printing Recipes
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        //// 3- Prompting "asking" the user to create the recipe.
        _recipesUserInteraction.PromptingToCreateRecipe();

        //// 4- Reading the ingredient form the user
        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        // check if the user selected any ingredients
        if (ingredients.Count() > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepository.write(filePath, allRecipes);

            _recipesUserInteraction.ShowMessage("Recipe added:");
            _recipesUserInteraction.ShowMessage(recipe.ToString());
        }
        else
        {
            _recipesUserInteraction.ShowMessage("No ingredients have been selected. " +
                "Recipe will not be save. ");
        }
        _recipesUserInteraction.Exit();
    }
}

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);  // pass any collection of recipies , even if array of recipies 
    void PromptingToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}

public interface IIngredientsRegister
{
    IEnumerable<Ingredient> All { get; }

    Ingredient GetById(int id);
}

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new SpeltFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder(),
    };

    public Ingredient GetById(int id)
    {
        foreach (var ingredient in All)
        {
            if (ingredient.Id == id)
            {
                return ingredient;
            }
        }
        return null;
    }
}

public class RecipesConsoleUserInteraction: IRecipesUserInteraction
{
    private readonly IIngredientsRegister _ingredientsRegister;
    public RecipesConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("Press any Key to close.");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are:" + Environment.NewLine);
            var counter = 1;
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"*****{counter}*****");
                Console.WriteLine(recipe);
                Console.WriteLine();
                ++counter;
            }
           
        }
    }

    public void PromptingToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe! " + "Available ingredients are:");
        foreach (var ingredient in _ingredientsRegister.All)
        {
            Console.WriteLine(ingredient);
        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool shallStop =false;
        var ingredients = new List<Ingredient>();

        while (!shallStop)
        {
            Console.WriteLine("Add an ingredient by its ID, " + "or type anything else if finished." );

            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int id))
            {
                var selectedIngredient = _ingredientsRegister.GetById(id);
                if (selectedIngredient is not null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else 
            { 
                shallStop = true;
            }
        }
        return ingredients;
    }
}

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
    void write(string filePath, List<Recipe> allRecipes);
}
public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string Separator = ",";

    public RecipesRepository(IStringsRepository stringsRepository, IIngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }
    public List<Recipe> Read(string filePath)
    {
        List<string> recipesFromFile = _stringsRepository.Read(filePath);
        var recipes = new List<Recipe>();

        foreach (var recipeFromFile in recipesFromFile)
        {
            var recipe = RecipeFromString(recipeFromFile);
            recipes.Add(recipe);
        }

        return recipes;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var textualIds = recipeFromFile.Split(Separator);
        var ingredients = new List<Ingredient>();


        foreach (var textualId in textualIds) 
        {
            var id = int.Parse(textualId);
            var ingredient = _ingredientsRegister.GetById(id);
            ingredients.Add(ingredient);

        }
        return new Recipe(ingredients);
    }

    public void write(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = new List<string>();
        foreach (var recipe in allRecipes) 
        {
          var allIds = new List<int>();
          foreach (var indgredient in recipe.Ingredients) 
          {
                allIds.Add(indgredient.Id);
          }
          recipesAsStrings.Add(string.Join(Separator, allIds));
        }
        _stringsRepository.Write(filePath, recipesAsStrings);
    }
}

public interface IStringsRepository
{
    List<string> Read(string filePath);
    void Write(string filePath, List<string> strings);
}

// Repositories class : will encapsulate (read / write) classes "logic required to access data source"
public class StringTextualRepository : IStringsRepository
{
    private static string Separator = Environment.NewLine; // static = no one can create instances from it , readonly = we do not want to modifiy it

    public List<string> Read(string filePath) // Read Names from text file , return list of strings
    {
        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath); // take file path and read the content in single strings
            return fileContents.Split(Separator).ToList(); // (split-method) the multi line string to single lines
        }
        return new List<string>();
    }

    public void Write(string filePath, List<string> strings) =>   // take a list of strings as a parameter
    File.WriteAllText(filePath, string.Join(Separator, strings)); // format the multi lines to single & then save it to a text file
}



public class StringJsonRepository : IStringsRepository
{

    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<string>>(fileContents);
        }
        return new List<string>();
    }

    public void Write(string filePath, List<string> strings) =>
    File.WriteAllText(filePath, JsonSerializer.Serialize(strings));
}