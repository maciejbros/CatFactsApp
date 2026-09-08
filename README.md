# Cat Facts

A simple C# console application that retrieves random cat facts from the [Cat Fact API](https://catfact.ninja/) and stores them locally in a text file.

The project was created as a demonstration of basic .NET development, Dependency Injection, HTTP communication, asynchronous programming, file handling, and clean code organization.

## Features

* Retrieve random cat facts from the Cat Fact API
* Display the fact and its length in the console
* Save retrieved facts to a local `.txt` file
* Store each fact on a separate line
* View the history of retrieved facts
* Display statistics based on saved facts
* Clear the entire history
* Handle API and application errors
* Exit the application using the `ESC` key

## Technologies

* C#
* .NET 8
* `HttpClient`
* `System.Text.Json`
* Dependency Injection
* Asynchronous programming with `async/await`
* File I/O
* Git / GitHub

## Project Structure

```text
CatFactsApp/
│
├── Models/
│   └── CatFact.cs
│
├── Services/
│   ├── ICatFactService.cs
│   ├── CatFactService.cs
│   ├── IFileService.cs
│   └── FileService.cs
│
├── Program.cs
├── README.md
└── .gitignore
```

### Models

`CatFact.cs` represents the data returned by the Cat Fact API.

### Services

`ICatFactService` and `CatFactService` are responsible for communicating with the external API.

`IFileService` and `FileService` handle storing, reading, and clearing the cat fact history.

Dependency Injection is used to provide the required services to the application.

## API

The application uses the following endpoint:

```text
https://catfact.ninja/fact
```

Example response:

```json
{
  "fact": "Baking chocolate is the most dangerous chocolate to your cat.",
  "length": 61
}
```

## Data Storage

Retrieved facts are stored locally in:

```text
Documents/catfacts.txt
```

The file is created automatically when the first fact is retrieved.

Each fact is stored on a separate line using `|` as a separator:

```text
Baking chocolate is the most dangerous chocolate to your cat. | 61
Cats sleep for around 13-16 hours a day. | 43
```

The `|` separator is used instead of a comma to avoid problems with facts that may contain commas.

## Application Controls

| Key     | Action                  |
| ------- | ----------------------- |
| `ENTER` | Retrieve a new cat fact |
| `H`     | Show history            |
| `S`     | Show statistics         |
| `C`     | Clear history           |
| `ESC`   | Exit the application    |

## Statistics

The application can calculate statistics based on the stored facts, including:

* Total number of facts
* Average fact length
* Shortest fact
* Longest fact

Example:

```text
      STATISTICS


Total facts:       10
Average length:    74.30
Shortest fact:     42
Longest fact:      128
```

## Error Handling

The application handles errors that may occur while communicating with the external API or working with the local file.

Errors are displayed in the console without terminating the application unexpectedly.

## Getting Started

There are two ways to run the application.

### Option 1 — Download the latest release

The easiest way to run the application is to download the latest release from the GitHub Releases page.

1. Open the **Releases** section of the repository.
2. Download the latest `CatFactsApp.exe`.
3. Run the executable.

A published self-contained version of the application can be run without installing the .NET 8 SDK.

> The application requires an internet connection to retrieve cat facts from the API.

### Option 2 — Run from source code

To run the application from source, you need:

* .NET 8 SDK
* Visual Studio 2022 or another IDE supporting .NET 8

Clone the repository:

```bash
git clone <repository-url>
```

Navigate to the project directory:

```bash
cd CatFactsApp
```

Run the application:

```bash
dotnet run
```

Alternatively, open the solution in Visual Studio and run the project using `Ctrl + F5` or `F5`.

## Dependency Injection

The application uses Microsoft's built-in Dependency Injection container.

Services are registered in `Program.cs`:

```csharp
services.AddHttpClient<ICatFactService, CatFactService>();
services.AddSingleton<IFileService, FileService>();
```

This allows the application to depend on abstractions (`ICatFactService` and `IFileService`) instead of concrete implementations.

It also makes the application easier to test, maintain, and extend.

## Asynchronous Programming

The application uses `async/await` for operations that involve I/O, including:

* HTTP requests
* Reading the history file
* Writing new facts to the file
* Clearing the history file

This prevents blocking the application while waiting for external operations to complete.

## Git and Version Control

The project is managed using Git and hosted on GitHub.

The repository contains the application source code, documentation, and project configuration.

Releases are used to provide ready-to-run versions of the application.

## License

This project was created for educational and recruitment purposes.
