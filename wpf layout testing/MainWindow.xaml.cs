using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_layout_testing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        DirectoryInfo di = new DirectoryInfo("C:\\");
        public MainWindow()
        {
            InitializeComponent();
            locationChanged();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            drives drive = sdLocation.SelectedItem as drives;
            string location = drive.name;
            
            di = new DirectoryInfo(location);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        private void locationChanged()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo i in allDrives)
            {
                if (i.IsReady == true)
                {
                    drives drives = new drives();
                    drives.driveSize = (double.Parse(i.TotalSize.ToString()) / 1000000000).ToString("N1").ToString() + " GB";
                    drives.name = i.Name + "\\";
                    drives.driveDescription = $"{drives.name} {drives.driveSize}";
                    sdLocation.Items.Add(drives);
                }
                else
                {

                }
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }
    }

    public class drives
    {
        public string name { get; set; } = string.Empty;
        public string driveSize { get; set; } = string.Empty;
        public string driveDescription { get; set; } = string.Empty;
    }
}
