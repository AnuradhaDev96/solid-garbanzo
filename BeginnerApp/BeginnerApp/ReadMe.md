## Getting Started
Should install Nuget packages

## Data Migration Commands
Open Package Manager Console
- Tools > NuGet Package Manager > PMC

Add migration | Add<ModelName>ToDatabase
- add-migration AddCategoryToDatabase

Update the database
- update-database

## Development Tips
- Download bootstrap theme from https://bootswatch.com/ and add it to wwwroot/css/ folder. Then link it in <head> tag of _Layout.cshtml file
- Copy the js link for bootstrap from https://getbootstrap.com/docs/ and paste it in _Layout.cshtml as script