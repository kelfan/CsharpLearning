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

namespace RAP.Views.userControls
{
    /// <summary>
    /// Interaction logic for labelTextboxUC.xaml
    /// </summary>
    public partial class labelTextboxUC : UserControl
    {
        public static DependencyProperty ucTextboxValueProperty = DependencyProperty.Register("ucTextboxValue", typeof(string), typeof(labelValuesUC), new PropertyMetadata(null));

        public labelTextboxUC()
        {
            InitializeComponent();
        }

        public string ucTextboxValue
        {
            get { return (string)GetValue(ucTextboxValueProperty); }
            set { SetValue(ucTextboxValueProperty, value); }
        }


    }
}
