/*
 1- What is SRP = Single Responsibility Principle 
 2- What is SOLID  Principle
 3- How to read from and write to a text file
 4- How to add new files to a project
 5- How to move classes to their own files
 6- what namespaces are
 7- what using directives are
 */




class NamesFilePathBuilder
{
    public string BuildFilePath()
    {
        //we could imagine this is much more complicated
        //for example that path is provided by the user and validated
        return "names.txt";
    }
}
