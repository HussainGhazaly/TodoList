
class NamesValidator
{

    public bool IsValid(string name) //function that checks whether a given string name is a valid
    {
        return
            name.Length >= 2 && 
            name.Length < 25 && 
            char.IsUpper(name[0]) && 
            name.All(char.IsLetter); 
    }
}
