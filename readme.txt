** In Tools and then NuGet Package Manager -> Package Manager Console.
1. Add-Migration "Freetext" *(Exp: Add-Migration InitialMigrations
2. Update-database


**run both of applications 'TechnicalTest' and 'WebApi' in the same time
1. Right click in solution of Project
2. Select properties
3. In 'Common Properties', select Startup Project
4. Select Multiple Startup Projects
5. Change action both of TechnicalTest and WebApi into Start
6. And then click Apply and Ok

**Note
if your localhost link doesnt look like this -> https://localhost:7223/api/Transaction/ When you run WebApi Project
And then change it in TechnicalTest project - Properties - launchSetting.json - ApiUrl, adjust the localhost link with your own link