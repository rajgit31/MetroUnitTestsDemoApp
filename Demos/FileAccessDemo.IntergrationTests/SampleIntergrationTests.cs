using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace FileAccessDemo.IntergrationTests
{
    [TestClass]
    public class SampleIntergrationTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var musicLibrary = Windows.Storage.KnownFolders.MusicLibrary;
            Assert.IsNotNull(musicLibrary);
        }
    }
}
