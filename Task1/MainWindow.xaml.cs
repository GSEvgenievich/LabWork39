using System.IO;
using System.Linq;
using System.Windows;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\temp\испв-21");
            FileInfo[] files = directory.GetFiles("*", SearchOption.AllDirectories);
            DirectoryInfo[] directories = directory.GetDirectories("*", SearchOption.AllDirectories);

            var fileData = files.Select(f => new { Name = f.Name, CreationDate = f.CreationTime });
            var directoryData = directories.Select(d => new { Name = d.Name, CreationDate = d.CreationTime });

            var result = fileData.Union(directoryData);

            createDateDataGrid.ItemsSource = result;
        }
    }
}
