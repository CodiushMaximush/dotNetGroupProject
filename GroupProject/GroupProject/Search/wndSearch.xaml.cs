using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public List<Invoices> InvoicesList;

        public List<decimal> CostsList;

        public List<Invoices> FilteredInvoicesList;

        public int SelectedNum;

        public DateTime SelectedDate;

        public decimal SelectedCost;

        /// <summary>
        /// Search Window Constructor.
        /// </summary>
        public wndSearch()
        {
            InitializeComponent();
            searchLogic = new clsSearchLogic();
            SelectedNum = -1;
            SelectedCost = -1;
            SelectedDate = DateTime.Now;
            InvoicesList = new List<Invoices>();
            InvoicesList = searchLogic.GetAllInvoices();
            CostsList = new List<decimal>();

            // Fill invoice number combo box and add items to costs list.
            foreach (Invoices invoice in InvoicesList)
            {
                cbInvoiceNumber.Items.Add(invoice.Num);
                CostsList.Add(invoice.TotalCost);
            }

            // Sort the costs list.
            CostsList.Sort();

            // Add costs list items to charges combo box.
            foreach (decimal cost in CostsList)
            {
                cbTotalCharges.Items.Add(cost);
            }
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
                // Check if a selection has been made.
                if (cbInvoiceNumber.SelectedIndex != -1)
                {
                    // Set the SelectedNum variable to the selected item.
                    SelectedNum = (int)cbInvoiceNumber.SelectedItem;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
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
                // Check if a selction has been made.
                if (cbTotalCharges.SelectedIndex != -1)
                {
                    // Set the SelectedCost variable to the selected item.
                    SelectedCost = (decimal)cbTotalCharges.SelectedItem;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
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
                // Check if a selection has been made.
                if (dpInvoiceDatePicker.SelectedDate != null)
                {
                    // Set SelectedDate variable to the selected date item.
                    SelectedDate = (DateTime)dpInvoiceDatePicker.SelectedDate;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
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
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
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
                // Reset the selections.
                dpInvoiceDatePicker.SelectedDate = null;
                cbInvoiceNumber.SelectedIndex = -1;
                cbTotalCharges.SelectedIndex = -1;
                SelectedNum = -1;
                SelectedDate = DateTime.Now;
                SelectedCost = -1;

                lvInvoiceList.ItemsSource = InvoicesList;
                //// Refill the list
                //foreach(Invoices invoice in InvoicesList)
                //{
                //    lvInvoiceList.Items.Add(invoice);
                //}
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        //private void FillInvoiceList()
        //{
        //    foreach (Invoices invoice in InvoicesList)
        //    {
        //        lvInvoiceList.Items.Add(invoice);
        //    }
        //}

        /// <summary>
        /// Error handling method.
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
    }
}
