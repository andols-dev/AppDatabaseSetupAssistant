# App Database Setup Assistant

A lightweight console application to generate database connection strings for Microsoft SQL Server and PostgreSQL. It uses Spectre.Console to provide an interactive prompt-based user experience, with validation and helpful defaults.

## Features

- Interactive selection of database type (MsSql, PostgresSql)
- Prompt-based input for connection parameters (server, database name, host, port, user, password)
- Optional MS SQL flags for TrustServerCertificate / MARS / Trusted_Connection
- Validated inputs for required fields and numeric port
- Outputs a properly formatted connection string

## Usage

1. Choose a database type (MsSql or PostgresSql).
2. Enter a database name when prompted.
3. Fill in additional settings:
   - MS SQL: server, optional TrustServerCertificate, MultipleActiveResultSets, Trusted_Connection
   - PostgreSQL: host, port, username, password
4. App prints the generated connection string inside an ANSI panel and indicates success.

### Example Flow (MS SQL)

```
Choose database option: MsSql
Choose a name for the database: exampledb
Enter server: (localdb)\mssqllocaldb
Add TrustServerCertificate=True? (y/n): y
Add MultipleActiveResultSets=True? (y/n): y
Add Trusted_Connection=True? (y/n): n
```

Output:

```
Server=(localdb)\mssqllocaldb;Database=exampledb;TrustServerCertificate=True;MultipleActiveResultSets=True;
```

### Example Flow (PostgreSQL)

```
Choose database option: PostgresSql
Choose a name for the database: exampledb
Enter host: localhost
Enter port: 5432
Enter username: myuser
Enter password: (hidden)
```

Output:

```
Host=localhost;Port=5432;Database=exampledb;Username=myuser;Password=<your-password>
```
