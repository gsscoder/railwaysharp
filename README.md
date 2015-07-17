# RailwaySharp
Native **C#** implementation of Railway-oriented programming (https://github.com/fsprojects/Chessie).

The motivation of this version is to allow source inclusion in other projects. Just drop `ErrorHandling.cs` in your project tree.

## Async
F# code about async result is mainly for computation expressions. In **C#** for define an async computation result, simply use `Task<Result<TSuccess,TMessage>>`. 
