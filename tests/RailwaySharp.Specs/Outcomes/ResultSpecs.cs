using System;
using System.Linq;
using Xunit;
using FluentAssertions;
using RailwaySharp;

public class Result
{
    [Fact]
    public void try_will_catch()
    {
        var exn = new Exception("Hello World");
        var result = Result<object, object>.Try(() => { throw exn; });
        exn.Should().Be(result.FailedWith().First());
    }

    [Fact]
    public void try_will_return_value()
    {
        var result = Result<string, object>.Try(() => "hello world");
        "hello world".Should().Be(result.SucceededWith());
    }
}