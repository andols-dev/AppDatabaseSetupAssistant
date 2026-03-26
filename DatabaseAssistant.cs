namespace AppDatabaseSetupAssistant;

using AppDatabaseSetupAssistant.Enums;

public static class DatabaseAssistant
{
    public static void CreateString(DatabaseType dbOption)
    {
        string? connectionString = null;
        //postgres
        // "Host=localhost;Port=5432;Database=mydb;Username=postgres;Password=yourpassword"

        //mssql
        // "Server=(localdb)\\mssqllocaldb;Database=OneToManyDb;Trusted_Connection=True;MultipleActiveResultSets=true; TrustServerCertificate=True"
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






        /*         switch (dbOption)
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
         */
        //return connectionString;
        System.Console.WriteLine(("dbName: ", dbName));

    }

    private static string? CreatePostgresString(string? dbName)
    {
        throw new NotImplementedException();
    }

    private static string? CreateMsSqlString(string? dbName)
    {
        throw new NotImplementedException();
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