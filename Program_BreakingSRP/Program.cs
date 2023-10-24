
/*
 1- What is SRP = Single Responsibility Principle 
 2- What is SOLID  Principle
 3- How to read from and write to a text file
 4- How to add new files to a project
 5- How to move classes to their own files
 6- what namespaces are
 7- what using directives are
 */




using Program_BreakingSRP.DataAccess;


//var stopweatch = Stopwatch.StartNew();
//for (int i = 0; i < 1000; i++)
//{
//    Console.WriteLine($"Loop number{i}");
//}

//stopweatch.Stop();
//Console.WriteLine("Time in ms: " + stopweatch.ElapsedMilliseconds);

var names = new Names();
var path = new NamesFilePathBuilder().BuildFilePath();
var stringTextualRepository = new StringTextualRepository();
if (File.Exists(path))
{
    Console.WriteLine("Names file already exists. Loading names.");
    var stringFromFile = stringTextualRepository.Read(path);
    names.AddNames(stringFromFile);
}
else
{
    Console.WriteLine("Names file does not yet exist.");

    //let's imagine they are given by the user
    names.AddName("John");
    names.AddName("not a valid name");
    names.AddName("Claire");
    names.AddName("123 definitely not a valid name");

    Console.WriteLine("Saving names to the file.");
    stringTextualRepository.Write(path, names.ALL);
}
Console.WriteLine(new NamesFormatter().Format(names.ALL));

Console.ReadLine();
