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
using RAP.Research;
using RAP.Control;

namespace RAP.Views
{
    /// <summary>
    /// Interaction logic for ResearcherDetailView.xaml
    /// </summary>
    public partial class ResearcherDetailView : Page
    {
        
        // the variable to store the details of current researcher 
        public Researcher curResearcher { set; get; }
        // the method to initiate the page when it si first create
        public ResearcherDetailView()
        {
            InitializeComponent();
        }

        // the button to show the barchart of publications numbers by years
        private void cumulativeCountBtn_Click(object sender, RoutedEventArgs e)
        {
            // create a new window to display the cumulativeCountView 
            Window cumulativeCountWindow = new Window();
            // create a new CumulativeCountView to display the barchart of publications numbers by years
            CumulativeCountView cumulativeCountView = new CumulativeCountView();
            // get the current researcher's publication data by years 
            cumulativeCountView.DataContext = PublicationsController.genPublicationYearData(curResearcher);
            // display the cummulativeCountView on the new window
            cumulativeCountWindow.Content = cumulativeCountView;
            // adjust the window size to the contents
            cumulativeCountWindow.SizeToContent=SizeToContent.WidthAndHeight;
            // set the startup location of the windows in the center of the screen
            cumulativeCountWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            // diplay the new window
            cumulativeCountWindow.Show();
            // bring the new window to the front
            cumulativeCountWindow.Activate();
        }

        private void showNameBtn_Click(object sender, RoutedEventArgs e)
        {
            // create a new window to display the supervisionView
            Window showNameWindow = new Window();
            // acquire the list of students under current researcher 
            List<Student> supervisionList = Control.ResearcherController.LoadSupervisionStudents(curResearcher);
            // create a new supervisionView to display the list of students
            SupervisionView supervisionView = new SupervisionView();
            // pass the list of students the listbox in the new supervisionView
            supervisionView.supervisionListbox.ItemsSource = supervisionList;
            // display the supervisionView in the new window
            showNameWindow.Content = supervisionView;
            // adjust the window size to the contents
            showNameWindow.SizeToContent = SizeToContent.WidthAndHeight;
            // set the startup location of the windows in the center of the screen
            showNameWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            // diplay the new window
            showNameWindow.Show();
            // bring the new window to the front
            showNameWindow.Activate();
        }
    }
}
