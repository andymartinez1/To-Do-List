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
            Console.WriteLine ("Invalid option. Please try again.");
            break;
    }
}

void AddTodo()
{
    bool isInputValid = false;
    while (!isInputValid)
    {


        Console.WriteLine("Enter the TODO description:");
        string newTodo = Console.ReadLine();
        if (newTodo == "")
        {
            Console.WriteLine("The description cannot be empty");
        }
        else if (todoList.Contains(newTodo))
        {
            Console.WriteLine("TODO already exists.");
        }
        else
        {
            isInputValid = true;
            todoList.Add(newTodo);
            Console.WriteLine("TODO added successfully.");
        }
    }
}

void SeeAllTodos()
{
    if(todoList.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet");
    }
    else
    {
        for (int i = 0; i < todoList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {todoList[i]}");
        }
    }
}

void RemoveTodo()
{
    if(todoList.Count == 0)
    {
        Console.WriteLine("No TODOs to remove.");
        return;
    }

    bool isInputValid = false;
    while (!isInputValid)
    {
        Console.WriteLine("Select the TODO to remove: ");
        SeeAllTodos();
        var userInput = Console.ReadLine();
        if(userInput == "")
        {
            Console.WriteLine("You must select a valid TODO");
            continue;
        }
        if (int.TryParse(userInput, out int todoIndex) && todoIndex > 0 && todoIndex <= todoList.Count)
        {
            var indexOfTodo = todoIndex - 1;
            var todoToBeRemoved = todoList[indexOfTodo];
            todoList.RemoveAt(indexOfTodo);
            Console.WriteLine("TODO removed: " + todoToBeRemoved);
            isInputValid = true;
        }
        else
        {
            Console.WriteLine("Invalid selection. Please try again.");
        }
    }
}