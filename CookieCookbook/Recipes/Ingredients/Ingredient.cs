namespace CookieCookbook.Recipes.Ingredients;

public abstract class Ingredient  // An abstract class is a class that cannot be instantiated on its own and is meant to be subclassed by other classes. Abstract classes may contain abstract methods (methods without a body)
{
    public abstract int Id { get; }
    public abstract string Name { get; }
    public virtual string PreparationInstruction => // keyword is used to declare a virtual member in a base class that can be overridden in derived classes. In the context of a property, it means that a derived class can provide its own implementation for this property using the override keyword.
        "Add to other ingredients. ";

    public override string ToString() =>
        $"{Id}. {Name}";
}
