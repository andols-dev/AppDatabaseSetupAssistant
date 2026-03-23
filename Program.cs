
// Console Application , .NET App Database setup assistant
// Welcome message
Console.WriteLine("Welcome to the .Net App Database Setup assistant"); 
// Database options
Console.WriteLine("Choose which database you like to connect to: MsSql (1), MySql (2), PostgresSql (3)");

string? dbNameUserInput = Console.ReadLine();

if (String.IsNullOrEmpty(dbNameUserInput))
{
    Console.WriteLine("Please enter a valid database option");
}