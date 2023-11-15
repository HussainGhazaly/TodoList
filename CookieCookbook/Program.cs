


var cookiesRecipesApp = new CookiesRecipesApp( new RecipesRepository() , new RecipesConsoleUserInteraction());


cookiesRecipesApp.Run();



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

    public void Run()
    {
        // 1- Reading Recipes from file
        var allRecipes = _recipesRepository.Read(FilePath);

        // 2- Printing Recipes
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        // 3- Prompting "asking" the user to create the recipe.
        _recipesUserInteraction.PromptingToCreateRecipe();

        // 4- Reading the ingredient form the user
        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        // check if the user selected any ingredients
        if (ingredients.Count > 0)
        {
            var recipes = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepository.write(FilePath, allRecipes);
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
}

public class RecipesConsoleUserInteraction: IRecipesUserInteraction
{

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("Press any Key to close.");
        Console.ReadKey();
    }
}

public interface IRecipesRepository
{

}
public class RecipesRepository: IRecipesRepository
{
}