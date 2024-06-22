using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace Task4
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

            DateTime today = DateTime.Today;
            var todayDirectories = directories.Where(d => d.CreationTime.Date == today).ToList();

            var fileData = files.Join(todayDirectories,
            file => Directory.GetParent(file.FullName).Name,
            directory => directory.Name,
            (file, directory) => new { file.Name, directory.CreationTime })
            .ToList();

            createDateDataGrid.ItemsSource = fileData;
        }

    }
}
