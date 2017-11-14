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
        // a lists of content to handle by different actions 
        List<Cell> cells = new List<Cell>();
        List<Cell> selectedCells = new List<Cell>();
        Cell currentCell = new Cell();

        public MainWindow()
        {
            InitializeComponent();
            cells = Data.FreData.getData();
            selectedCells = cells;
            itemlist.ItemsSource = cells;
        }


        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.itemlist.SelectedItem != null)
            {
                currentCell = (Cell)e.AddedItems[0];
                inputflow.DataContext = currentCell;
            }
        }

        // open file button action 
        private void openBtn_Click(object sender, RoutedEventArgs e)
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
            catch (FileNotFoundException)
            {
                MessageBoxResult rt = System.Windows.MessageBox.Show("main app.json cannot be found ");
            }
        }

        // add cell button logic 
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            string titleTxt = titleInput.Text;
            string contentTxt = contentInput.Text;
            if (titleTxt != "")
            {
                cells.Add(new Cell() { title = titleTxt, content = contentTxt, created = System.DateTime.Now });
                cells = control.ListHandler.sortCells(cells);
                itemlist.Items.Refresh();
                int lastId = cells.Count() - 1;
                currentCell = cells[lastId];
                Data.FreData.saveData(cells);
                itemlist.Items.Refresh();
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            cells.Remove(currentCell);
            cells = control.ListHandler.sortCells(cells);
                Data.FreData.saveData(cells);
            itemlist.Items.Refresh();
        }

        private void newBtn_Click(object sender, RoutedEventArgs e)
        {
            inputflow.DataContext = null;
            titleInput.Clear();
            contentInput.Clear();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            FreData.saveData(cells);
            System.Windows.MessageBox.Show("saved.");
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            string titleTxt = titleInput.Text;
            string contentTxt = contentInput.Text;
            int idx = cells.IndexOf(currentCell);
            if (titleTxt != "" && idx >= 0)
            {
                cells[idx].title = titleTxt;
                cells[idx].content = contentTxt;
                cells[idx].updated = System.DateTime.Now;
                cells = control.ListHandler.sortCells(cells);
                Data.FreData.saveData(cells);
                itemlist.Items.Refresh();
                System.Windows.MessageBox.Show("updated.");
            }
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            cells = Data.FreData.getData();
            itemlist.ItemsSource = cells;
            itemlist.Items.Refresh();
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTxt = searchBox.Text.ToLower();
            string[] searchTerms = searchTxt.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
            selectedCells = cells;

            foreach (string term in searchTerms)
            {
                var selected = from Cell c in selectedCells
                               where c.title.ToLower().Contains(term)
                               select c;
                selectedCells = (List<Cell>)selected.ToList();
            }
            selectedCells = control.ListHandler.sortCells(selectedCells);
            itemlist.ItemsSource = selectedCells;
            itemlist.Items.Refresh();
        }
    }
}
