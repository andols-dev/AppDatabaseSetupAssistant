namespace AppDatabaseSetupAssistant;

using AppDatabaseSetupAssistant.Enums;

public static class DatabaseAssistant
{
    public static string CreateString(DatabaseType dbOption)
    {
        string connectionString = String.Empty;

        string? dbName = null;
        // choose a name for the database
        while (dbName == null)
        {
            Console.WriteLine("Choose a name for the database");
            dbName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(dbName))
            {
                Console.WriteLine("You need to choose a name for the database");
                dbName = null;  // Reset to null to repeat the loop
            }
        }

        switch (dbOption)
        {
            case DatabaseType.MsSql:
                connectionString = CreateMsSqlString(dbName);
                break;
            case DatabaseType.PostgresSql:
                connectionString = CreatePostgresString(dbName);
                break;

            default:
                Console.WriteLine("Invalid database option");
                break;

        }

        return connectionString;

    }

    private static string CreatePostgresString(string dbName)
    {
        string? connectionString = null;
        while (connectionString == null)
        {
            Console.WriteLine("Enter host (default: localhost), leave blank for default:");
            string? host = Console.ReadLine()?.Trim();
            if (String.IsNullOrWhiteSpace(host))
            {
                host = "localhost";
            }

            Console.WriteLine("Enter port (default: 5432), leave blank for default:");
            string? port = Console.ReadLine()?.Trim();
            if (String.IsNullOrWhiteSpace(port))
            {
                port = "5432";
            }

            Console.WriteLine("Enter username:");
            string? username = Console.ReadLine()?.Trim();

            Console.WriteLine("Enter password:");
            string? password = Console.ReadLine()?.Trim();

            connectionString = $"Host={host};Port={port};Database={dbName};Username={username};Password={password}";
        }

        return connectionString;
    }

    private static string CreateMsSqlString(string dbName)
    {
        string? connectionString = null;
        while (connectionString == null)
        {
            Console.WriteLine("Enter server (default: (localdb)\\mssqllocaldb), leave blank for default:");
            string? server = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(server))
            {
                server = "(localdb)\\mssqllocaldb";
            }

            string serverCertificate = GetYesNoInput("Do you want to add \"TrustServerCertificate=True\" (y/n)");
            string activeResultSets = GetYesNoInput("Do you want to add \"MultipleActiveResultSets=True\" (y/n)");
            string trustedConnection = GetYesNoInput("Do you want to add \"Trusted_Connection=True\" (y/n)");

            string trustCert = serverCertificate == "y" ? "TrustServerCertificate=True;" : "";
            string trustConn = trustedConnection == "y" ? "Trusted_Connection=True;" : "";
            string mars = activeResultSets == "y" ? "MultipleActiveResultSets=True;" : "";
            connectionString = $"\"Server={server};Database={dbName};{trustCert}{trustConn}{mars}\"";

        }

        return connectionString;
    }

    public static DatabaseType GetDatabaseChoice()
    {
        DatabaseType choice = DatabaseType.None;

        while (choice == DatabaseType.None)
        {
            Console.WriteLine($"Choose database option: (1) {DatabaseType.MsSql},(2) {DatabaseType.PostgresSql} ");

            var input = Console.ReadLine()?.Trim();

            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("You need to choose a valid database option");
                continue;
            }
            switch (input)
            {
                case "1":
                    choice = DatabaseType.MsSql;
                    break;
                case "2":
                    choice = DatabaseType.PostgresSql;
                    break;
                default:
                    Console.WriteLine("You need to choose a valid database option");
                    break;
            }
        }

        return choice;
    }
    private static string GetYesNoInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine()?.Trim();
            if (input?.ToLower() is "y" or "n")
                return input;
            Console.WriteLine("Please enter a valid option: y or n");
        }
    }
}