// Initializing a dictionary with values
Dictionary<string, List<float>> dictionaryOfBandsAndTheirNotes = new Dictionary<string, List<float>>
{
    { "Sleep Token", new List<float> { 10, 8.5f, 7 } },
    { "Gojira", new List<float> { 10, 10, 10 } },
    { "Rage Against the Machine", new List<float> { 10, 10, 10 } }
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
                EvaluateBand();
                break;
            case 4:
                ShowBandAverages();
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

void ShowBandAverages()
{
    Console.Clear();
    Console.WriteLine("\nBand Averages:\n");

    foreach (KeyValuePair<string, List<float>> kvp in dictionaryOfBandsAndTheirNotes)
    {
        List<float> notes = kvp.Value;
        string averageString = notes.Count > 0 ? kvp.Value.Average().ToString("F2") : "N/A";
        Console.WriteLine($"{kvp.Key}: {averageString}");
        Console.WriteLine("--------------------------------");
    }

    Console.Write("\nPress any key to return to the menu...");
    Console.ReadKey();
    Console.Clear();
    ShowMenu();
}
void EvaluateBand()
{
    Console.Clear();
    Console.WriteLine("\nWhich band would you like to evaluate?");
    for (int i = 0; i <dictionaryOfBandsAndTheirNotes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {dictionaryOfBandsAndTheirNotes.Keys.ElementAt(i)}");
    }
    Console.Write("Answer: ");
    string inputBandNumber = Console.ReadLine()!;

    bool isValidNumber = int.TryParse(inputBandNumber, out int bandNumber);
    if (isValidNumber)
    {
        int bandIndexNumber = bandNumber - 1;
        if (bandIndexNumber >= 0 && bandIndexNumber < dictionaryOfBandsAndTheirNotes.Count)
        {
            string bandName = dictionaryOfBandsAndTheirNotes.Keys.ElementAt(bandIndexNumber);
            
            string continueEvaluation = "y";

            // It's other looping statement.
            // We have to ensure that inside of it we have a way to break the loop.
            while (continueEvaluation == "y")
            {
                Console.Clear();
                Console.WriteLine("Evaluating {0}:", bandName);
                Console.Write("Insert a note for the band: ");
                string inputNote = Console.ReadLine()!;

                if (float.TryParse(inputNote, out float note))
                {
                    dictionaryOfBandsAndTheirNotes[bandName].Add(note);
                    Console.WriteLine("Note added successfully! Would you like to insert another note? y/n");
                    string continueEvaluatingInput = Console.ReadLine()!;
                    if (continueEvaluatingInput.ToLower().Equals("y"))
                    {
                        continueEvaluation = "y";
                    }
                    else
                    {
                        Console.WriteLine("Returning to menu...");
                        continueEvaluation = "n";
                    }
                }
                else
                {
                    Console.WriteLine("Invalid note. Returning to menu...");
                    continueEvaluation = "n";
                }
            }

        }
        else
        {
            Console.WriteLine("Invalid number. Returning to menu...");
        }
    }
    else
    {
        Console.WriteLine("Invalid option. Returning to menu...");
    }

    Thread.Sleep(2000);
    Console.Clear();
    ShowMenu();
}

void RecordBand()
{
    // Clearing console
    Console.Clear();
    Console.Write("\nEnter the band name: ");
    string bandName = Console.ReadLine()!;

    // Adding value to the list
    dictionaryOfBandsAndTheirNotes.Add(bandName, new List<float>());

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