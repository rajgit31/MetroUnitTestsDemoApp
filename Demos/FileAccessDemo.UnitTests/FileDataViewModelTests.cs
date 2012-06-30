using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Moq;
using Windows.Storage;

namespace FileAccessDemo.UnitTests
{
    [TestClass]
    public class FileDataViewModelTests
    {
        [TestMethod]
        public void CalculateCommand_WhenValidDataValueExists_ReturnsExpectedTotal()
        {
            //Arrange            
            var stubFileRepo = new StubIFileService();
            var model = new FileDataViewModel(stubFileRepo) {FileContent = "3, 5"};
            var command = new CalculateCommand();

            //Act
            command.Execute(model);

            //Assert             
            Assert.IsTrue(model.TotalValue.Equals("8"));
        }


        [TestMethod]
        public async Task GetFilesAsync_WhenFilesExist_ReturnsExpectedType()
        {
            //Arrange
            var sut = new FileService(new StubLoggerService());
            ;
            //Act
            var result = await sut.GetFilesAsync();

            //Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<FileItem>));
        }


        [TestMethod]
        public async Task GetFilesAsync_VerifyLogMethodIsCalled()
        {
            //Arrange
            var loggerServiceMock = new Mock<ILoggerService>();
            var sut = new FileService(loggerServiceMock.Object);

            //Act
            var result = await sut.GetFilesAsync();

            //Assert
            loggerServiceMock.Verify(c => c.Log(It.IsAny<string>()), Times.Once());
        }


        [TestMethod]
        public void testGetFilesAsync_VerifyLogMethodIsCalled()
        {
            //Arrange
            var loggerServiceMock = new Mock<ILoggerService>();
            var sut = new FileService(loggerServiceMock.Object);

            //Act
            var result = sut.GetFiles();

            //Assert
            loggerServiceMock.Verify(c => c.Log(It.IsAny<string>()), Times.Once());
        }





        //[TestMethod]
        //public void iCalculateCommand_WhenValidDataValueExists_ReturnsExpectedTotal()
        //{
        //    var stubFileRepo = new Mock<IFileService>();
            
        //    //Arrange
        //    var model = new FileDataViewModel(stubFileRepo.Object) { };
        //    //var command = new CalculateCommand();

        //    //Act
        //    var list = model.FilesList;
        //    //Returns(() => Task.Run<IEnumerable<FileItem>>(() => new List<FileItem>()));
        //    ////Assert             
        //    stubFileRepo.Verify(x => x.GetFileContent(), Times.Never());
        //}

        //[TestMethod]
        //public async Task ReadFileCommandAction_WhenFileExist_EnsureTheModelContainsNumbersDivisableByZero()
        //{
        //    //Arrange            
        //    //var stubFileRepo = new StubIFileRepository();
        //    var stubFoo = new Mock<IFoo>();
        //    stubFoo.Setup(x => x.GetBar()).Returns(new Bar());
        //    var stubFileRepo = new Mock<IFileRepository>();
        //    var stubFile = new Mock<Task<IStorageFile>>();
        //    stubFileRepo.Setup(x => x.GetFileAsync("file"))
        //        .Returns(() => stubFile.Object);
        //    //var model = new FileDataViewModel(stubFileRepo.Object);
        //    var model = new FileDataViewModel();
        //    model.FileRepository = stubFileRepo.Object;
        //    model.SelectedFileItem = new FileItem("code", "name");
        //    model.Foo = stubFoo.Object;

        //    //Act
        //    await model.ReadFileCommandAction();

        //    //Assert             
        //    //Assert.IsTrue(model.OutputText.Equals("15"));
        //    Assert.IsTrue(true);

        //}
    }


    public class StubIFileService : IFileService
    {
        public Task<IEnumerable<FileItem>> GetFilesAsync()
        {
            return Task.Run<IEnumerable<FileItem>>(() => new List<FileItem>());
        }

        public Task<string> GetFileContentAsyn(FileItem storageFile)
        {
            return Task.Run(() => "5, 10");
        }

        public string GetFileContent()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<FileItem> GetFiles()
        {
            throw new NotImplementedException();
        }
    }


    public class StubLoggerService : ILoggerService
    {
        public void Log(string message)
        {
            //do nothing
        }
    }
}

