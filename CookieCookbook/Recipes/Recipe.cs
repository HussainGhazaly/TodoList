using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook.Recipes;

public class Recipe
{
    // Note: we don't want the list to be public , so any one can clear all items! -> use IEnumerable "as IEnumerable dosen't have any methods like ex: clear , that modified "
    public IEnumerable<Ingredient> Ingredients { get; } // property (reading a collection of ingredient)

    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients; // constructor
    }

    public override string ToString()
    {
        var steps = new List<string>();
        foreach(var ingredient in Ingredients)
        {
            steps.Add($"{ingredient.Name}. {ingredient.PreparationInstruction}");
        }
        return string.Join(Environment.NewLine, steps);
    }
}
