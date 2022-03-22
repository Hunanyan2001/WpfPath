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

namespace WpfPath
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string infoPos;
        public MainWindow()
        {
            InitializeComponent();
            getDrive();
            //string[] files = Directory.GetFiles(@"C:\Users\Lenovo\");
            //foreach (var file in files)
            //{
            //    //MessageBox.Show(file);

            //    File.Items.Add(file);
            //}
            //{
            //    string[] newfiles = Directory.GetDirectories(@"C:\Users\Lenovo\");
            //    foreach (var x in newfiles)
            //    {
            //        File.Items.Add(x);
            //    }
            //}

        }
        private void getDrive()
        {
            string[] drive = Directory.GetLogicalDrives();
            foreach (string item in drive)
            {
                disk.Items.Add(item.ToString());
            }
        }

        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string getInfoDisk = disk.SelectedItem.ToString();
            DriveInfo drive = new DriveInfo(getInfoDisk);
            string[] folders = Directory.GetDirectories(getInfoDisk);
            foreach (string f in folders)
            {
                folder.Items.Add(f.ToString());
            }
            infoPos = folder.Items.ToString();
        }
        private void folder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listoffile.Items.Clear();
            string getInfoFolders = folder.SelectedItem.ToString();
            string[] files = Directory.GetFiles(getInfoFolders);
            foreach (string fl in files )
            {
                listoffile.Items.Add(fl.ToString());
            }
            infoPos = listoffile.Items.ToString();
        }

        private void files_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CreateFolder_Click(object sender, RoutedEventArgs e)
        {

            string path1 = inputNameOnFolder.Text;
            string fullpath = System.IO.Path.Combine(@"C:\",path1 );
            // Create directory temp if it doesn't exist
            if (!Directory.Exists(fullpath))
            {
                Directory.CreateDirectory(fullpath);
            }
            else
            {
                MessageBox.Show("Such a file already exists");
            }
        }
        private void DeleteFolder_Click(object sender, RoutedEventArgs e)
        {
            string infoDelete = folder.SelectedItem.ToString();
            if (Directory.Exists(infoDelete))
            {
                Directory.Delete(infoDelete);
                MessageBox.Show("Folder is Deleted");
            }
            else
            {
                MessageBox.Show("Folder is Not Exsist");
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

