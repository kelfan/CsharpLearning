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
using RAP;

namespace RAP.Views
{
    /// <summary>
    /// Interaction logic for ResearcherListView.xaml
    /// </summary>
    public partial class ResearcherListView : Page
    {
        // a variable to record whether the researcherListView is first time created
        private int listviewOpenTimes = 0;
        // create a new researcherDetailsView
        public ResearcherDetailView researcherDetailsView = new ResearcherDetailView();
        // create a new publicationListView 
        public PublicationListView publicationListView = new PublicationListView();
        // refresh the components and contents in the comboBox and the listBox
        public ResearcherListView()
        {
            InitializeComponent();
            // deisplay the researcher details in the ResearcherDetailFrame
            this.ResearcherDetailFrame.Content = researcherDetailsView;
            // display publication information in the publicationListFrame
            this.researcherDetailsView.PublicationListFrame.Content = publicationListView;
        }

        // take actions when the user select a item in the comboBox
        private void ResearcherLevelFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // acquire the level selected by the user 
            EmploymentLevel item = (EmploymentLevel)ResearcherLevelFilter.SelectedItem;
            // refresh the researcher list with the filtered list 
            ResearcherListBox.ItemsSource = Control.ResearcherController.FilterBy(item);
        }

        // take actions when the user input any letters in the textBox
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // acquire the text input by the user
            string text_input = ResearcherNameTextbox.Text.ToString();
            // filter the researcher list with the user's input text
            ResearcherListBox.ItemsSource = ResearcherController.FilterByName(text_input);
        }

        // take actions when an item in the listBox is selected by the user
        private void ResearcherListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.ResearcherListBox.SelectedItem != null)
            {
                // Get the currently selected item in the ListBox.
                Researcher curItem = (Researcher)e.AddedItems[0];
                // get the researcher details from the researcher controller
                Researcher researcherDetails = ResearcherController.LoadResearcherDetails(curItem);
                // get the publication list of the selected researcher from the publication controller
                List<Publication> publicationList = PublicationsController.loadPublicationsFor(curItem);
                // if it is the first to click on a item, make the researcherDetailsView visible
                if (listviewOpenTimes == 0)
                {
                    researcherDetailsView.Visibility = Visibility.Visible;
                    listviewOpenTimes = 1;
                }

                // disable the visibility of the publicationListView 
                if (researcherDetailsView.PublicationDetailFrame.Visibility == Visibility.Visible)
                {
                    researcherDetailsView.PublicationDetailFrame.Visibility = Visibility.Hidden;
                }

                // pass the researcherDetailsView to the upper level to display
                publicationListView.parentResearcherDetailView = researcherDetailsView;
               
                // pass the publicationList to the publicationListView
                publicationListView.publicationListView.ItemsSource = publicationList;
                publicationListView.localPublicationList = publicationList;
                publicationListView.allPulicationList = publicationList;
               
                // acquire the publication years for the filter of years 
                List<int> yearList = Control.PublicationsController.fetchPublicationYearList(curItem);
                
                // display the list of years in the fromCombobox & toCombobox in the publicationListView
                publicationListView.fromCombobox.ItemsSource = yearList;
                publicationListView.toCombobox.ItemsSource = yearList;
                
                // reset the publication list status in true to be as in a ascending list 
                publicationListView.publicationListState = true;

                // researcherDetailsView.curResearcher = researcherDetails;
                researcherDetailsView.DataContext = researcherDetails;
                researcherDetailsView.curResearcher = curItem;

                // if the selected people is a student then the supervision column would not be displayed and the supervision button also would be disabled
                if (curItem.Level.ToString() == "Student")
                {
                    researcherDetailsView.supervisionsLabel.Visibility = Visibility.Hidden;
                    researcherDetailsView.showNameBtn.IsEnabled = false;
                }
                // else the supervision numbers would be displayed.
                else
                {
                    researcherDetailsView.supervisionsLabel.Visibility = Visibility.Visible;
                    // if the supervision numbers is more than zero, then the supervision button "show name" will be displayed
                    if (researcherDetails.Supervisions > 0 )
                    {
                        researcherDetailsView.showNameBtn.IsEnabled = true;
                    }
                    else
                    {
                        researcherDetailsView.showNameBtn.IsEnabled = false;
                    }

                }

                // if the publicationList of the selecled researcher is null then disable the search, invert and cumlative count buttons
                if (publicationList == null)
                {
                    publicationListView.searchBtn.IsEnabled = false;
                    publicationListView.invertBtn.IsEnabled = false;
                    researcherDetailsView.cumulativeCountBtn.IsEnabled = false;
                }
                else
                {
                    publicationListView.searchBtn.IsEnabled = true;
                    publicationListView.invertBtn.IsEnabled = true;
                    researcherDetailsView.cumulativeCountBtn.IsEnabled = true;
                }
            }
        }
    }
}
