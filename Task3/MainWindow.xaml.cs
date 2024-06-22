using System.IO;
using System.Linq;
using System.Windows;

namespace Task3
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

            var fileData = files.GroupBy(f => new { f.CreationTime.Year, f.CreationTime.Month })
                .Select(group => new
                {
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                    FileCount = group.Count()
                }).ToList();

            createDateDataGrid.ItemsSource = fileData;
        }
    }
}
