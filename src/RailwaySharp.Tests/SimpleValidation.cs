using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
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

    [TestFixture]
    public class TrySpecs
    {
        [Test]
        public void TryWillCatch()
        {
            var exn = new Exception("Hello World");
            var result = Result.Try<string>(() => { throw exn; });
            Assert.AreEqual(exn, result.FailedWith().First());
        }

        [Test]
        public void TryWillReturnValue()
        {
            var result = Result.Try(() => "hello world");
            Assert.AreEqual("hello world", result.SucceededWith());
        }
    }

    [TestFixture]
    public class SimpleValidation
    {
        [Test]
        public void CanCreateSuccess()
        {
            var request = new Request { Name = "Steffen", EMail = "mail@support.com" };
            var result = Validation.ValidateInput(request);
            Assert.AreEqual(request, result.SucceededWith());
        }
    }

    [TestFixture]
    public class SimplePatternMatching
    {
        [Test]
        public void CanMatchSuccess()
        {
            var request = new Request { Name = "Steffen", EMail = "mail@support.com" };
            var result = Validation.ValidateInput(request);
            result.Match(
               (x, msgs) => { Assert.AreEqual(request, x); },
               msgs => { throw new Exception("wrong match case"); });
        }

        [Test]
        public void CanMatchFailure()
        {
            var request = new Request { Name = "Steffen", EMail = "" };
            var result = Validation.ValidateInput(request);
            result.Match(
               (x, msgs) => { throw new Exception("wrong match case"); },
               msgs => { Assert.AreEqual("Email must not be blank", msgs.ElementAt(0)); });
        }
    }

    [TestFixture]
    public class SimpleEitherPatternMatching
    {
        [Test]
        public void CanMatchSuccess()
        {
            var request = new Request { Name = "Steffen", EMail = "mail@support.com" };
            var result =
                Validation
                 .ValidateInput(request)
                 .Either(
                   (x, msgs) => x,
                   msgs => { throw new Exception("wrong match case"); });
            Assert.AreEqual(request, result);
        }

        [Test]
        public void CanMatchFailure()
        {
            var request = new Request { Name = "Steffen", EMail = "" };
            var result =
               Validation.ValidateInput(request)
                .Either(
                   (x, msgs) => { throw new Exception("wrong match case"); },
                   msgs => msgs.ElementAt(0));

            Assert.AreEqual("Email must not be blank", result);
        }
    }
}