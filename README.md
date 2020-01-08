# <img src="/assets/icon.png" height="30px" alt="RailwaySharp Logo"> RailwaySharp

Native **C#** implementation of Railway-oriented programming. Inspired by [Chessie](https://github.com/fsprojects/Chessie).

## Targets

- .NET Standard 2.0
- .NET Framework 4.0, 4.5, 4.6.1

## Install via NuGet

```sh
$ dotnet add package RailwaySharp --version 1.0.0
```

## At a glance

``` csharp
public static Result<Request, string> ValidateInput(Request input)
{
    if (input.Name == "") {
        return Result.FailWith<Request, string>("Name must not be blank");
    }
    if (input.EMail == "") {
        return Result.FailWith<Request, string>("Email must not be blank");
    }
    return Result.Succeed<Request, string>(input);
}

var request = new Request { Name = "Giacomo", EMail = "gsscoder@gmail.com" };
var result = Validation.ValidateInput(request);
result.Match(
    (x, msgs) => { Logic.SendMail(x.EMail); },
    msgs => { Logic.HandleFailure(msgs) });
```
See this [unit test](https://github.com/gsscoder/railwaysharp/blob/master/tests/RailwaySharp.Tests/Unit/SimpleValidation.cs) for more examples.


## Reference

It allows also source inclusion in other projects. Just drop `ErrorHandling.cs` in your project tree or reference it using [Paket](http://fsprojects.github.io/Paket/).

**paket.dependencies**
```
source https://nuget.org/api/v2 

github gsscoder/railwaysharp src/RailwaySharp/ErrorHandling.cs 
```
**paket.references** (if you've a dir called `Infrastructure`)
```
File:ErrorHandling.cs Infrastructure
```
`ErrorHandling.cs` contains an internal `Unit` type, comment `ERRH_BUILTIN_TYPES` to use the (identical) one from [CSharpx](https://github.com/gsscoder/CSharpx) if already included. `ERRH_DISABLE_INLINE_METHODS` allows usage on .NET Framework <= 4.0.

## Async

Simply define an async computation result using `Task<Result<TSuccess,TMessage>>` type. 

## Latest Changes

  - Ported to .NET Core.

## Icon

[Railway Crossing](https://thenounproject.com/search/?q=railway&i=716833) icon designed by Gan Khoon Lay from [The Noun Project](https://thenounproject.com/).