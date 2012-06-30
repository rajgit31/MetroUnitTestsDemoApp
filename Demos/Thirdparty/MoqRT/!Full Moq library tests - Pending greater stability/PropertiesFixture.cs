﻿using System;
using System.Diagnostics;
using System.Reflection;
using Moq;

#if !NETFX_CORE
using Microsoft.VisualStudio.TestTools.UnitTesting;
#else
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#endif

namespace Moq.Tests
{
    [TestClass]
    public class PropertiesFixture
	{
		public interface IFoo
		{
			IIndexedFoo Indexed { get; set; }
		}

		public interface IIndexedFoo
		{
			string this[int key] { get; set; }
			string this[int key1, string key2, bool key3, DateTime key4] { get; set; }

			IBar this[int key1, string key2, DateTime key4] { get; set; }
		}

		public interface IBar
		{
			string Value { get; set; }
		}


		[TestMethod]
		public void ShouldSupportMultipleIndexerGettersInFluentMock()
		{
			var foo = new Mock<IFoo>();

			foo.SetupGet(x => x.Indexed[It.IsAny<int>(), "foo", It.IsAny<DateTime>()].Value).Returns("bar");

			var result = foo.Object.Indexed[1, "foo", DateTime.Now].Value;

			Assert.AreEqual("bar", result);
		}

		[TestMethod]
		public void ShouldSupportMultipleIndexerGetters()
		{
			var foo = new Mock<IIndexedFoo>();

			foo.SetupGet(x => x[It.IsAny<int>(), "foo", true, It.IsAny<DateTime>()]).Returns("bar");

			var result = foo.Object[1, "foo", true, DateTime.Now];

			Assert.AreEqual("bar", result);
		}

		[TestMethod]
		public void ShouldSetIndexer()
		{
			var foo = new Mock<IIndexedFoo>(MockBehavior.Strict);

			foo.SetupSet(f => f[0] = "foo");

			foo.Object[0] = "foo";
		}

		[TestMethod]
		public void ShouldSetIndexerWithValueMatcher()
		{
			var foo = new Mock<IIndexedFoo>(MockBehavior.Strict);

			foo.SetupSet(f => f[0] = It.IsAny<string>());

			foo.Object[0] = "foo";
		}

        //[Fact(Skip = "Not supported for now")]
        //public void ShouldSetIndexerWithIndexMatcher()
        //{
        //    var foo = new Mock<IIndexedFoo>(MockBehavior.Strict);

        //    foo.SetupSet(f => f[It.IsAny<int>()] = "foo");

        //    foo.Object[18] = "foo";
        //}

        //[Fact(Skip = "Not supported for now")]
        //public void ShouldSetIndexerWithBothMatcher()
        //{
        //    var foo = new Mock<IIndexedFoo>(MockBehavior.Strict);

        //    foo.SetupSet(f => f[It.IsAny<int>()] = It.IsAny<string>());

        //    foo.Object[18] = "foo";
        //}
	}
}
