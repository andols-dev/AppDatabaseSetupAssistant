using AppDatabaseSetupAssistant;
using AppDatabaseSetupAssistant.Enums;

Console.WriteLine("Welcome to the .Net App Database Setup assistant");
DatabaseType? dbOption = DatabaseAssistant.GetDatabaseChoice();
if (dbOption == null)
{
    Console.WriteLine("Exiting ...");
    return;
}
Console.WriteLine($"Using {dbOption}");

if (dbOption == DatabaseType.MsSql)
{
    string connectionString = DatabaseAssistant.CreateString(dbOption.Value);
    Console.WriteLine($"Generated connection string: {connectionString}");
}


