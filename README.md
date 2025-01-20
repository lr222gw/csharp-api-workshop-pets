# C# Pets API

Simple Pet API with basic endpoints.

## Endpoints


## Setup

- Add an appsettings.json file in the root of the workshop.wwwapi project which contains:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```

- Note the .gitignore file in the root of the project which prevents the build directories being uploaded:
```
*/**/bin/Debug   
*/**/bin/Release   
*/**/obj/Debug   
*/**/obj/Release   
/workshop.wwwapi/appsettings.json
/workshop.wwwapi/appsettings.Development.json
```


 ## Dependencies:
- install-package Scalar.AspNetCore
- install-package Swashbuckle.AspNetCore

## Validation Filters

Two packages are required for the validation.

- install-package FluentValidation
- install-package FluentValidation.DependencyInjectionExtensions

Note the ValidationFilter class and the PetPostValidator which we can create for every ViewModel/Dto that sends data into our API.