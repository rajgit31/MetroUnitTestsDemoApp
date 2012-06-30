using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;

namespace FileAccessDemo
{
    public interface IFileService
    {
        Task<IEnumerable<FileItem>> GetFilesAsync();
        IEnumerable<FileItem> GetFiles();
        Task<string> GetFileContentAsyn(FileItem storageFile);
    }


    public class FileService : IFileService
    {
        private readonly ILoggerService loggerService;

        public FileService(ILoggerService loggerService)
        {
            this.loggerService = loggerService;
        }

        public async Task<IEnumerable<FileItem>> GetFilesAsync()
        {
            loggerService.Log("retrieving files");

            var folder = KnownFolders.DocumentsLibrary;
            var files = await folder.GetFilesAsync();

            return files.Select(x => new FileItem(x.Name, x.DisplayName));
        }

        public async Task<string> GetFileContentAsyn(FileItem fileItem)
        {
            var folder = KnownFolders.DocumentsLibrary;
            
            var storageFile = await folder.GetFileAsync(fileItem.Code);

            return await FileIO.ReadTextAsync(storageFile);
        }


        public IEnumerable<FileItem> GetFiles()
        {
            loggerService.Log("retrieving files");
            return null;
        }
    }   
}
