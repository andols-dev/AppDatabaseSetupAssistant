namespace AppDatabaseSetupAssistant;

public static class DatabaseAssistant
{
    public static string CreateString(string dbOption)
    {
        while (true)
        {
            Console.WriteLine(
                $"In order to create a connection string for a {dbOption} database you need to answer the following questions");

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

            string serverCertificate = GetYesNoInput("Do you want to add \"TrustServerCertificate=True\" (y/n)");
            string activeResultSets = GetYesNoInput("Do you want to add \"MultipleActiveResultSets=True\" (y/n)");
            string trustedConnection = GetYesNoInput("Do you want to add \"Trusted_Connection=True\" (y/n)");

            string trustCert = serverCertificate == "y" ? "TrustServerCertificate=True;" : "";
            string trustConn = trustedConnection == "y" ? "Trusted_Connection=True;" : "";
            string mars = activeResultSets == "y" ? "MultipleActiveResultSets=True;" : "";
            string connectionString = $"\"Server={serverName};Database={databaseName};{trustCert}{trustConn}{mars}\"";
            return connectionString;
        }

        static string GetYesNoInput(string prompt)
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
}