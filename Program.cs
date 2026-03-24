// Console Application , .NET App Database setup assistant
// variables
using System.Runtime.CompilerServices;

string? dbOption = null;
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
        return;
    }

    dbOption = dbOptionUserInput switch
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
    break;
}
Console.WriteLine($"Using {dbOption}");

// Create connection string based on chosen option
// connection string
if (dbOption == "MsSql")
{
    Console.WriteLine($"In order to create a connection string for a {dbOption} database you need to answer the following questions");
    Console.WriteLine("What is the server name?");
    string? serverName = Console.ReadLine()?.Trim();
    Console.WriteLine($"Create the name for the database");
    string? databaseName = Console.ReadLine()?.Trim();
    Console.WriteLine("Do you want to add \"TrustServerCertificate=True\" (y/n)");
    string? serverCertificate = Console.ReadLine()?.Trim();
    Console.WriteLine("Do you want to add \"MultipleActiveResultSets=True\" (y/n)");
    string? activeResultSets = Console.ReadLine()?.Trim();
    Console.WriteLine("Do you want to add \"Trusted_Connection=True\" (y/n)");
    string? trustedConnection = Console.ReadLine()?.Trim();

    string trustCert = serverCertificate?.ToLower() == "y" ? "TrustServerCertificate=True;" : "";
    string trustConn = trustedConnection?.ToLower() == "y" ? "Trusted_Connection=True;" : "";
    string mars = activeResultSets?.ToLower() == "y" ? "MultipleActiveResultSets=True;" : "";
    string connectionString = $"\"Server={serverName};Database={databaseName};{trustCert}{trustConn}{mars}\"";
    Console.WriteLine($"Your connection string is: {connectionString}");
    Console.ReadLine();

}

else if (dbOption == "PostgresSql")
{
    Console.WriteLine($"In order to create a connection string for a {dbOption} database you need to answer the following questions");
    string? host = Console.ReadLine()?.Trim();
    Console.WriteLine($"Create the name for the database");
    string? databaseName = Console.ReadLine()?.Trim();
    string? username = Console.ReadLine()?.Trim();
    string? password = Console.ReadLine()?.Trim();
}