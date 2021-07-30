using GroupProject.Items;
using GroupProject.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Main
{
    public class clsMainLogic
    {
        /// <summary>
        /// called whenever UI needs to be updated because data changed. 
        /// </summary>
        public Action dataUpdated;

        /// <summary>
        /// cursor object for current invoice
        /// </summary>
        public Invoices currentInvoice;
        /// <summary>
        /// list of items in invoice
        /// </summary>
        public List<ItemDesc> invoiceItems;
        /// <summary>
        /// list of items available in database
        /// </summary>
        public List<ItemDesc> availableItems;
        /// <summary>
        /// class containing abstracted SQL queries
        /// </summary>
        private clsMainSQL mainSQL = new clsMainSQL();
        /// <summary>
        /// default constructor
        /// </summary>
        public clsMainLogic() {
            availableItems = mainSQL.GetAllItems();

        }
       /// <summary>
       /// sets cursor to new invoice then gets it's items from the database to display. should be triggered by search window using an Action. 
       /// </summary>
       /// <param name="newInvoice"></param>
        public void SelectInvoice(Invoices newInvoice) {
            currentInvoice = newInvoice;
            //get items for current invoice
            invoiceItems = mainSQL.getInvoiceItems(currentInvoice);
            
            dataUpdated?.Invoke();
        }
        /// <summary>
        /// adds a new invoice to the database then sets it to the current invoice. also invokes dataupdated
        /// </summary>
        public void CreateInvoice() {
            //insert a new invoice into the database
            mainSQL.insertNewInvoice();
            //set currentInvoice to newest invoice from database
            currentInvoice = mainSQL.getMaxInvoice();
            dataUpdated?.Invoke();
        }
        /// <summary>
        /// deletes current invoice from the database and sets currentInvoice to null, triggers dataupdated
        /// </summary>
        public void DeleteInvoice() {
            //delete current invoice from database
            mainSQL.DeleteInvoice(currentInvoice);
            //set currentInvoice to Empty
            currentInvoice = null;
            dataUpdated?.Invoke();
        }
        /// <summary>
        /// adds item to invoice selected from a combobox, triggers dataupdated
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(ItemDesc item) {
            //insert selected item into database
            mainSQL.AddInvoiceItem(item, currentInvoice, (invoiceItems.Count + 1));
            //update our item list
            invoiceItems = mainSQL.getInvoiceItems(currentInvoice);
            dataUpdated?.Invoke();
        }
        /// <summary>
        /// deletes item from current invoice, , triggers dataupdated
        /// </summary>
        /// <param name="items"></param>
        public void DeleteItem(List<ItemDesc> items) {

            //delete items from invoice in database
            foreach (ItemDesc item in items)
            {
                mainSQL.DeleteInvoiceItem(item, currentInvoice);
            }
            dataUpdated?.Invoke();
        }
        /// <summary>
        /// updates date for current invoice, triggers dataupdated
        /// </summary>
        /// <param name="date"></param>
        public void ChangeDate(DateTime date) {
            //update date in database for current invoice
            mainSQL.UpdateInvoiceDate(currentInvoice, date);
            dataUpdated.Invoke();
        }
    }
}
