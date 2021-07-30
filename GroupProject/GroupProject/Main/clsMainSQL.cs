using GroupProject.Items;
using GroupProject.Search;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Main
{
    public class clsMainSQL
    {   /// <summary>
    /// data access object provided by the course
    /// </summary>
        clsDataAccess dataAccess;

        public clsMainSQL() {
            ///connection string provided by course
            string sConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetCurrentDirectory() + "\\Group Project DB\\Invoice.accdb";
            dataAccess = new clsDataAccess(sConnectionString);
        }
        /// <summary>
        /// inserts a new invoice into the database with today as the invoice date
        /// </summary>
        public void insertNewInvoice() {
            int rowsAffected = 0;
            string nowDate = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("en-US"));
            string query = "INSERT INTO Invoices(InvoiceDate, TotalCost) Values('#" + nowDate +"#', 0)";
            dataAccess.ExecuteSQLStatement(query, ref rowsAffected);
        }
        /// <summary>
        /// gets the max or most recently inserted invoice and returns it as an object in memory
        /// </summary>
        /// <returns></returns>
        public Invoices getMaxInvoice() {
            int rowsAffected = 0;
            string maxQuery = "SELECT MAX(InvoiceNum) FROM Invoices";
            int maxInvoiceID = (int)dataAccess.ExecuteSQLStatement(maxQuery, ref rowsAffected).Tables[0].Rows[0].ItemArray[0];
            string query = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = " + maxInvoiceID.ToString();
            object[] row = dataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows[0].ItemArray;

            return new Invoices((int)row[0], DateTime.Parse(row[1].ToString()), (decimal)row[2]);
        }
        /// <summary>
        /// gets all items associated with an invoice and returns it as a list
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public List<ItemDesc> getInvoiceItems(Invoices invoice) {

            List<ItemDesc> items = new List<ItemDesc>();

            int rowsAffected = 0;
            string query = "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost " +
                "FROM LineItems, ItemDesc " +
                "WHERE LineItems.ItemCode = ItemDesc.ItemCode" +
                    " AND LineItems.InvoiceNum = " + invoice.Num.ToString();
            DataRowCollection rows = dataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows;
            foreach (DataRow row in rows)
            {
                items.Add(new ItemDesc(row.ItemArray[0].ToString(), row.ItemArray[1].ToString(), (decimal)row.ItemArray[2]));
            }

            return items;

        }
        /// <summary>
        /// deletes an invoice as well as it's items from the invoice table and the line items table
        /// </summary>
        /// <param name="invoice"></param>
        public void DeleteInvoice(Invoices invoice) {
            int rowsAffected = 0;
            string query = "DELETE From Invoices WHERE InvoiceNum = " + invoice.Num.ToString();
            dataAccess.ExecuteSQLStatement(query, ref rowsAffected);

            query = "DELETE FROM LineItems WHERE InvoiceNum = " + invoice.Num.ToString();
            dataAccess.ExecuteSQLStatement(query, ref rowsAffected);
        }
        /// <summary>
        /// adds item to invoice in the database
        /// </summary>
        /// <param name="item"></param>
        /// <param name="invoice"></param>
        /// <param name="lineItemNum"></param>
        public void AddInvoiceItem(ItemDesc item, Invoices invoice, int lineItemNum) {
            int rowsAffected = 0;
            string query = "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) Values (" +
                invoice.Num.ToString() + "," + lineItemNum.ToString() + ",'" + item.Code + "')";

            dataAccess.ExecuteSQLStatement(query, ref rowsAffected);

        }
        /// <summary>
        ///deletes an item from an invoice
        /// </summary>
        /// <param name="item"></param>
        /// <param name="invoice"></param>
        public void DeleteInvoiceItem(ItemDesc item, Invoices invoice) {
            int rowsAffected = 0;
            string query = "DELETE From LineItems WHERE ItemCode = " + item.Code + "AND InvoiceNum = " + invoice.Num;
            dataAccess.ExecuteSQLStatement(query, ref rowsAffected);

        }
        /// <summary>
        /// updates the date for a given invoice
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="dateTime"></param>
        public void UpdateInvoiceDate(Invoices invoice, DateTime dateTime) {
            int rowsAffected = 0;
            string parsedDate = dateTime.ToString("d", CultureInfo.CreateSpecificCulture("en-US"));
            string query = "UPDATE Invoices SET InvoiceDate = '#" + parsedDate + "#' WHERE InvoiceNum = " + invoice.Num.ToString();
            dataAccess.ExecuteSQLStatement(query, ref rowsAffected);      
        }
        /// <summary>
        /// gets all available items available to add to database
        /// </summary>
        /// <returns></returns>
        public List<ItemDesc> GetAllItems()
        {
            List<ItemDesc> items = new List<ItemDesc>();
            int rowsAffected = 0;
            string query = "SELECT ItemCode, ItemDesc, Cost from ItemDesc";
            DataRowCollection rows =  dataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows;
            foreach (DataRow row in rows)
            {
                items.Add(new ItemDesc(row.ItemArray[0].ToString(), row.ItemArray[1].ToString(), (decimal)row.ItemArray[2]));
            }
            return items;
        }
    }
}
