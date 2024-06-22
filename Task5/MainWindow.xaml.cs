using System.IO;
using System.Linq;
using System.Windows;

namespace Task5
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
            DirectoryInfo directory = new DirectoryInfo(@"C:\temp");
            FileInfo[] files = directory.GetFiles("*", SearchOption.AllDirectories);
            DirectoryInfo[] directories = directory.GetDirectories("*", SearchOption.AllDirectories);


            var fileData = directories.GroupJoin(files,
            dir => dir.Name,
            file => Directory.GetParent(file.FullName).Name,
            (dir, fileGroup) => new { DirectoryName = dir.Name, FilesCount = fileGroup.Count() }).ToList();

            createDateDataGrid.ItemsSource = fileData;
        }
    }
}
