using System;
using System.Collections.Generic;
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
using System.Windows.Forms;
using System.Data;
using System.IO;
using csharpDB.model;
using csharpDB.Data;

namespace csharpDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            itemlist.ItemsSource = Data.FreData.getData();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.itemlist.SelectedItem != null)
            {
                inputflow.DataContext = e.AddedItems[0];
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result;
            string path; 
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                result = dialog.ShowDialog();
                path = dialog.SelectedPath;
            }
            csharpDB.Data.FreData.filefolder = path;
            try
            {
                itemlist.ItemsSource = Data.FreData.getData();
            }
            catch (FileNotFoundException ex)
            {
                MessageBoxResult rt = System.Windows.MessageBox.Show("main app.json cannot be found ");
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            string titleTxt = titleInput.Text;
            string contentTxt = contentInput.Text;
            if (titleTxt != "" && contentTxt != "")
            {
                Cell c = new Cell();
                c.title = titleTxt;
                c.content = contentTxt;
                List<Cell> cs = (List<Cell>)itemlist.ItemsSource;
                cs.Add(c);
                itemlist.ItemsSource = cs;
                itemlist.Items.Refresh();
            }
        }
    }
}
