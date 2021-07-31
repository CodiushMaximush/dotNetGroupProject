using GroupProject.Items;
using GroupProject.Main;
using GroupProject.Search;
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
using System.Windows.Shapes;

namespace GroupProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        /// <summary>
        /// business logic class
        /// </summary>
        public clsItemsLogic itemsLogic;
        
        public wndItems()
        {
            InitializeComponent();
            itemsLogic = new clsItemsLogic();

        }
        public void RefreshDataGrid() {
           DGEditItems.ItemsSource = itemsLogic.GetItems();
           DGEditItems.CanUserAddRows = false; //To get rid of the extra row on the bottom of the DataGrid

        }

        //To Do
        private void DGEditItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //To Do
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
        //To Do
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int selectedItemIndex = DGEditItems.SelectedIndex;
                if (selectedItemIndex == -1)    // Selection is empty
                {
                    throw new InvalidOperationException("Cannot delete item, no item selected");
                }
                else
                {
                    ItemDesc selectedItem = null;
                    if (DGEditItems.SelectedItem is ItemDesc)
                    {
                        selectedItem = (ItemDesc)DGEditItems.SelectedItem;
                    }
                    itemsLogic.DeleteItem(selectedItem);
                }
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message);
            }
            catch (Exception ex) {
                if (ex.Message == "clsDataAccess.ExecuteSQLStatement -> Cannot find table 0.") {
                    MessageBox.Show("Item has been deleted");
                    RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //To Do
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int selectedItemIndex = DGEditItems.SelectedIndex;
                if (selectedItemIndex == -1)    // Selection is empty
                {
                    throw new InvalidOperationException("Cannot edit item, no item selected");
                }
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message);
            }

        }
    }
}