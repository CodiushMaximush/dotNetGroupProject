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

        /// <summary>
        /// List for invoices.
        /// </summary>
        public List<Invoices> InvoicesList;

        /// <summary>
        /// List for costs.
        /// </summary>
        public List<decimal> CostsList;

        /// <summary>
        /// The selected num.
        /// </summary>
        public int? SelectedNum;

        /// <summary>
        /// The selected date.
        /// </summary>
        public DateTime? SelectedDate;

        /// <summary>
        /// The selected cost.
        /// </summary>
        public decimal? SelectedCost;

        /// <summary>
        /// Search Window Constructor.
        /// </summary>
        public wndSearch()
        {
            InitializeComponent();
            searchLogic = new clsSearchLogic();
            SelectedNum = null;
            SelectedCost = null;
            SelectedDate = null;
            InvoicesList = new List<Invoices>();
            InvoicesList = searchLogic.GetAllInvoices();
            CostsList = searchLogic.GetCosts();
            CostsList.Sort();

            // Fill invoice number combo box and add items to costs list.
            foreach (Invoices invoice in InvoicesList)
            {
                cbInvoiceNumber.Items.Add(invoice.Num);
            }

            // Add costs list items to charges combo box.
            foreach (decimal cost in CostsList)
            {
                cbTotalCharges.Items.Add(cost);
            }

            // Fill items list
            foreach (Invoices invoice in InvoicesList)
            {
                lvInvoiceList.Items.Add(invoice);
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
                    // Filter the list
                    FilterList();
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
                    // Filter the list
                    FilterList();
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
                    // Filter the list
                    FilterList();
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
                searchLogic.SelectInvoice((Invoices)lvInvoiceList.SelectedItem);
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
                InvoicesList.Clear();

                InvoicesList = searchLogic.GetAllInvoices();

                foreach (Invoices invoice in InvoicesList)
                {
                    lvInvoiceList.Items.Add(invoice);
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Filter the invoices list by the things that have been selected.
        /// </summary>
        private void FilterList()
        {
            List<Invoices> filteredList = new List<Invoices>();

            if (SelectedNum != null && SelectedDate == null && SelectedCost == null)
            {
                filteredList = searchLogic.GetInvoiceByNumber((int)SelectedNum);
            }
            else if (SelectedNum != null && SelectedDate != null && SelectedCost == null)
            {
                filteredList = searchLogic.GetInvoicesByNumAndDate((int)SelectedNum, (DateTime)SelectedDate);
            }
            else if (SelectedNum != null && SelectedDate != null && SelectedCost != null)
            {
                filteredList = searchLogic.GetInvoicesByNumAndDateAndCost((int)SelectedNum, (DateTime)SelectedDate, (decimal)SelectedCost);
            }
            else if (SelectedNum == null && SelectedDate != null && SelectedCost == null)
            {
                filteredList = searchLogic.GetInvoicesByDateAndCost((DateTime)SelectedDate, (decimal)SelectedCost);
            }
            else if (SelectedNum == null && SelectedDate == null && SelectedCost != null)
            {
                filteredList = searchLogic.GetInvoicesByCost((decimal)SelectedCost);
            }
            else if (SelectedNum == null && SelectedDate != null && SelectedCost == null)
            {
                filteredList = searchLogic.GetInvoicesByDate((DateTime)SelectedDate);
            }

            InvoicesList.Clear();

            InvoicesList = filteredList;

            lvInvoiceList.Items.Clear();

            foreach (Invoices invoice in InvoicesList)
            {
                lvInvoiceList.Items.Add(invoice);
            }
        }

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
