using GroupProject.Items;
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

namespace GroupProject.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        /// <summary>
        /// business logic class
        /// </summary>
        public clsMainLogic mainLogic;
        

        public wndItems itemsWindow;
        public wndSearch searchWindow;

        
        public wndMain()
        {
            InitializeComponent();

            //initialize windows
            itemsWindow = new wndItems();
            searchWindow = new wndSearch();
            //initialize logic
            mainLogic = new clsMainLogic();

            //register our listeners
            searchWindow.searchLogic.onInvoiceSelected += mainLogic.SelectInvoice;
            mainLogic.dataUpdated += UpdateUI;

           
            //disable invoice controls until we select an invoice
            invoiceControls.IsEnabled = false;

        }
        /// <summary>
        /// called when editItems menu item is clicked. Opens the 'wndItems.xaml'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editItems_Click(object sender, RoutedEventArgs e)
        {
            //open edit items screen
            itemsWindow.Show();
            itemsWindow.RefreshDataGrid();
        }
        /// <summary>
        /// called when findInvoice menu item is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findInvoice_Click(object sender, RoutedEventArgs e)
        {
            //open search window screen
            searchWindow.Show();
            
        }
        /// <summary>
        /// called hwen hte addInvoice menu item is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addInvoice_Click(object sender, RoutedEventArgs e) {
            //tell our logic to create a new invoice
            mainLogic.CreateInvoice();
            invoiceControls.IsEnabled = false;
            
        }
        /// <summary>
        /// called when the deleteItems button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteItems_Click(object sender, RoutedEventArgs e)
        {
            //tell our logic to delete all the items we have selected in our itembox
            mainLogic.DeleteItems(invoiceItemsListView.SelectedItems.Cast<ItemDesc>().ToList());
        }
        /// <summary>
        /// called when the delete invoice button is clcked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            //tell our logic to delet the current invoice
            mainLogic.DeleteInvoice();
        }

        /// <summary>
        /// called by the main logic whenever the data behind is updated
        /// </summary>
        public void UpdateUI() {

            //populate available items
            availableItems.ItemsSource = mainLogic.GetAvailableItems();
            // if we have an invoice selected
            if (mainLogic.currentInvoice != null)
            {
                // populate items
                invoiceItemsListView.ItemsSource = mainLogic.invoiceItems;
                //enable controls
                invoiceControls.IsEnabled = true;
                //enable item list
                invoiceItemBox.IsEnabled = true;
                //enable stats
                detailsBox.IsEnabled = true;
                currentInvoiceCost.Content = mainLogic.currentInvoice.TotalCost.ToString();
                currentInvoiceDate.Content = mainLogic.currentInvoice.Date.ToString();
                currentInvoiceNumber.Content = mainLogic.currentInvoice.Num.ToString();

            }
            else {
                //clear items
                invoiceItemsListView.ItemsSource = null;
                //disable controls
                invoiceControls.IsEnabled = false;
                //disable item list
                invoiceItemBox.IsEnabled = false;
                //disable stats
                detailsBox.IsEnabled = false;
                currentInvoiceCost.Content = "";
                currentInvoiceDate.Content = "";
                currentInvoiceNumber.Content = "";

            }



        }
        /// <summary>
        /// called whenever add item button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (availableItems.SelectedItem != null) {//if we actually have something selected in out combobox
                //tell our logic to add the item selected in the available items combobox to our selected invoice
                mainLogic.AddItem((ItemDesc)availableItems.SelectedItem);

            }

        }
        /// <summary>
        /// called when change date button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if our date is selected
            if (datePicker.SelectedDate.HasValue) {
                mainLogic.ChangeDate(datePicker.SelectedDate.Value);
            }
        }

        private void UnlockControlsButton_Click(object sender, RoutedEventArgs e)
        {
            invoiceControls.IsEnabled = !invoiceControls.IsEnabled;
        }
    }
}
