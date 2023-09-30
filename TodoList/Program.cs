using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Channels;

/*
 * 
 * 
 * 
 * // Lec 56 - 60: TODO List Project 
 * 
 * 
 */


// we will use this (contains  & ADD methods & count  & removeAt) from list methods 
var todos = new List<string>();

Console.WriteLine("Hello!");

bool shallExit = false;
while (!shallExit)
{
    Console.WriteLine();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    var userChoice = Console.ReadLine();

    switch (userChoice)
    {

        case "E":
        case "e":
            shallExit = true;
            break;
        case "S":
        case "s":
            SeeAllTodos();
            break;
        case "A":
        case "a":
            AddTodo();
            break;
        case "R":
        case "r":
            RemoveTodo();
            break;
        default:
            Console.WriteLine("Invalid Choice");
            break;

    }
}
Console.ReadKey();





// 1) method to Display and see all todo
void SeeAllTodos()
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }

    for (int i = 0; i < todos.Count; i++)
    {
        // use string interpolation, to print index followed by a dot & then by todo description
        Console.WriteLine($"{i + 1}. {todos[i]}"); // print all todo list
    }




}

// 2) Method to Add a todo list 
void AddTodo()
{
    string description;
    do
    {
        Console.WriteLine("Enter the Todo desciption: ");
        description = Console.ReadLine();
    }
    while (!IsDescriptionValid(description));

    todos.Add(description);
}


// 3) Method to Remove a todo list ,
// note: list index start from 0 and count-1 , but her we are starting from 1

void RemoveTodo()
{

    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }

    int index; // loop until in dex unsuccessful 
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove");
        SeeAllTodos();
    } while (!TryReadIndex(out index));

    RemoveTodoAtIndex(index - 1);
}


// refactor to check if Description is Valid (  check if empty + check if the user enter same message)
bool IsDescriptionValid(string description)
{

    // check if the discription valid
    if (description == "") // check if empty " " 
    {
        Console.WriteLine("The description cannot be empty");
        return false;
    }
    if (todos.Contains(description)) // to put condition , check if the user enter same message
    {
        Console.WriteLine("The discrption must be uniqe. ");
        return false;
    }
    return true;
}

// refactor for reading the index that we want to remove it
bool TryReadIndex(out int index) // method to read the index
{
    var userInput = Console.ReadLine();
    if (userInput == "") // check if its empty
    {
        index = 0;
        Console.WriteLine("Selected index cannot be empty!");
        return false;
    }
    if (int.TryParse(userInput, out index) && index >= 1 && index <= todos.Count) //select valid index 
    {

        return true;
    }
    Console.WriteLine("the given index is not valid. ");
    return false;
}

// refactor for remove todo by index number
void RemoveTodoAtIndex(int index)
{
    var todoToBeRemoved = todos[index];
    todos.RemoveAt(index);
    Console.WriteLine("TODO removed: " + todoToBeRemoved);
}



// refactor for replacing "No To do Message"
static void ShowNoTodosMessage()
{
    Console.WriteLine("No todos have been added yet.");
}