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
    public class clsItemsSQL
    {   /// <summary>
        /// data access object provided by the course
        /// </summary>
        clsDataAccess dataAccess;

        public clsItemsSQL()
        {
            ///connection string provided by course
            string sConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory() + "\\Group Project DB\\Invoice.mdb";
            dataAccess = new clsDataAccess(sConnectionString);
        }
        /// <summary>
        /// inserts a new invoice into the database with today as the invoice date
        /// </summary>
        public void insertNewItem()
        {
            int rowsAffected = 0;
            string nowDate = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("en-US"));
            string query = "INSERT INTO Invoices(InvoiceDate, TotalCost) Values('#" + nowDate + "#', 0)";
            dataAccess.ExecuteSQLStatement(query, ref rowsAffected);
        }
        /// <summary>
        /// returns all items from itemdesc table and returns it as a list
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public List<ItemDesc> getItems() { 

            List<ItemDesc> items = new List<ItemDesc>();

            int rowsAffected = 0;
            string query = "SELECT * FROM ItemDesc "; 
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
        public void DeleteItem(ItemDesc item)
        {
            int rowsAffected = 0;
            string query = "DELETE From ItemDesc WHERE ItemCode = " + item.Code;
            dataAccess.ExecuteSQLStatement(query, ref rowsAffected);

            query = "DELETE FROM LineItems WHERE ItemCode = " + item.Code;
            dataAccess.ExecuteSQLStatement(query, ref rowsAffected);
        }
        /// <summary>
        /// adds item to invoice in the database
        /// </summary>
        /// <param name="item"></param>
        /// <param name="invoice"></param>
        /// <param name="lineItemNum"></param>
        public void AddItem(ItemDesc item)
        {
            int rowsAffected = 0;
            string query = "INSERT INTO ItemDesc (ItemCode,ItemDesc ,Cost) Values (" +
                item.Code + "," + item.Desc + ",'" + item.Cost.ToString() + "')";

            dataAccess.ExecuteSQLStatement(query, ref rowsAffected);

        }
        /// <summary>
        ///deletes an item from an invoice
        /// </summary>
        /// <param name="item"></param>
        /// <param name="invoice"></param>
        public void DeleteInvoiceItem(ItemDesc item, Invoices invoice)
        {
            int rowsAffected = 0;
            string query = "DELETE From LineItems WHERE ItemCode = " + item.Code + "AND InvoiceNum = " + invoice.Num;
            dataAccess.ExecuteSQLStatement(query, ref rowsAffected);

        }

        /// <summary>
        /// gets the max or most recently inserted invoice and returns it as an object in memory
        /// </summary>
        /// <returns></returns>
        public ItemDesc getMaxItem()
        {
            int rowsAffected = 0;
            string maxQuery = "SELECT MAX(ItemCode) FROM ItemDesc";
            string maxItemID = (string)dataAccess.ExecuteSQLStatement(maxQuery, ref rowsAffected).Tables[0].Rows[0].ItemArray[0];
            string query = "SELECT *  FROM ItemDesc WHERE ItemCode = " + maxItemID;
            object[] row = dataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows[0].ItemArray;

            return new ItemDesc((string)row[0], (string) row[1], (decimal)row[2]);
        }

        /// <summary>
        /// updates the date for a given invoice
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="dateTime"></param>
        public void UpdateItem(Invoices invoice, DateTime dateTime)
        {
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
            DataRowCollection rows = dataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows;
            foreach (DataRow row in rows)
            {
                items.Add(new ItemDesc(row.ItemArray[0].ToString(), row.ItemArray[1].ToString(), (decimal)row.ItemArray[2]));
            }
            return items;
        }
    }
}
