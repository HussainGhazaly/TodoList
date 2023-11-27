using CookieCookbook.Recipes.Ingredients;
using CookieCookbook.Recipes;


namespace CookieCookbook.App;

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);  // pass any collection of recipies , even if array of recipies 
    void PromptingToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}
