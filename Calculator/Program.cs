// See https://aka.ms/new-console-template for more information



/*
 * 
 * 1) Learn Code Refactoring
 * 2) Apply all the past Lectures (IF - FUNC - INTPARS )  
 * 3) how to transform a string to uppercase version
 * 4) Implement calculator APP
 * 
 */


Console.WriteLine("Hello");

Console.WriteLine("Input the first number: ");
var firstAsText = Console.ReadLine();
var number1 = int.Parse(firstAsText);


Console.WriteLine("Input the second number: ");
var secondAsText = Console.ReadLine();
var number2 = int.Parse(secondAsText);

Console.WriteLine("what " +
    "do you want to do? ");
Console.WriteLine("[A]dd numbers ");
Console.WriteLine("[S]ubtract numbers ");
Console.WriteLine("[M]ultiply numbers ");

var choice = Console.ReadLine();

if (EqualsCaseInsensitive(choice , "A") )
{

    var sum = number1 + number2 ;
    //Console.WriteLine(number1 + " + " + number2 + " = " + sum);

    PrintFinalEquation(number1 , number2 , sum, "+");
}
else if (EqualsCaseInsensitive(choice, "S"))
{

        var Difference = number1 - number2;
    //Console.WriteLine(number1 + " - " + number2 + " = " + Difference);

    PrintFinalEquation(number1, number2, Difference, "-");
    }
else if (EqualsCaseInsensitive(choice, "M"))
{

    var multiplied = number1 * number2;
    //Console.WriteLine(number1 + " * " + number2 + " = " + multiplied);

    PrintFinalEquation(number1, number2, multiplied, "*");
}
else
{
    Console.WriteLine("Invalid choice! ");
}


/// Note: TO use key C# words as Variables ==
/// "Add @ before the keyword"
/// 

// EX : "3 * 4 = 12"
void PrintFinalEquation (int number1 ,int number2 , int result , string @operator) {

    Console.WriteLine(number1 + " " + @operator + " " + number2 + " = " + result);
    
}

bool EqualsCaseInsensitive (string left , string right) { 

    // calling a built in method directly on a string (similar to "left.Length" )
    // Note ToUpper , will Transform both parameter to uppercase
    // & see if they are the same ("A" == "A")
    // to upper is an object of type string ( we will elarn this in CLASS OBJECT ORINTED LEC)

    return left.ToUpper() == right.ToUpper();

}



Console.WriteLine("press any key to close ");
Console.ReadKey();