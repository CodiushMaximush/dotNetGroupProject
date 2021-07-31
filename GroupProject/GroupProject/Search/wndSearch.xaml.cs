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

namespace GroupProject.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        /// <summary>
        /// Class to handle Search window logic.
        /// </summary>
        public clsSearchLogic searchLogic;

        /// <summary>
        /// Search Window Constructor.
        /// </summary>
        public wndSearch()
        {
            InitializeComponent();
            searchLogic = new clsSearchLogic();
        }

        /// <summary>
        /// Get list of invoices based on selected invoice number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbInvoiceNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbInvoiceNumber.SelectedIndex != -1)
                {
                    // Filter list based on cbInvoiceNumber.SelectedItem
                }
            }
            catch (Exception ex)
            {
                // throw appropriate exception
            }
        }

        /// <summary>
        /// Get list of invoices based on selected total charges.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTotalCharges_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbTotalCharges.SelectedIndex != -1)
                {
                    // Filter list based on cbTotalCharges.SelectedItem
                }
            }
            catch (Exception ex)
            {
                // throw appropriate exception
            }
        }

        /// <summary>
        /// Get list of invoices based on selected date.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpInvoiceDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dpInvoiceDatePicker.SelectedDate != null)
                {
                    // Filter list based on dpInvoiceDatePicker.SelectedDate
                }
            }
            catch (Exception ex)
            {
                // throw appropriate exception
            }
        }

        /// <summary>
        /// Get the selected invoice and send to main window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get Selected row info
                // Invoke action from SearchLogic
                Close();
            }
            catch(Exception ex)
            {
                // Throw exception
            }
        }

        /// <summary>
        /// Reset the search options to initial state and get full invoice list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dpInvoiceDatePicker.SelectedDate = null;
                cbInvoiceNumber.SelectedIndex = -1;
                cbTotalCharges.SelectedIndex = -1;
                // Fill combo boxes with unfiltered data
            }
            catch (Exception ex)
            {
                // Throw exception
            }
        }

    }
}
