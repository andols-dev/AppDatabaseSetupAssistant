using AppDatabaseSetupAssistant;
using AppDatabaseSetupAssistant.Enums;
using Spectre.Console;

AnsiConsole.Write(
    new Rule("[bold cyan]Database Connection String Builder[/]")
        .RuleStyle("cyan"));
AnsiConsole.WriteLine();

DatabaseType dbOption = DatabaseAssistant.GetDatabaseChoice();
AnsiConsole.WriteLine();

AnsiConsole.MarkupLine($"[bold green]You have chosen:[/] [yellow]{dbOption}[/]");
AnsiConsole.MarkupLine("[bold cyan]Building connection string...[/]");
AnsiConsole.WriteLine();

string connectionString = DatabaseAssistant.CreateString(dbOption);
AnsiConsole.WriteLine();

AnsiConsole.Write(
    new Panel(connectionString)
        .Header("[bold green]Connection String[/]")
        .Border(BoxBorder.Rounded)
        .BorderStyle(Style.Parse("green"))
        .Expand()
        .Padding(1, 2));

AnsiConsole.WriteLine();
AnsiConsole.MarkupLine("[bold green]✓ Connection string generated successfully![/]");