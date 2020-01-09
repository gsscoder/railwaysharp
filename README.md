# <img src="/assets/icon.png" height="30px" alt="RailwaySharp Logo"> RailwaySharp

Native **C#** implementation of Railway-oriented programming. Inspired by [Chessie](https://github.com/fsprojects/Chessie).

## Targets

- .NET Standard 2.0
- .NET Framework 4.0, 4.5, 4.6.1

## Install via NuGet

```sh
$ dotnet add package RailwaySharp --version 1.1.0
```

## At a glance

``` csharp
public static Result<Request, string> ValidateInput(Request input)
{
    if (input.Name == string.Empty) {
        return Result.FailWith<Request, string>("Name must not be blank");
    }
    if (input.EMail == string.Empty) {
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
github gsscoder/railwaysharp src/RailwaySharp/ErrorHandling.cs 
```
**paket.references** (if you've a dir called `Infrastructure`)
```
File:ErrorHandling.cs Infrastructure
```
- Enabling `ERRH_ADD_MAYBE_METHODS` compilation constant will add `Maybe` type related methods (as defined in [CSharpx](https://github.com/gsscoder/csharpx). You will need at least `Maybe.cs` in your project.
- Enabling `ERRH_ENABLE_INLINE_METHODS` will allow inlining of certain methods on targets that support it.

## Async

Simply define an async computation result using `Task<Result<TSuccess,TMessage>>` type. 

## Latest Changes

  - Ported to .NET Core.

## Icon

[Railway Crossing](https://thenounproject.com/search/?q=railway&i=716833) icon designed by Gan Khoon Lay from [The Noun Project](https://thenounproject.com/).