namespace AppDatabaseSetupAssistant;

using AppDatabaseSetupAssistant.Enums;
using Spectre.Console;

public static class DatabaseAssistant
{
    public static string CreateString(DatabaseType dbOption)
    {
        string dbName = AnsiConsole.Prompt(
            new TextPrompt<string>("[bold cyan]Choose a name for the database:[/]")
                .PromptStyle("green")
                .Validate(input => string.IsNullOrWhiteSpace(input) ? ValidationResult.Error("[red]Database name cannot be empty[/]") : ValidationResult.Success()));

        string connectionString = String.Empty;

        switch (dbOption)
        {
            case DatabaseType.MsSql:
                connectionString = CreateMsSqlString(dbName);
                break;
            case DatabaseType.PostgresSql:
                connectionString = CreatePostgresString(dbName);
                break;

            default:
                AnsiConsole.MarkupLine("[red]Invalid database option[/]");
                break;

        }

        return connectionString;

    }

    private static string CreatePostgresString(string dbName)
    {
        string host = AnsiConsole.Prompt(
            new TextPrompt<string>("[bold cyan]Enter host:[/]")
                .PromptStyle("green")
                .DefaultValue("localhost"));

        string port = AnsiConsole.Prompt(
            new TextPrompt<string>("[bold cyan]Enter port:[/]")
                .PromptStyle("green")
                .DefaultValue("5432")
                .Validate(input => int.TryParse(input, out _) ? ValidationResult.Success() : ValidationResult.Error("[red]Port must be a valid number[/]")));

        string username = AnsiConsole.Prompt(
            new TextPrompt<string>("[bold cyan]Enter username:[/]")
                .PromptStyle("green")
                .Validate(input => string.IsNullOrWhiteSpace(input) ? ValidationResult.Error("[red]Username cannot be empty[/]") : ValidationResult.Success()));

        string password = AnsiConsole.Prompt(
            new TextPrompt<string>("[bold cyan]Enter password:[/]")
                .PromptStyle("green")
                .Validate(input => string.IsNullOrWhiteSpace(input) ? ValidationResult.Error("[red]Password cannot be empty[/]") : ValidationResult.Success())
                .Secret());

        string connectionString = $"Host={host};Port={port};Database={dbName};Username={username};Password={password}";

        return connectionString;
    }


    private static string CreateMsSqlString(string dbName)
    {
        string server = AnsiConsole.Prompt(
            new TextPrompt<string>("[bold cyan]Enter server:[/]")
                .PromptStyle("green")
                .DefaultValue("(localdb)\\mssqllocaldb"));

        bool trustServerCert = AnsiConsole.Confirm("[bold cyan]Add TrustServerCertificate=True?[/]", false);
        bool multipleActiveResultSets = AnsiConsole.Confirm("[bold cyan]Add MultipleActiveResultSets=True?[/]", false);
        bool trustedConnection = AnsiConsole.Confirm("[bold cyan]Add Trusted_Connection=True?[/]", false);

        string trustCert = trustServerCert ? "TrustServerCertificate=True;" : "";
        string mars = multipleActiveResultSets ? "MultipleActiveResultSets=True;" : "";
        string trustConn = trustedConnection ? "Trusted_Connection=True;" : "";
        string connectionString = $"Server={server};Database={dbName};{trustCert}{trustConn}{mars}";
        return connectionString;
    }

    public static DatabaseType GetDatabaseChoice()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<DatabaseType>()
                .Title("[bold cyan]Choose database option:[/]")
                .AddChoices(DatabaseType.MsSql, DatabaseType.PostgresSql)
                .HighlightStyle(new Style(foreground: Color.Yellow, decoration: Decoration.Bold)));
    }
}