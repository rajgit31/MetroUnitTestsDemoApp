using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xunit;

namespace FileAccessDemo.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public async void ReadFileCommandAction_WhenFileExist_EnsureTheModelContainsNumbersDivisableByZero()
        {
            //Arrange            
            var stubFileRepo = new StubIFileRepository();
            var model = new FileDataViewModel(stubFileRepo);
            model.SelectedFileItem = new FileItem("code", "name");

            //Act
            await model.ReadFileCommandAction();

            //Assert             
            Assert.True(model.OutputText.Equals("fake string"));
        }        
    }

    public class StubIFileRepository : IFileRepository
    {

        public Task<IStorageFile> GetFileAsync(string fileName)
        {
            //return new FakeStorageFile();
            return Task.Run<IStorageFile>(() => { return new FakeStorageFile(); });
        }

        public Task<string> ReadFileAsync(IStorageFile storageFile)
        {
            return Task.Run(() => { return "fake string"; });
        }

        public Task<IEnumerable<FileItem>> GetFilesAsync()
        {
            return new Task<IEnumerable<FileItem>>(() => new List<FileItem> { new FileItem("fakeCode", "fakeName") });
        }
    }

    internal class FakeStorageFile : IStorageFile
    {
        public FakeStorageFile()
        {
        }

        public string ContentType
        {
            get { throw new NotImplementedException(); }
        }

        public Windows.Foundation.IAsyncAction CopyAndReplaceAsync(IStorageFile fileToReplace)
        {
            throw new NotImplementedException();
        }

        public Windows.Foundation.IAsyncOperation<StorageFile> CopyAsync(IStorageFolder destinationFolder, string desiredNewName, NameCollisionOption option)
        {
            throw new NotImplementedException();
        }

        public Windows.Foundation.IAsyncOperation<StorageFile> CopyAsync(IStorageFolder destinationFolder, string desiredNewName)
        {
            throw new NotImplementedException();
        }

        public Windows.Foundation.IAsyncOperation<StorageFile> CopyAsync(IStorageFolder destinationFolder)
        {
            throw new NotImplementedException();
        }

        public string FileType
        {
            get { throw new NotImplementedException(); }
        }

        public Windows.Foundation.IAsyncAction MoveAndReplaceAsync(IStorageFile fileToReplace)
        {
            throw new NotImplementedException();
        }

        public Windows.Foundation.IAsyncAction MoveAsync(IStorageFolder destinationFolder, string desiredNewName, NameCollisionOption option)
        {
            throw new NotImplementedException();
        }

        public Windows.Foundation.IAsyncAction MoveAsync(IStorageFolder destinationFolder, string desiredNewName)
        {
            throw new NotImplementedException();
        }

        public Windows.Foundation.IAsyncAction MoveAsync(IStorageFolder destinationFolder)
        {
            throw new NotImplementedException();
        }

        public Windows.Foundation.IAsyncOperation<Windows.Storage.Streams.IRandomAccessStream> OpenAsync(FileAccessMode accessMode)
        {
            throw new NotImplementedException();
        }

        public FileAttributes Attributes
        {
            get { throw new NotImplementedException(); }
        }

        public DateTimeOffset DateCreated
        {
            get { throw new NotImplementedException(); }
        }

        public Windows.Foundation.IAsyncAction DeleteAsync(StorageDeleteOption option)
        {
            throw new NotImplementedException();
        }

        public Windows.Foundation.IAsyncAction DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public Windows.Foundation.IAsyncOperation<Windows.Storage.FileProperties.BasicProperties> GetBasicPropertiesAsync()
        {
            throw new NotImplementedException();
        }

        public bool IsOfType(StorageItemTypes type)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public string Path
        {
            get { throw new NotImplementedException(); }
        }

        public Windows.Foundation.IAsyncAction RenameAsync(string desiredName, NameCollisionOption option)
        {
            throw new NotImplementedException();
        }

        public Windows.Foundation.IAsyncAction RenameAsync(string desiredName)
        {
            throw new NotImplementedException();
        }

        public Windows.Foundation.IAsyncOperation<Windows.Storage.Streams.IRandomAccessStreamWithContentType> OpenReadAsync()
        {
            throw new NotImplementedException();
        }

        public Windows.Foundation.IAsyncOperation<Windows.Storage.Streams.IInputStream> OpenSequentialReadAsync()
        {
            throw new NotImplementedException();
        }


        public Windows.Foundation.IAsyncOperation<StorageStreamTransaction> OpenTransactedWriteAsync()
        {
            throw new NotImplementedException();
        }
    }
    
}
