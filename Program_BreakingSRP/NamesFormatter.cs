/*
 1- What is SRP = Single Responsibility Principle 
 2- What is SOLID  Principle
 3- How to read from and write to a text file
 4- How to add new files to a project
 5- How to move classes to their own files
 6- what namespaces are
 7- what using directives are
 */




class NamesFormatter
{
    public string Format(List<string> names)
    {
        return string.Join(Environment.NewLine, names);

    }
}
