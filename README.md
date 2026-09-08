# Cat Facts App

A .NET 8 console application that retrieves random cat facts from the Cat Fact API and stores them locally in a text file.

## Features

* Retrieve random cat facts from the Cat Fact API
* Display the fact and its character length
* Save every retrieved fact locally
* View previously saved facts
* Display statistics based on saved facts
* Clear saved history with confirmation
* Dependency Injection
* Asynchronous programming with `async`/`await`
* Error handling
* Version control with Git

## Technologies

* C#
* .NET 8
* Console Application
* `HttpClient`
* `System.Net.Http.Json`
* Microsoft.Extensions.DependencyInjection
* Git / GitHub

## Project Structure

```text
CatFactsApp
│
├── Models
│   └── CatFact.cs
│
├── Services
│   ├── Interfaces
│   │   ├── ICatFactService.cs
│   │   └── IFileService.cs
│   │
│   ├── CatFactService.cs
│   └── FileService.cs
│
├── UI
│   ├── ConsoleUI.cs
│   └── ConsoleConstants.cs
│
├── Program.cs
├── README.md
└── .gitignore
```

### Models

`CatFact.cs` represents the data returned by the Cat Fact API.

It contains:

* `Fact` - the cat fact text
* `Length` - the length of the fact

### Services

The application logic is separated into dedicated services.

#### `CatFactService`

Responsible for communicating with the Cat Fact API and retrieving cat facts.

#### `FileService`

Responsible for local data storage:

* Appending new facts to the history file
* Reading saved facts
* Clearing the history

### Interfaces

The service interfaces are placed in a separate `Services/Interfaces` folder.

* `ICatFactService` defines the contract for retrieving cat facts
* `IFileService` defines the contract for managing the local history

Using interfaces allows the application to depend on abstractions instead of concrete implementations and makes the services easier to replace or test.

### UI

`ConsoleUI` contains the application's user interface and menu logic.

`ConsoleConstants` contains shared UI text and application constants, keeping hard-coded strings out of the main UI logic.

### Program.cs

`Program.cs` is responsible only for configuring Dependency Injection and starting the application.

The application logic and UI methods are handled by `ConsoleUI`.

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

Each request appends a new line to the file.

The stored format is:

```text
Fact text | Length
```

The `|` character is used as the separator and is defined as a constant in `ConsoleConstants`.

## Controls

| Key     | Action             |
| ------- | ------------------ |
| `ENTER` | Get a new cat fact |
| `H`     | Show history       |
| `S`     | Show statistics    |
| `C`     | Clear history      |
| `ESC`   | Exit               |

## Statistics

The statistics view displays:

* Total number of saved facts
* Average fact length
* Shortest fact
* Longest fact

Statistics are calculated from the locally stored history.

## Dependency Injection

The application uses Microsoft's built-in Dependency Injection container.

Services are registered in `Program.cs`:

```csharp
services.AddHttpClient<ICatFactService, CatFactService>();
services.AddSingleton<IFileService, FileService>();
services.AddSingleton<ConsoleUI>();
```

`ConsoleUI` receives its dependencies through constructor injection:

```csharp
public ConsoleUI(
    ICatFactService catFactService,
    IFileService fileService)
{
    _catFactService = catFactService;
    _fileService = fileService;
}
```

This keeps the classes loosely coupled and makes the application easier to maintain and test.

## Asynchronous Programming

The application uses asynchronous methods for operations that involve I/O, including:

* HTTP requests
* Reading the history file
* Writing to the history file

This is implemented using `async`/`await`.

## Error Handling

API and file operations are handled using exception handling so that unexpected errors do not terminate the application without an explanation.

Errors are displayed directly in the console.

## Getting Started

### Option 1 - Download the latest release

The easiest way to run the application is to download the latest release from GitHub.

The published Windows executable is self-contained, so the .NET 8 SDK is not required.

1. Go to the [Releases](https://github.com/maciejbros/CatFactsApp/releases) page.
2. Download `CatFactsApp.exe`.
3. Run the executable.

### Option 2 - Run from source

Requirements:

* .NET 8 SDK
* Visual Studio 2022 or another compatible .NET development environment

Clone the repository:

```bash
git clone https://github.com/maciejbros/CatFactsApp.git
```

Navigate to the project:

```bash
cd CatFactsApp
```

Run the application:

```bash
dotnet run
```

## Version Control

The project is managed using Git and hosted on GitHub.

Repository:

https://github.com/maciejbros/CatFactsApp

The repository contains the complete source code and project files.

## License

This project was created as a recruitment task and is intended for demonstration purposes.
