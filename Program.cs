
// Console Application , .NET App Database setup assistant
// variables
string dbOption = "";
// Welcome message
Console.WriteLine("Welcome to the .Net App Database Setup assistant");
while (true)
{
    // Database options
    Console.WriteLine("Choose which database you like to connect to: MsSql (1), PostgresSql (2), Exit (q)");
    // user input
    string? dbOptionUserInput = Console.ReadLine()?.Trim();

    if (String.IsNullOrEmpty(dbOptionUserInput))
    {
        Console.WriteLine("Please enter a valid option: 1, 2 or q");
        continue;
    }

    if (dbOptionUserInput.ToLower() == "q")
    {
        Console.WriteLine("Exiting ...");
    }

    dbOption = dbOptionUserInput switch
    {
        "1" => "MsSql",
        "2" => "PostgresSql",
        _ => null
    };
    break;
}
Console.WriteLine($"Using {dbOption} in {dbOption}");