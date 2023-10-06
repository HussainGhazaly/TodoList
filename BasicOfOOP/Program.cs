
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

var rectangle1 = new Rectangle(5,10);  // create object from the constructor1
var calculator = new ShapeMeasurmentsCalculator(); // create object from the constructor2

Console.WriteLine("Width is " + rectangle1.Width);

//rectangle1.Width = 15; // using the setter , cannot be used outside the class as it is private

Console.WriteLine("height is " + rectangle1.GetHeight());
Console.WriteLine("Area is " + calculator.CalculateRectangleArea(rectangle1));
Console.WriteLine("Circumference is " + calculator.CalculateRectangleCircumference(rectangle1));


var rectangle2 = new Rectangle(6, 11);
Console.WriteLine();
Console.WriteLine("Width is " + rectangle2.Width);
Console.WriteLine("height is " + rectangle2.GetHeight());
Console.WriteLine("Area is " + calculator.CalculateRectangleArea(rectangle2));
Console.WriteLine("Circumference is " + calculator.CalculateRectangleCircumference(rectangle2));



Console.ReadKey();
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
 Lec = 77. Validation of constructor parameters
 Lec = 78. Readonly and const 
 Lec = 79. Limitations of fields. A need for properties
 Lec = 80. Properties
            {
                - What properties are
                - What a backing field of a property is
                - What accessors are
                - What is the differnces between fields & properties are
                - When we should use fields & properties 
            
            }

 */


//  No Semicolons in the CLass, also first letter of class name must be capital  
class Rectangle
{
    // A field is a variable that belongs to an Object of a class
    // if we did not use any access modifires , this means the defult is "private" is used
    //Note: Public field names start with ("W" Capital letter) , Private filed names start with ("_width/_height" underscore & lowercase letter) 

    const int NumberOfSides = 4;
    readonly int NumberOfSidesReadonly;
                                     // make the field read only 
                                     // read only field can only be assigned at the declaraction or in the constructor '
                                     // making the field readonly this means "Immutability"
                                     // Immutability: is that once a object is created , it will never be modified 
                                     // READONLY = we use readonly when we want a field never to change, after ithas been set in the constructor
                                     // Const = we use const for things with a constant value known at compilation time
                                     /***************/
                                     // 2) Const Modifier:
                                     //  --> const can be applied to both variables & fields, 
                                     //    those variables must be assigned at declaration and can never be modified afterward
                                                          

    /*
    Note we define a 'constructor' similar to a method 
    */
    public Rectangle(int width ,int height)
    {
        // will do validation - print  the warning - in case of negative numbers
        // will use "Nameof" experression to change multiple of names without forgetting anything
        // , it will return a string equal to te name of the given thing (nameof"") 

        NumberOfSidesReadonly = 4;
        _width = GetLenghtOrDefault(width, nameof(_width));
        _height = GetLenghtOrDefault(height, nameof(_height));


    }


    private int _width; // Private backing field for the Width property

    // Public property named Width with a getter and private setter
    public int Width
    {
        get // Getter: Allows you to retrieve the value of _width
        {
            return _width;
        }
        private set // Setter: Allows you to set the value of _width, but it's private
        {
            if (value > 10)
            {
                _width = value; // Only set _width if the value is greater than 10
            }
        }
    }


    private int _height;

    // Public method for getting the height value
    public int GetHeight() => _height;

    // Public method for setting the height value with validation
    public void SetHeight(int value)
    {
        if (value > 0)
        {
            _height = value;
        }
    }


    private int GetLenghtOrDefault(int Length, string name)
    {
        // Adding "Const" , as we will nver going to change this value , Note: we cannot use "const" with "Var"
        const int defailtValueIfNonPositive = 1;

        if (Length <= 0)
        {
            Console.WriteLine($"{name} must be a postive number. ");
            return defailtValueIfNonPositive;
        }
        return Length;
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
    public int CalculateRectangleCircumference(Rectangle rectangle) =>  2 * rectangle.Width + 2 * rectangle.GetHeight();
    
    
       

    // if defult/private : then we need to use them inside the class only
    // if Public : then we can use it outside the class 

    public int CalculateRectangleArea(Rectangle rectangle)
    {
        // Note: we cannot use Expression-bodied methods ,because it has multiple of lines of code
        Console.WriteLine("Calculating area"); // statement
        return rectangle.Width * rectangle.GetHeight(); // Exepression 
    }


}



