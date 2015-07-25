# RailwaySharp
Native **C#** implementation of Railway-oriented programming (https://github.com/fsprojects/Chessie).

The motivation of this version is to allow source inclusion in other projects. Just drop `ErrorHandling.cs` in your project tree.

`ErrorHandling.cs` contains internal `EnumerableExtensions::Fold(...)` and `Unit` type, comment `ERRH_BUILTIN_TYPES` to use the ones from [CSharpx](https://github.com/gsscoder/CSharpx).

## Async
F# code about async result is mainly for computation expressions. In **C#** for define an async computation result, simply use `Task<Result<TSuccess,TMessage>>`. 
