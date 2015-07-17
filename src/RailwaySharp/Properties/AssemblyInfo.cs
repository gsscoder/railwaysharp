using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("RailwaySharp.dll")]
[assembly: AssemblyDescription("Native C# implementation of Railway-oriented programming.")]
[assembly: AssemblyCulture("")]
[assembly: InternalsVisibleTo("RailwaySharp.Tests")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]