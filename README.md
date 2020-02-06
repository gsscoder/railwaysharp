[![NuGet](https://img.shields.io/nuget/dt/railwaysharp.svg)](https://nuget.org/packages/railwaysharp)
[![NuGet](https://img.shields.io/nuget/v/railwaysharp.svg)](https://nuget.org/packages/railwaysharp)

# <img src="/assets/icon.png" height="30px" alt="RailwaySharp Logo"> RailwaySharp

Native **C#** implementation of Railway-oriented programming. Inspired by [Chessie](https://github.com/fsprojects/Chessie). This project is used in [Command Line Parser Library](https://github.com/commandlineparser/commandline).

## Reference

It allows also source inclusion in other projects. Just drop `ErrorHandling.cs` in your project tree or reference it using [Paket](http://fsprojects.github.io/Paket/):

**paket.dependencies**
```
github gsscoder/railwaysharp src/railwaysharp/ErrorHandling.cs 
```
**paket.references** (if you've a dir called `Internal`)
```
File:ErrorHandling.cs Internal
```
- **Paket** will alter your `csproj` file adding a `Compile` item, so you need to set `EnableDefaultCompileItems` property to `false`. At this point, every other source file must be handled in the same way. For more detailed informations please read [Paket Documentation](https://fsprojects.github.io/Paket/github-dependencies.html).
- Enabling `ERRH_ADD_MAYBE_METHODS` compilation constant will add `Maybe` type related methods (as defined in [CSharpx](https://github.com/gsscoder/csharpx). You will need at least `Maybe.cs` in your project.
- Enabling `ERRH_ENABLE_INLINE_METHODS` will allow inlining of certain methods on targets that support it.

## Targets

- .NET Standard 2.0
- .NET Framework 4.0, 4.5, 4.6.1

## Install via NuGet

```sh
$ dotnet add package RailwaySharp --version 1.2.2
```

## At a glance

``` csharp
public static Result<Request, string> ValidateInput(Request input)
{
    if (input.Name == string.Empty) {
        return Result<Request, string>.FailWith("Name must not be blank");
    }
    if (input.EMail == string.Empty) {
        return Result<Request, string>.FailWith("Email must not be blank");
    }
    return Result<Request, string>.Succeed(input);
}

var request = new Request { Name = "Giacomo", EMail = "gsscoder@gmail.com" };
var result = Validation.ValidateInput(request);
result.Match(
    (x, msgs) => { Logic.SendMail(x.EMail); },
    msgs => { Logic.HandleFailure(msgs) });
```
See this [unit test](https://github.com/gsscoder/railwaysharp/blob/master/tests/RailwaySharp.Tests/Unit/SimpleValidation.cs) for more examples.

## Async

Simply define an async computation result using `Task<Result<TSuccess,TMessage>>` type. 

## Latest Changes

- Namespace set to `RailwaySharp`.
- Moved first parameter of `Trial` class.
- Fixed an issue in `Trail.Collect`.
- Removed static class `Result`, methods moved to `Result<Result<TSuccess, TMessage>>`.

## Related Projects

- [CSharpx](https://github.com/gsscoder/csharpx)

## Icon

[Railway Crossing](https://thenounproject.com/search/?q=railway&i=716833) icon designed by Gan Khoon Lay from [The Noun Project](https://thenounproject.com/).