// Initializing a dictionary with values
Dictionary<string, List<double>> dictionaryOfBandsAndTheirNotes = new Dictionary<string, List<double>>
{
    { "Sleep Token", new List<double> { 10, 8.5, 7 } },
    { "Gojira", new List<double> { 10, 10, 10 } },
    { "Rage Against the Machine", new List<double> { 10, 10, 10 } }
};

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
    ShowWelcomeMessage();
    Console.WriteLine("\nType 1 to record a band");
    Console.WriteLine("Type 2 to show all bands");
    Console.WriteLine("Type 3 to evaluate a band");
    Console.WriteLine("Type 4 to show band evaluations");
    Console.WriteLine("Type -1 to exit");

    Console.Write("\nType your choice: ");

    // Receiving an input from the console
    string stringInputOption = Console.ReadLine()!;
    
    if (int.TryParse(stringInputOption, out int inputOption))
    {
        // One of the ways to format a string, it's named composite formatting
        Console.WriteLine("Choice made: {0}", inputOption);

        // Switch statement is good to use when we have many predefined options
        switch (inputOption)
        {
            case 1:
                RecordBand();
                break;
            case 2:
                ShowAllBands();
                break;
            case 3:
                Console.WriteLine("Evaluating a band...");
                break;
            case 4:
                Console.WriteLine("Showing band evaluations...");
                break;
            case -1:
                Console.WriteLine("Exiting the application...");
                break;
            default:
                Console.WriteLine("Invalid option. Please enter a valid number.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid option. Please enter a valid number.");
    }

}

void RecordBand()
{
    // Clearing console
    Console.Clear();
    Console.Write("\nEnter the band name: ");
    string bandName = Console.ReadLine()!;

    // Adding value to the list
    dictionaryOfBandsAndTheirNotes.Add(bandName, new List<double>());

    // Another way to format a string, it's called string interpolation
    Console.WriteLine($"Band {bandName} was added successfully");
    Thread.Sleep(2000);

    Console.Clear();
    ShowMenu();
}

void ShowAllBands()
{
    Console.Clear();
    Console.WriteLine("See all bands: \n");

    for (int i = 0; i < dictionaryOfBandsAndTheirNotes.Count; i++)
    {
        Console.WriteLine($"Band {i + 1}: { dictionaryOfBandsAndTheirNotes.Keys.ElementAt(i) }");
    }

    Console.Write("\nPress any key to continue... ");
    Console.ReadKey();
    Console.Clear();
    ShowMenu();
}