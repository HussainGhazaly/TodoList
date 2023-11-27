namespace CookieCookbook.Recipes;

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
    void write(string filePath, List<Recipe> allRecipes);
}
