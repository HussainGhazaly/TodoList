


using CookieCookbook.Recipes;
using CookieCookbook.Recipes.Ingredients;
using System.Threading.Channels;

var cookiesRecipesApp = new CookiesRecipesApp( new RecipesRepository() , new RecipesConsoleUserInteraction(new IngredientsRegister()));


cookiesRecipesApp.Run("recipes.txt");



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
            //_recipesRepository.write(FilePath, allRecipes);

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

public class IngredientsRegister
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
    private readonly IngredientsRegister _ingredientsRegister;
    public RecipesConsoleUserInteraction(IngredientsRegister ingredientsRegister)
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
}
public class RecipesRepository : IRecipesRepository
{
    public List<Recipe> Read(string filePath)
    {
        return new List<Recipe>
        {
            new Recipe(new List<Ingredient>
            {
                new WheatFlour(),
                new Butter(),
                new Sugar()
            }),
            new Recipe(new List<Ingredient>
            {
                new CocoaPowder(),
                new SpeltFlour(),
                new Cinnamon()
            })


        };

    }
}