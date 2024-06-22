using System.IO;
using System.Linq;
using System.Windows;

namespace Task2
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

            var fileData = files.GroupBy(f => f.Extension)
                .Select(group => new
                {
                    Extension = group.Key,
                    TotalSize = group.Sum(file => file.Length),
                    FileCount = group.Count()
                }).ToList();

            createDateDataGrid.ItemsSource = fileData;
        }
    }
}
