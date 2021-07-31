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
        /// <summary>
        /// item logic decimal select costs last
        /// </summary>
        private decimal lastSelectCost;
        /// <summary>
        /// item logic  select costs last string
        /// </summary>
        private string lastSelectCode;
        /// <summary>
        /// item logic string select description
        /// </summary>
        private string lastSelectDesc;
        /// <summary>
        /// constructor for items and methods
        /// </summary>
        public wndItems()
        {
            InitializeComponent();
            itemsLogic = new clsItemsLogic();
            HideNewItemControls();
        }
        /// <summary>
        /// refreshs the data grid
        /// </summary>
        public void RefreshDataGrid() {
           DGEditItems.ItemsSource = itemsLogic.GetItems();
           DGEditItems.CanUserAddRows = false; //To get rid of the extra row on the bottom of the DataGrid
           DGEditItems.Columns[0].IsReadOnly = true; // primary key cannot be edited
        }

        /// <summary>
        /// add click method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ShowNewItemControls();
        }
        /// <summary>
        /// hiding form controls
        /// </summary>
        private void HideNewItemControls() {
            LblNewItem.Visibility = Visibility.Hidden;
            txtItemCode.Visibility = Visibility.Hidden;
            txtItemCost.Visibility = Visibility.Hidden;
            txtItemDesc.Visibility = Visibility.Hidden;
            BtnItemSubmit.Visibility = Visibility.Hidden;

        }
        /// <summary>
        /// showing item controls
        /// </summary>
        private void ShowNewItemControls()
        {
            LblNewItem.Visibility = Visibility.Visible;
            txtItemCode.Visibility = Visibility.Visible;
            txtItemCost.Visibility = Visibility.Visible;
            txtItemDesc.Visibility = Visibility.Visible;
            BtnItemSubmit.Visibility = Visibility.Visible;
        }


        /// <summary>
        ///  deletes selected item in datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HideNewItemControls();
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
        /// <summary>
        /// editing click button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HideNewItemControls();

                int selectedItemIndex = DGEditItems.SelectedIndex;
                if (selectedItemIndex == -1)    // Selection is empty
                {
                    throw new InvalidOperationException("Cannot edit item, no item selected");
                }

                else
                {
                    ItemDesc selectedItem = null;
                    if (DGEditItems.SelectedItem is ItemDesc)
                    {
                        selectedItem = (ItemDesc)DGEditItems.SelectedItem;
                    }
                    itemsLogic.EditItem(selectedItem, lastSelectCode);
                }

            }
            
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message);
            }
            catch(Exception ex)
            {
                if (ex.Message == "clsDataAccess.ExecuteSQLStatement -> Cannot find table 0.")
                {
                    MessageBox.Show("Item updated");
                    RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
        /// <summary>
        /// editing changing fields when selecting a row/column.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGEditItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedItemIndex = DGEditItems.SelectedIndex;
            if(selectedItemIndex != -1)
            {
                ItemDesc selectedItem = null;
                if (DGEditItems.SelectedItem is ItemDesc)
                {
                    selectedItem = (ItemDesc)DGEditItems.SelectedItem;
                    lastSelectCode = selectedItem.Code;
                    lastSelectDesc = selectedItem.Desc;
                    lastSelectCost = selectedItem.Cost;
                }

            }
        }
        /// <summary>
        /// button for item submit 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnItemSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ItemDesc newItem = new ItemDesc(txtItemCode.Text,txtItemDesc.Text,decimal.Parse(txtItemCost.Text));
                itemsLogic.AddItem(newItem);

            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }
            catch(Exception ex)
            {
                if (ex.Message == "clsDataAccess.ExecuteSQLStatement -> Cannot find table 0.")
                {
                    MessageBox.Show("Item added");
                    HideNewItemControls();
                    RefreshDataGrid();

                }
                else
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}