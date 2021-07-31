using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupProject.Search
{
    public class clsSearchLogic
    {
        /// <summary>
        /// delegate Action invoked when invoice is selected
        /// Invoke like this: onInvoiceSelected?.Invoke(selectedInvoice);
        /// </summary>
        public Action<Invoices> onInvoiceSelected;

        /// <summary>
        /// Variable for the selected invoice.
        /// </summary>
        public Invoices SelectedInvoice;

        /// <summary>
        /// List for invoice items.
        /// </summary>
        public List<Invoices> InvoicesList;

        /// <summary>
        /// Class for SQL Logic.
        /// </summary>
        private clsSearchSQL SearchSQL;

        /// <summary>
        /// Holds the currently selected invoice num filter.
        /// </summary>
        public int FilteredInvoiceNumber;

        /// <summary>
        /// Holds the currently selected invoice date filter.
        /// </summary>
        public DateTime FilteredInvoiceDate;

        /// <summary>
        /// Holds the currnelty selected total cost filter.
        /// </summary>
        public decimal FilteredTotalCost;

        /// <summary>
        /// Constructor for SearchLogic class.
        /// </summary>
        public clsSearchLogic()
        {
            SearchSQL = new clsSearchSQL();
            InvoicesList = SearchSQL.GetAllInvoices();
        }

        /// <summary>
        /// Invoice selection logic.
        /// </summary>
        /// <param name="invoice"></param>
        public void SelectInvoice(Invoices invoice)
        {
            try
            {
                SelectedInvoice = invoice;
                onInvoiceSelected?.Invoke(SelectedInvoice);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        //GetAllInvoices();
        //GetInvoiceByNumber(int num);
        //GetInvoicesByDate(DateTime date);
        //GetInvoicesByCost(decimal cost);
        //GetInvoicesByNumAndDate(int num, DateTime date);
        //GetInvoicesByNumAndDateAndCost(int num, DateTime date, decimal cost);
        //GetInvoicesByDateAndCost(DateTime date, decimal cost);

    }

}
