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
using HRIS.Entity;

namespace HRIS.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //This data is obviously something that would go in the control classes, not the GUI
        private int current = 0;
        private List<Object> things = new List<Object>();

        public MainWindow()
        {
            InitializeComponent();

            //Let's create some objects
            things.Add(new Person { Name = "A", DOB = new DateTime(1989, 04, 24), Weight = 60.4 });
            things.Add(new SportsBall { Age = 2, Weight = 0.4 });
            things.Add(new Person { Name = "B", DOB = new DateTime(1981, 07, 17), Weight = 75.0 });
            things.Add(new SportsBall { Age = 6, Weight = 1.2 });
        }

        private void btnDemo_Click(object sender, RoutedEventArgs e)
        {
            //lstList.ItemsSource = things;

            DetailsPanel.DataContext = things[current];
            current = (current + 1) % things.Count;
        }

    }
}
