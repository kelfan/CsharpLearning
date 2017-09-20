﻿using System;
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

namespace bindComboBoxString
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Apple");
            data.Add("Mongo");
            data.Add("Grapes");
            var combo = sender as ComboBox;
            combo.ItemsSource = data;
            combo.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedcomboitem = sender as ComboBox;
            string name = selectedcomboitem.SelectedItem as string;
            MessageBox.Show(name);
        }
        
    }
}
