# RailwaySharp

Native **C#** implementation of Railway-oriented programming. Inspired by [Chessie](https://github.com/fsprojects/Chessie).

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

It allows source inclusion in other projects. Just drop `ErrorHandling.cs` in your project tree or reference it using [Paket](http://fsprojects.github.io/Paket/):

**paket.dependencies**
```
source https://nuget.org/api/v2 

github gsscoder/railwaysharp src/RailwaySharp/ErrorHandling.cs 
```
**paket.references** (if you've a dir called `Infrastructure`)
```
File:ErrorHandling.cs Infrastructure
```
`ErrorHandling.cs` contains an internal `Unit` type, comment `ERRH_BUILTIN_TYPES` to use the (identical) one from [CSharpx](https://github.com/gsscoder/CSharpx) if already included.

## Async

Simply define an async computation result using `Task<Result<TSuccess,TMessage>>` type. 

## Latest Changes

  - Ported to .NET Core.