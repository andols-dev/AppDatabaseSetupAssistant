using AppDatabaseSetupAssistant;

Console.WriteLine("Welcome to the .Net App Database Setup assistant");
string? dbOption = GetDatabaseChoice();
if (dbOption == null)
{
    Console.WriteLine("Exiting ...");
    return;
}
Console.WriteLine($"Using {dbOption}");

if (dbOption == "MsSql")
{
    string connectionString = DatabaseAssistant.CreateString(dbOption);
    Console.WriteLine($"Generated connection string: {connectionString}");
}

static string GetDatabaseChoice()
{
    while (true)
    {
        Console.WriteLine("Choose which database you like to connect to: MsSql (1), PostgresSql (2), Exit (q)");
        string? dbOptionUserInput = Console.ReadLine()?.Trim();

        if (String.IsNullOrEmpty(dbOptionUserInput))
        {
            Console.WriteLine("Please enter a valid option: 1, 2 or q");
            continue;
        }

        if (dbOptionUserInput.ToLower() == "q")
        {
            return null; // Indicate exit
        }

        string? dbOption = dbOptionUserInput switch
        {
            "1" => "MsSql",
            "2" => "PostgresSql",
            _ => null
        };

        if (dbOption == null)
        {
            Console.WriteLine("Please enter a valid option: 1, 2 or q");
            continue;
        }
        return dbOption;
    }
}