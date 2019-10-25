# Pierre's Sassy Store

#### A website to track market Pierre's sweet and savory treats, 25-Oct-2019

#### By **Christine Frank**

## Description

This is a MVC website created to allow a business owner to market their sweet and savory treats. All users have read authorization of content on the website, but only users logged in can create, update or delete items. The application provides a many-to-many relationship between different treats and flavors.

## Setup/Installation Requirements

* Clone this repository to your desktop
* Install .NET Core SDK (if not already installed)
* Install REPL *dotnet script* (if not already installed)
    * Command: 'dotnet tool install -g dotnet-script'
* Install MySql Server and WorkBench (if not already installed)
* Open a new Command Terminal and start MySql Server if not already running
    * Command: mysql -uroot -p{EnterYourPassword}

* In the main project folder of the local repository, create a file "appsettings.json" and add the following content:

```JSON
{
  "ConnectionStrings":
  {
    "DefaultConnection": "Server=localhost;Port=3306;database=christine_frank;uid=root;pwd=epicodus;"
  }
}
```
* In a new Command Terminal route to the project folder of the local repository and run the migration command:
```
dotnet ef database update
```
* Confirm successful migration
* Open a new Command Terminal and route to the main project folder of the local repository (//Desktop/PierresSassyStore.Solution/PierresSassyStore)
* Enter command 'dotnet run' into the Terminal
* Open a new browser and enter 'http://localhost:5000/'

## Known Bugs

None known at this time.

## Support and contact details

Find a bug?! Add an issue to the GitHub Repo.
Repo: https://github.com/christinelfrank16/PierresSassyStore.Solution

Other Contact
Email: christine.braun13@gmail.com
LinkedIn: https://www.linkedin.com/in/christine-frank/

## Application Specifications

* The user can view the splashpage
* A user can create an account
* A user with a valid account can log in and out
* All users have READ access to the entire application
* Only logged-in users can:
    *  Add a new treat or flavor
    *  Update a treat or flavor
    *  Delete a treat or flavor
* The user can route to a splashpage that displays all treats and flavors
* The user can route to a specific treat or flavor and see all treats/flavors that belong to it

## Technologies Used

* .NET/C#
* MVC
* Entity Framework
* Identity Framework

### License

*This application is licensed under the MIT license*

Copyright (c) 2019 **Christine Frank**