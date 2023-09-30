
/*
 * 
 * 
 * Lec OOP New Chapter: 
 * 
 *     61. Section introduction
 *     62. The issues in our code. A need for Object-Oriented Programming
 *     63. Introduction to object-oriented programming
 *     64. Understanding OOP with the DateTime type
 * 
 */



// Date_Time = is a special method called " Constructor " 
var internationaPizzaDay23 = new DateTime(2023 ,2 ,9);  // we can Add , hour-min-sec

Console.WriteLine("Year is: "+ internationaPizzaDay23.Year);
Console.WriteLine("Month is: "+ internationaPizzaDay23.Month);
Console.WriteLine("Day is: "+ internationaPizzaDay23.Day);
Console.WriteLine("Day of the week: "+ internationaPizzaDay23.DayOfWeek);

/*
 * 
 */
 
var internationaPizzaDay24 = internationaPizzaDay23.AddYears(1);
Console.WriteLine();
Console.WriteLine("Year is: " + internationaPizzaDay24.Year);
Console.WriteLine("Month is: " + internationaPizzaDay24.Month);
Console.WriteLine("Day is: " + internationaPizzaDay24.Day);
Console.WriteLine("Day of the week: " + internationaPizzaDay24.DayOfWeek);

Console.ReadKey();


