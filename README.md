# Guardians of the Code

This is the code from the On-Demand Course `Design Patterns Using C#` by `Dmitri Loukas` on O'Reilly.

I did not follow the online course exactly. Most of the course is outdated and not following modern .NET practices and some of the examples are poor examples of design patterns.

The course is quite messy and all over the place.  There is very little coherence between the examples and the end resulting code. I would say the course is very incomplete.  It might be worth the time for a beginner.

## Projects

There are 2 class libraries.
- Common
- SpaceWeapons (Adapter Pattern)

There is one API project.
- Api

There is one console application.
- GuardiansOfTheCode


## Building the code

### Prerequisites
- .NET 9 SDK
- (Optional) Rider or Visual Studio 2022

The code is .NET 9 and can be built using Rider, Visual Studio 2022 or the .NET CLI.

From the root of the repository you can build the solution.
```shell
dotnet build
```

## Running the code

The console application requires the API project to be running.

### Running the API

```shell
# You may need to trust the development certificate for ASP.NET Core
dotnet dev-certs https --trust
# Run the API project
dotnet run --project .\src\Api --launch-profile https
```
This should start the api on `https://localhost:7241` which is required for the console application.  If you cannot get it working then the `buy` command will work, but `play` will not.

You can visit the API in a browser to see the swagger UI.
- [https://localhost:7241/swagger/index.html](https://localhost:7241/swagger/index.html)

There is just one endpoint `/cards` which is a GET request that returns a list of cards.

### Run the console application

```shell
# Print the help
dotnet run --project .\src\GuardiansOfTheCode
```

This will provide you with the commands available.
- play
  - the core game loop, although it is not really a game which was disappointing.
- buy
  - Simulates some subscription buying.
  - The online course didn't implement this at all just created classes.
  - It is supposed to represent the state pattern.
  - I implemented the buy command to simulate the state pattern just to put the classes to use.


To run the play command.
```shell
# Run the console application
dotnet run --project .\src\GuardiansOfTheCode play
```

To run the buy command.
```shell
# Run the console application
dotnet run --project .\src\GuardiansOfTheCode buy
```
