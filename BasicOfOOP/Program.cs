
/*
 * 
 *  Lec = 66. Our first class 
 * 
 */


// remember the constructor is a method used to instantiate object of a class
// we cannot do this " var rectangle1 = new Rectangle(5,10); " 
//  this constructor does not exist , we did't define any constructor 
// So ,we can only use the default paramerterless constructor , which is automatically created to
// us if we do not creat6e 

var rectangle1 = new Rectangle(5,10);
var calculator = new ShapeMeasurmentsCalculator();

Console.WriteLine("Width is " + rectangle1.Width);
Console.WriteLine("height is " + rectangle1.Height);
Console.WriteLine("Area is " + calculator.CalculateRectangleArea(rectangle1));
Console.WriteLine("Circumference is " + calculator.CalculateRectangleCircumference(rectangle1));


var rectangle2 = new Rectangle(6, 11);
Console.WriteLine();
Console.WriteLine("Width is " + rectangle2.Width);
Console.WriteLine("height is " + rectangle2.Height);
Console.WriteLine("Area is " + calculator.CalculateRectangleArea(rectangle2));
Console.WriteLine("Circumference is " + calculator.CalculateRectangleCircumference(rectangle2));


/*
 Code 
 */
//var numbers = new List<int> { 1, 2, 3 };
//Console.WriteLine("Count of element is " +  numbers.Count);


// count used to get the number of element in the list 
// we can get Data from "Public" class , But we  cannot Set values as it is "private" data & no one should access them 

// Note: to control "who can access componnents of a class we use acess modifires
// Group of Key words like (Public - Private - Protected)"




/*
 
 Lec = 70. Adding methods to classes
 */


//  No Semicolons in the CLass, also first letter of class name must be capital  
class Rectangle
{
    // A field is a variable that belongs to an Object of a class
    // if we did not use any access modifires , this means the defult is "private" is used
    //Note: Public field names start with ("W" Capital letter) , Private filed names start with ("_width/_height" underscore & lowercase letter) 

    public int Width;
    public int Height;


    //void DummyMethod() 
    //{
    //    // we can use them inside the class 
    //    Console.WriteLine("Width is " + width);
    //    Console.WriteLine("height is " +height);

    //}


    /*
    Note we define a 'constructor' similar to a method 
    */
    public Rectangle(int width ,int height)
    {
        Width = width;
        Height = height;
    }



}




/*
 
    Lec: 71. Encapsulation
        // is to make all (variable & method) in one class 
        // Encapsulation: Bundling data with methods that operate on it in the same class
        // Data hiding: Making fields private , instead of public
 */


class ShapeMeasurmentsCalculator
{
    // LEC : 74. Expression-bodied methods ( 1) Remove the "return" & " brackets" , 2) Add " => " Arrows and follow it with what you want to return)
    public int CalculateRectangleCircumference(Rectangle rectangle) =>  2 * rectangle.Width + 2 * rectangle.Height;
    
    
       

    // if defult/private : then we need to use them inside the class only
    // if Public : then we can use it outside the class 

    public int CalculateRectangleArea(Rectangle rectangle)
    {
        // Note: we cannot use Expression-bodied methods ,because it has multiple of lines of code
        Console.WriteLine("Calculating area"); // statement
        return rectangle.Width * rectangle.Height; // Exepression 
    }


}



