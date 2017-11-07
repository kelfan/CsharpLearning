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
using System.ComponentModel;
using System.Collections.ObjectModel;

/// https://stackoverflow.com/questions/14096414/easy-way-to-refresh-listbox-in-wpf
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<MyModel> _list = new ObservableCollection<MyModel>();
        private MyModel _selectedModel;

        public MainWindow()
        {
            InitializeComponent();
            List.Add(new MyModel { Name = "James", CompanyName = "StackOverflow" });
            List.Add(new MyModel { Name = "Adam", CompanyName = "StackOverflow" });
            List.Add(new MyModel { Name = "Chris", CompanyName = "StackOverflow" });
            List.Add(new MyModel { Name = "Steve", CompanyName = "StackOverflow" });
            List.Add(new MyModel { Name = "Brent", CompanyName = "StackOverflow" });
        }

        public ObservableCollection<MyModel> List
        {
            get { return _list; }
            set { _list = value; }
        }

        public MyModel SelectedModel
        {
            get { return _selectedModel; }
            set { _selectedModel = value; NotifyPropertyChanged("SelectedModel"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
