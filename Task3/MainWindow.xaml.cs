using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int currentPage = 1;
        public int pageSize = 5;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowFiles()
        {
            DirectoryInfo directory = new(@"V:\ispp21");
            var files = directory.GetFiles("*", SearchOption.AllDirectories)
                .Select(files => new
                {
                    files.Name,
                    files.Extension,
                    files.FullName,
                    files.Length,
                    files.CreationTime
                })
                .OrderBy(files => files.FullName)
                .Skip(pageSize * (currentPage - 1))
                .Take(pageSize);

            fileDataGrid.ItemsSource = files;

            navigateTextBox.Text = currentPage.ToString();
        }

        private void NavigateTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(navigateTextBox.Text, out currentPage);
            ShowFiles();
        }
    }
}