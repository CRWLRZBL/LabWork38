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

namespace LabWork38
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
                .Take(pageSize * currentPage);

            fileDataGrid.ItemsSource = files;

            pagesCountLabel.Content = $"Показано {files.Count()} из {directory.GetFiles("*", SearchOption.AllDirectories).Count()} записей";
        }

        private void ShowMoreButton_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            ShowFiles();
        }

        private void CountPageTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Int32.TryParse(countPageTextBox.Text, out pageSize);
            currentPage = 1;
            ShowFiles();
        }
    }
}