# Minimal API demo implementation on .NET Core 6

 An attempt to implement minimal API.
### Features:
- Modularization of API sections. Each module can be extracted as microservice
- Validation of requests with [Fluent Validation](https://github.com/FluentValidation/FluentValidation)
- Auto registration of module repositories in DI with [Scrutor](https://github.com/khellang/Scrutor)

## Sources
1. [Maybe it's time to rethink our project structure with .NET 6](https://timdeschryver.dev/blog/maybe-its-time-to-rethink-our-project-structure-with-dot-net-6)
2. [Minimal APIs overview](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0)
3. [Fluent Validation of requests](https://github.com/juniorporfirio/MinimalApis.Validators/blob/main/src/MininalApis.Validators/FluentValidationExtension.cs)