Console.WriteLine("Hello!");
Console.WriteLine("What would you like to do?");
Console.WriteLine("[S]ee all TODOs");
Console.WriteLine("[A]dd new TODO");
Console.WriteLine("[R]emove a TODO");
Console.WriteLine("[E]xit");

string userChoice = Console.ReadLine();
Console.WriteLine("User input: " + userChoice);

if (userChoice == "S")
{
    PrintSelectedOption("See all TODOs");
}

else if (userChoice == "A")
{
    PrintSelectedOption("Add new TODO");
}

else if (userChoice == "R")
{
    PrintSelectedOption("Remove a TODO");
}

else if (userChoice == "E")
{
    PrintSelectedOption("Exit");
}

Console.ReadKey();

void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}