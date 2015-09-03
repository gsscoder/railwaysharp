# RailwaySharp
Native **C#** implementation of Railway-oriented programming (https://github.com/fsprojects/Chessie).

The motivation of this version is to allow source inclusion in other projects. Just drop `ErrorHandling.cs` in your project tree or reference it using [Paket](http://fsprojects.github.io/Paket/):

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
F# code about async result is mainly for computation expressions. In **C#** for define an async computation result, simply use `Task<Result<TSuccess,TMessage>>`. 

## Latest Changes
  - Using Linq `Aggregate` instead of local `Fold` extension method.
  - Removed custom tuple `OkPair` and simplified `Ok` _case_.
