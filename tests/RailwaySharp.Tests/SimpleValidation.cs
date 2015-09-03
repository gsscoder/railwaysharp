using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using RailwaySharp.ErrorHandling;

namespace RailwaySharp.Tests
{
    public class Request
    {
        public string Name { get; set; }
        public string EMail { get; set; }
    }

    public class Validation
    {
        public static Result<Request, string> ValidateInput(Request input)
        {
            if (input.Name == "")
                return Result.FailWith<Request, string>("Name must not be blank");
            if (input.EMail == "")
                return Result.FailWith<Request, string>("Email must not be blank");
            return Result.Succeed<Request, string>(input);

        }
    }

    public class TrySpecs
    {
        [Fact]
        public void TryWillCatch()
        {
            var exn = new Exception("Hello World");
            var result = Result.Try<string>(() => { throw exn; });
            exn.ShouldBeEquivalentTo(result.FailedWith().First());
        }

        [Fact]
        public void TryWillReturnValue()
        {
            var result = Result.Try(() => "hello world");
            "hello world".ShouldBeEquivalentTo(result.SucceededWith());
        }
    }

    public class SimpleValidation
    {
        [Fact]
        public void CanCreateSuccess()
        {
            var request = new Request { Name = "Steffen", EMail = "mail@support.com" };
            var result = Validation.ValidateInput(request);
            request.ShouldBeEquivalentTo(result.SucceededWith());
        }
    }

    public class SimplePatternMatching
    {
        [Fact]
        public void CanMatchSuccess()
        {
            var request = new Request { Name = "Steffen", EMail = "mail@support.com" };
            var result = Validation.ValidateInput(request);
            result.Match(
               (x, msgs) => { request.ShouldBeEquivalentTo(x); },
               msgs => { throw new Exception("wrong match case"); });
        }

        [Fact]
        public void CanMatchFailure()
        {
            var request = new Request { Name = "Steffen", EMail = "" };
            var result = Validation.ValidateInput(request);
            result.Match(
               (x, msgs) => { throw new Exception("wrong match case"); },
               msgs => { "Email must not be blank".ShouldBeEquivalentTo(msgs.ElementAt(0)); });
        }
    }

    public class SimpleEitherPatternMatching
    {
        [Fact]
        public void CanMatchSuccess()
        {
            var request = new Request { Name = "Steffen", EMail = "mail@support.com" };
            var result =
                Validation
                 .ValidateInput(request)
                 .Either(
                   (x, msgs) => x,
                   msgs => { throw new Exception("wrong match case"); });
            request.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public void CanMatchFailure()
        {
            var request = new Request { Name = "Steffen", EMail = "" };
            var result =
               Validation.ValidateInput(request)
                .Either(
                   (x, msgs) => { throw new Exception("wrong match case"); },
                   msgs => msgs.ElementAt(0));

            "Email must not be blank".ShouldBeEquivalentTo(result);
        }
    }
}