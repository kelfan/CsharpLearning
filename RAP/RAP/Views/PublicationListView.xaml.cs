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
using RAP.Control;
using RAP.Research;

namespace RAP.Views
{
    /// <summary>
    /// Interaction logic for PublicationListView.xaml
    /// </summary>
    
    public partial class PublicationListView : Page
    {
        //define a variable to receive researcher object from researcher list view 
        public Researcher localResearcher { set; get; }
        //define a variable to receive researcherDetailView from researcher list view 
        public ResearcherDetailView parentResearcherDetailView { set; get; }
        // define a variable to receive the publication list of the researcher
        public List<Publication> localPublicationList { get; set; }
        // define a varibale to recive all publication list from the researcher 
        public List<Publication> allPulicationList { get; set; }
        // define a varibale to record the start year of publications selected by the user
        private int startYear;
        // define a varibale to record the end year of publications selected by the user
        private int endYear;
        // define a bool varible to record that the state of the list is in ascending or descending order, true is in ascending order
        public bool publicationListState = true;
        //create a publicationView to display publication's details
        PublicationDetailView publicationView = new PublicationDetailView();

        public PublicationListView()
        {
            InitializeComponent();
        }
        
        // take action when the user select a publication in the publicationListView
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // initial data context in publicationView into null
            publicationView.DataContext = null;
            // display the publication details in the publicationDetailFrame
            parentResearcherDetailView.PublicationDetailFrame.Content = publicationView;
            // if the user select a publication from the list 
            if (this.publicationListView.SelectedItem != null)
            {
                // the publicationView to display the selected publication 
                publicationView.DataContext = e.AddedItems[0];
                // display the pulicationView in the publicationDetailFrame of the ResearcherDetailView 
                parentResearcherDetailView.PublicationDetailFrame.Content = publicationView;
                // make the publicationDetailFrame visible 
                parentResearcherDetailView.PublicationDetailFrame.Visibility = Visibility.Visible;
            }
        }

        private void invertBtn_Click(object sender, RoutedEventArgs e)
        {
            // if there is a selection of publication from the publication list
            if (localPublicationList.Count > 1)
            {
                // if the publication list state is ascending (true), then invert into descending order
                if (publicationListState)
                {
                    publicationListView.ItemsSource = Control.PublicationsController.invert(localPublicationList, "des");
                }
                // else present the list in ascending order
                else
                {
                    publicationListView.ItemsSource = Control.PublicationsController.invert(localPublicationList, "asc");
                }
                // change the pulication list state in a opposite direction 
                publicationListState = !publicationListState;

            }

        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            // there is no publication list or start year or end year selected by the user 
            if (startYear != 0 && endYear != 0 && localPublicationList != null)
            {
                // if the user select a start year is less than a end year 
                if (startYear <= endYear)
                {
                    // filter the publication list based on the start year and end year 
                    localPublicationList=RAP.Control.PublicationsController.search(allPulicationList, startYear, endYear);
                    // display the filtered list to the publicationListView
                    publicationListView.ItemsSource = localPublicationList;
                }
                else
                {
                    // dispaly a error message 
                    MessageBox.Show("Start year should be smaller than end year.");
                }
            }
            else
            {
                // display a error message 
                MessageBox.Show("Start year or end year for search is missed.");
            }
        }

        // acquire the value for start year in the filtering of search years
        private void fromCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                // record the start year for the filter  
                startYear = (int)e.AddedItems[0];
            }
        }

        // acquire the value for end year in the filtering of search years
        private void toCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                // record the end year for the filter 
                endYear = (int)e.AddedItems[0];
            }
        }
    }
}
