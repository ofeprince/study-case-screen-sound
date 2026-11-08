// Calling a method
ShowWelcomeMessage();
ShowMenu();

// A void method: void doesn't return any value
void ShowWelcomeMessage()
{
    // Initializing a string variable
    string welcomeMessage = "Welcome to Screen Sound!";

    // Writing to the console
    Console.WriteLine("\n**********************");
    Console.WriteLine(welcomeMessage);
    Console.WriteLine("**********************");
}

void ShowMenu()
{
    // Press 4 
    Console.WriteLine("\nType 1 to record a band");
    Console.WriteLine("Type 2 to show all bands");
    Console.WriteLine("Type 3 to evaluate a band");
    Console.WriteLine("Type 4 to show band evaluations");
    Console.WriteLine("Type -1 to exit");
}