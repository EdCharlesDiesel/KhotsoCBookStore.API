
# KhotsoCBookStore.API

KhotsoCBookStore.API is an API back-end of the angular front-end application [KhotsoCBookStore](https://microsoft.com/cli). This project was generated with [dotnet CLI](https://microsoft.com/cli) version 5.0.
and SQL server as the database and EntityFrameworkCore as the ORM. 
## KhotsoCBookStore.API V2.1.1 New Features

This version has been rebuild with new features and improved stability. Like:
-New Bug Fixes.
-Unit tests.
-New Entities added ie:

    -Authors 
    -Promotions
    -Publishers
    -Employees
    -BookAuthors
    -many more..
-Rewrote the code base with async
-
Security has been updated featuring login using 3rd party SSO.

## Re-Build

If you don't hava localdb installed please update the connection string to point to your sql server instance. 
Run `dotnet restore` to restore the packages required to build the application successfuly. Then after run the 
command  `dotnet build` to build the project. Lastly run the command `dotnet ef database update`.

## Development server

Run `dotnet run` for a dev server. Navigate to `http://localhost:5000/`. The app will automatically load with 
a swagger API documentation with all the end-points.

## Running unit tests

Run `dotnet test` to execute the unit tests.

## Running unit tests and code coverage

Run `dotnet test --collect:"XPlat Code Coverage"` to execute the upnit tests via [Xplat](http://www.protractortest.org/).

## Further help

To get more help on the dotnet CLI use `dotnet --help` or go check out the [dotnet CLI Overview and Command Reference](https:/microsoft.com/cli) page.
---