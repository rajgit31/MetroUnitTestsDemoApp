using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Windows.Storage;

namespace FileAccessDemo
{
    public class FileDataViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IFileService fileService;

        public FileDataViewModel(IFileService fileService)
        {
            this.fileService = fileService;
        }

        private ObservableCollection<FileItem> filesList;
        public ObservableCollection<FileItem> FilesList
        {
            get
            {
                if (filesList == null)
                {
                    LoadFiles();
                }
                return filesList;
            }
            private set
            {
                filesList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("FilesList"));
                }
            }
        }

        private FileItem selectedFile;
        public FileItem SelectedFileItem
        {
            get { return selectedFile; }
            set
            {
                selectedFile = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedFileItem"));
                    SetFileContent(selectedFile);
                }
            }
        }

        private string fileContent;
        public string FileContent
        {
            get { return fileContent; }
            set
            {
                fileContent = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("FileContent"));
                }
            }
        }

        private ICommand calculateCommand;
        public ICommand CalculateCommand
        {
            get
            {
                if (calculateCommand == null)
                {
                    calculateCommand = new CalculateCommand();
                }
                return calculateCommand;
            }
        }

        private string totalValue;
        public string TotalValue
        {
            get { return totalValue; }
            set
            {
                totalValue = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("TotalValue"));
                }
            }
        }

        private async void SetFileContent(FileItem storageFile)
        {
            FileContent = await fileService.GetFileContentAsyn(storageFile);
        }

        private async void LoadFiles()
        {
            FilesList = new ObservableCollection<FileItem>(await fileService.GetFilesAsync());
        }
    }
}
