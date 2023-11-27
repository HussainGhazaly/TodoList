namespace CookieCookbook.Recipes.Ingredients;

public abstract class Flour : Ingredient
{
    public override string PreparationInstruction =>
            $"Sieve. {base.PreparationInstruction}";
}
