using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FileAccessDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //private readonly StorageFolder storageFolder;
        private readonly FileDataViewModel viewModel;
        public MainPage()
        {
            this.InitializeComponent();
            //storageFolder = KnownFolders.DocumentsLibrary;
            //AddFiles();
            
            //.....
            viewModel = new FileDataViewModel(new FileService(new LoggerService()));
            this.DataContext = viewModel;
        }

        //private async void AddFiles()
        //{
        //    var filesList = await storageFolder.GetFilesAsync();
        //    cboSelectFile.ItemsSource = filesList;
        //}


        //private async void cboSelectFile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var selectedItem = ((ComboBox)sender).SelectedItem;
        //    var fileContent = await FileIO.ReadTextAsync((IStorageFile)selectedItem);
        //    LblReadFile.Text = fileContent.Split(',').Sum(num => int.Parse(num)).ToString();
        //}

        //<summary>
        //Invoked when this page is about to be displayed in a Frame.
        //</summary>
        //<param name="e">Event data that describes how this page was reached.  The Parameter
        //property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
