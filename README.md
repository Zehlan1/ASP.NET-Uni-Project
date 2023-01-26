# Videogame Auction House

App allows visitors to browse various video games, series they belong to and thier publishers. Users that are logged in can add mentioned before elements and create auctions with them, they can also bid in these auctions or buy them out completely.
Admin account can delete and edit said elements.

## App Functions

- Creating Auctions, games, publishers and videogame series
- Displaying details, editing and deleting these elements
- Registration and Login features
- Bidding and Buyout in auctions
- API allowing the creation and manipulation of auctions

# Installation and required packages

All packages were installed with the use of **NuGet**.
App uses an external database, in this case **Microsoft SQL Server**

## Packages

- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.AspNetCore.Identity.UI
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- xunit

## Installation

- In the file **appsettings.json** next to fields **DATA SOURCE=** and **Server=** type the address of the database server which will be used (**localhost** by default)
- Open project terminal
- Run the command: **dotnet ef database update --context AppDbContext**
It createds the following tables in the database: Auctions, Games, Producers adn GameSeries
- Run the command: **dotnet ef database update --context IdentityDbContext**
It createds all the Identity tables in the database
- In case any of the upper two commands doesn't work, use the following:
**dotnet ef migrations add InitialCreate --context AppDbContext**
**dotnet ef migrations add InitialIdentity --context IdentityDbContext**
and use the first two commands again.

# Aviailable Users

## Admins

- **Login:** admin1@fake.fake **Password:** AdminPassword1!

## Users

- **Login:** test1@fake.fake **Password:** Password1!
- **Login:** test2@fake.fake **Password:** Password2!
- **Login:** test3@fake.fake **Password:** Password3!
