using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Moq;

namespace UnitTestLibrary1
{
    public interface IFoo
    {
        string Bar();
    }

    public class A
    {
        public string M(IFoo foo)
        {
            var s = foo.Bar();
            return s;
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod2()
        {
            var fooMock = new Mock<IFoo>();
            fooMock.Setup(x => x.Bar()).Returns("foo");

            var a = new A();
            var r = a.M(fooMock.Object);

            Assert.AreEqual("foo", r);


        }
    }
}
