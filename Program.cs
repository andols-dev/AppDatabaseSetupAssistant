using AppDatabaseSetupAssistant;
using AppDatabaseSetupAssistant.Enums;

DatabaseType dbOption = DatabaseAssistant.GetDatabaseChoice();

Console.WriteLine("You have chosen to create a connection string for a " + dbOption + " database.");
string connectionString = DatabaseAssistant.CreateString(dbOption);
Console.WriteLine("connectionString: {0}", connectionString);