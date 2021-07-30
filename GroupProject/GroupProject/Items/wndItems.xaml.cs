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
        public void SetUpIntialDataGrid() {
           DGEditItems.ItemsSource = itemsLogic.mainSQL.getItems();
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
                if (DGEditItems.SelectedIndex == -1)    // Selection is empty
                {
                    throw new InvalidOperationException("Cannot delete item, no item selected");
                }
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message);
            }
        }
        //To Do
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DGEditItems.SelectedIndex == -1)    // Selection is empty
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