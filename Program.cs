// Console Application , .NET App Database setup assistant
// variables

// Welcome message
Console.WriteLine("Welcome to the .Net App Database Setup assistant");
string? dbOption = GetDatabaseChoice();
if (dbOption == null)
{
    Console.WriteLine("Exiting ...");
    return;
}
Console.WriteLine($"Using {dbOption}");

// Create connection string based on chosen option
// connection string
if (dbOption == "MsSql")
{
    while (true)
    {
        Console.WriteLine($"In order to create a connection string for a {dbOption} database you need to answer the following questions");

        Console.WriteLine("What do you want to name the connection string?");
        string? connString = Console.ReadLine()?.Trim();
        if (String.IsNullOrEmpty(connString))
        {
            Console.WriteLine("Please enter a valid connection string");
            continue;
        }

        Console.WriteLine("What is the server name?");
        string? serverName = Console.ReadLine()?.Trim();

        if (String.IsNullOrEmpty(serverName))
        {
            Console.WriteLine("Please enter a valid server name");
            continue;
        }
        Console.WriteLine($"Create the name for the database");
        string? databaseName = Console.ReadLine()?.Trim();
        if (String.IsNullOrEmpty(databaseName))
        {
            Console.WriteLine("Please enter a valid database name");
            continue;
        }
        Console.WriteLine("Do you want to add \"TrustServerCertificate=True\" (y/n)");
        string? serverCertificate = Console.ReadLine()?.Trim();
        if (String.IsNullOrEmpty(serverCertificate))
        {
            Console.WriteLine("Please enter a valid option: y or n");
            continue;
        }
        Console.WriteLine("Do you want to add \"MultipleActiveResultSets=True\" (y/n)");
        string? activeResultSets = Console.ReadLine()?.Trim();
        if (String.IsNullOrEmpty(activeResultSets))
        {
            Console.WriteLine("Please enter a valid option: y or n");
            continue;
        }
        Console.WriteLine("Do you want to add \"Trusted_Connection=True\" (y/n)");
        string? trustedConnection = Console.ReadLine()?.Trim();
        if (String.IsNullOrEmpty(trustedConnection))
        {
            Console.WriteLine("Please enter a valid option: y or n");
            continue;
        }

        string trustCert = serverCertificate?.ToLower() == "y" ? "TrustServerCertificate=True;" : "";
        string trustConn = trustedConnection?.ToLower() == "y" ? "Trusted_Connection=True;" : "";
        string mars = activeResultSets?.ToLower() == "y" ? "MultipleActiveResultSets=True;" : "";
        string connectionString = $"\"Server={serverName};Database={databaseName};{trustCert}{trustConn}{mars}\"";
        Console.WriteLine($"Your connection string is: {connectionString}");
        break;
    }

}


static string GetDatabaseChoice()
{
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



// implementation for PostgresSql can be added here
/* else if (dbOption == "PostgresSql")
{
    Console.WriteLine($"In order to create a connection string for a {dbOption} database you need to answer the following questions");
    string? host = Console.ReadLine()?.Trim();
    Console.WriteLine($"Create the name for the database");
    string? databaseName = Console.ReadLine()?.Trim();
    string? username = Console.ReadLine()?.Trim();
    string? password = Console.ReadLine()?.Trim();
} */