# Course manager application

This applications is for managing courses and assigning topics to them 

## Installation:

***Running API***

Make sure to install the .Net Core 6.0 SDK for the proper functioning.
You can find it [here](https://dotnet.microsoft.com/download/dotnet-core/6.0) .

To start the application from the command line, make sure you are inside the backend folder.

```
cd Backend
```

First rebuild database
```
dotnet ef database update --project App
```

Then just simply run the command from the powershell/cmd:
```
dotnet run --project App
```

*There should be no worries to try compile it on Linux machine.*


***Running Angular***:

Navigate to:
```
cd Frontend
```

Then run two commands:
```
npm install
ng serve --o 
```
*--o as optional parameter to open browser.*

*If your port 4200 is already in use, feel free to use ng serve --port whaterveryouwant.*


## Technology stack:

***Used Technologies***
+ Angular 13
+ .Net Core 6.0
+ Sqlite
+ Entity framework 6

### Additional info:
Author:
Tomasz Kulka
