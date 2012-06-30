using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.Storage;

namespace UnitTestLibrary1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task SomeAsyncTest()
        {
            var result = await StorageFile.GetFileFromPathAsync("some file path");
        }
    }
}
