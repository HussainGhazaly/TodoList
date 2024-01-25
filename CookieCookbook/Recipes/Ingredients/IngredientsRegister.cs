namespace CookieCookbook.Recipes.Ingredients;

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
        var allcountOfIngredientsWithGivenId = All
            .Where(ingredient => ingredient.Id == id);

        if(allcountOfIngredientsWithGivenId.Count() > 1)
        {
            throw new InvalidOperationException(
                $"More than one ingredients have ID  equal to {id}.");
        }

        if (All.Select(ingredient => ingredient.Id).Distinct().Count() != All.Count())
        {
            throw new InvalidOperationException(
                $"Some ingredients have Duplicaed ID.");
        }

        return allcountOfIngredientsWithGivenId.FirstOrDefault();
    } 
}
