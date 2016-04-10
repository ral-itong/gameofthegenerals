using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Text.RegularExpressions;

namespace GameOfTheGeneralsUnitTests.MoqSamples
{
    public interface IFoo
    {
        object Name { get; set; }
        OtherClassOne Bar { get; set; }

        bool DoSomething(string input);
        bool TryParse(string input, out string output);
        bool Submit(ref Bar instance);
        string DoSomethingWithString(string input);
        int GetCount();
        int GetCountThing();
        bool Add(int input);

        event MyEventHandler MyEvent;
    }

    public class Bar {

    }

    public interface OtherClassOne
    {
        OtherClassTwo Baz { get; set; }
    }

    public interface OtherClassTwo
    {
        object Name { get; set; }
    }

    public delegate void MyEventHandler(int i, bool b);

    internal class FooEventArgs : EventArgs
    {
        private object fooValue;

        public FooEventArgs(object fooValue)
        {
            this.fooValue = fooValue;
        }
    }

    [TestClass]
    public class MoqExamples
    {
        Mock<IFoo> mock;

        [TestInitialize]
        public void InitTest()
        {
            mock = new Mock<IFoo>();
        }


        [TestMethod]
        public void MockMethodOne()
        {
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
            Assert.AreEqual(true, mock.Object.DoSomething("ping"));
        }

        [TestMethod]
        public void MockMethodTwo()
        {
            var outString = "ack";
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);

            Assert.AreEqual(true, mock.Object.TryParse("ping", out outString));
        }

        [TestMethod]
        public void MockMethodThree()
        {
            var instance = new Bar();
            var otherInstance = new Bar();
            mock.Setup(foo => foo.Submit(ref instance)).Returns(true);

            Assert.AreEqual(true, mock.Object.Submit(ref instance));
            Assert.AreEqual(false, mock.Object.Submit(ref otherInstance));
        }

        [TestMethod]
        public void MockMethodFour()
        {
            mock.Setup(x => x.DoSomethingWithString(It.IsAny<string>())).Returns((string s) => s.ToLower());
            string input = "Negus";
            Assert.AreEqual(input.ToLower(), mock.Object.DoSomethingWithString(input));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MockMethodFive()
        {
            mock.Setup(foo => foo.DoSomethingWithString("reset")).Throws<InvalidOperationException>();
            mock.Object.DoSomethingWithString("reset");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MockMethodSix()
        {
            mock.Setup(foo => foo.DoSomethingWithString("")).Throws(new ArgumentException("command"));
            mock.Object.DoSomethingWithString("");
        }

        [TestMethod]
        public void MockMethodSeven()
        {
            int count = 5;
            mock.Setup(foo => foo.GetCount()).Returns(() => count);
            Assert.AreEqual(count, mock.Object.GetCount());
        }

        [TestMethod]
        public void MockMethodEight()
        {
            var calls = 0;
            mock.Setup(foo => foo.GetCountThing())
                .Returns(() => calls)
                .Callback(() => calls++);

            Assert.AreEqual(0, mock.Object.GetCountThing());
            Assert.AreEqual(1, mock.Object.GetCountThing());
        }

        [TestMethod]
        public void MockMethodNine()
        {
            mock.Setup(foo => foo.DoSomething(It.IsAny<string>())).Returns(true);
            Assert.AreEqual(true, mock.Object.DoSomething("lalala"));
        }

        [TestMethod]
        public void MockMethodTen()
        {
            mock.Setup(foo => foo.Add(It.Is<int>(i => i % 2 == 0))).Returns(true);
            Assert.AreEqual(true, mock.Object.Add(2));
            Assert.AreEqual(false, mock.Object.Add(1));
        }

        [TestMethod]
        public void MockMethodEleven()
        {
            mock.Setup(foo => foo.Add(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns(true);
            Assert.AreEqual(true, mock.Object.Add(0));
            Assert.AreEqual(true, mock.Object.Add(2));
            Assert.AreEqual(true, mock.Object.Add(10));
            Assert.AreEqual(false, mock.Object.Add(-3));
            Assert.AreEqual(false, mock.Object.Add(11));
        }

        [TestMethod]
        public void MockMethodTwelve()
        {
            string expected = "foo";
            mock.Setup(x => x.DoSomethingWithString(It.IsRegex("[a-d+]", RegexOptions.IgnoreCase))).Returns(expected);
            Assert.AreEqual(expected, mock.Object.DoSomethingWithString("abcd"));
            Assert.AreNotEqual(expected, mock.Object.DoSomethingWithString("x"));
        }

        [TestMethod]
        public void MockMethodThirteen()
        {
            mock.Setup(foo => foo.Name).Returns("bar");
            Assert.AreEqual("bar", mock.Object.Name);
        }

        [TestMethod]
        public void MockMethodFourteen()
        {
            mock.Setup(foo => foo.Bar.Baz.Name).Returns("baz");
            Assert.AreEqual("baz", mock.Object.Bar.Baz.Name);
        }

        [TestMethod]
        public void MockMethodFifteen()
        {
            mock.SetupSet(foo => foo.Name = "foo");
            mock.Object.Name = "foo";
            mock.VerifySet(foo => foo.Name = "foo");
        }

        [TestMethod]
        public void MockMethodSixteen()
        {
            mock.SetupProperty(f => f.Name);
            // or
            mock.SetupProperty(f => f.Name, "foo");

            IFoo foo = mock.Object;

            Assert.AreEqual("foo", foo.Name);

            foo.Name = "bar";
            Assert.AreEqual("bar", foo.Name);
        }

        // Events
        [TestMethod]
        public void MockMethodSeventeen()
        {
            object fooValue = null;
            mock.Raise(m => m.MyEvent += null, new FooEventArgs(fooValue));
        }


    }


}
