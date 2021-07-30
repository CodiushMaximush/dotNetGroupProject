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

            //test list for listview
            List<ItemDesc> items = new List<ItemDesc>();
            items.Add(new ItemDesc("A", "Test Item", (decimal)10.02));
            items.Add(new ItemDesc("A", "Test Item", (decimal)20.02));
            items.Add(new ItemDesc("A", "Test Item", (decimal)30.02));


            invoiceItemsListView.ItemsSource = items;



            
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
        }

        private void findInvoice_Click(object sender, RoutedEventArgs e)
        {
            //open search window screen
            searchWindow.Show();

        }

        private void addInvoice_Click(object sender, RoutedEventArgs e) {

          //  mainLogic.CreateInvoice();
            
        }
        private void deleteItems_Click(object sender, RoutedEventArgs e)
        {

        }
        private void deleteInvoice_Click(object sender, RoutedEventArgs e)
        {

        }


        public void UpdateUI() {


        }

       
    }
}
