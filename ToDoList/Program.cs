
using System;

var todoList = new List<string>();

Console.WriteLine("Hello!");


bool exitProgram = false;
while (!exitProgram)
{
    Console.WriteLine();
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd new TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");


    string userChoice = Console.ReadLine();
    Console.WriteLine();

    switch (userChoice)
    {
        case "s":
        case "S":
            SeeAllTodos();
            break;
        case "a":
        case "A":
            AddTodo();
            break;
        case "r":
        case "R":
            RemoveTodo();
            break;
        case "e":
        case "E":
            exitProgram = true;
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

void SeeAllTodos()
{
    if (todoList.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }
    for (int i = 0; i < todoList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todoList[i]}");
    }

}

void AddTodo()
{
    string description;
    do
    {
        Console.WriteLine("Enter the TODO description:");
        description = Console.ReadLine();


    } while (!IsDescriptionValid(description));

    todoList.Add(description);

}

bool IsDescriptionValid(string description)
{
    if (description == "")
    {
        Console.WriteLine("The description cannot be empty");
        return false;
    }
    else if (todoList.Contains(description))
    {
        Console.WriteLine("TODO already exists.");
        return false;
    }
    return true;
}

void RemoveTodo()
{
    if (todoList.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }

    int index;
    do
    {
        Console.WriteLine("Select the TODO to remove: ");
        SeeAllTodos();


    } while (!TryReadIndex(out index));

    RemoveTodoAtIndex(index - 1);
}

void RemoveTodoAtIndex(int index)
{
    var indexOfTodo = index - 1;
    var todoToRemove = todoList[index];
    todoList.RemoveAt(index);
    Console.WriteLine("TODO removed: " + todoToRemove);
}

bool TryReadIndex(out int index)
{
    var userInput = Console.ReadLine();
    if (userInput == "")
    {
        index = 0;
        Console.WriteLine("You must select a valid TODO");
        return false;
    }
    if (int.TryParse(userInput, out index) && index > 0 && index <= todoList.Count)
    {
        return true;
    }

    Console.WriteLine("Invalid selection. Please try again.");
    return false;
}

static void ShowNoTodosMessage()
{
    Console.WriteLine("No TODOs have been added yet");
}