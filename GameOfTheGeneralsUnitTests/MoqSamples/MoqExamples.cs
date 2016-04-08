using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameOfTheGeneralsUnitTests.MoqSamples
{
    public interface IFoo
    {
        bool DoSomething(string input);
        bool TryParse(string input, out string output);
        bool Submit(ref Bar instance);
    }

    public class Bar {

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
            mock.Setup(x => x.DoSomething(It.IsAny<string>())).Returns((string s) => s.ToLower()); 
        }
    }
}
