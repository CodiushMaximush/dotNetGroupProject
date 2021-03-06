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

namespace GroupProject.Items
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
        /// inserts a new item into the database with today as the invoice date
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
        /// deletes an item as well as it's items from the item table and the line items table
        /// </summary>
        /// <param name="invoice"></param>
        public void DeleteItem(ItemDesc item)
        {
            try
            {
                int rowsAffected = 0;
                string query = $"DELETE From ItemDesc WHERE ItemCode = '{item.Code}';";
                dataAccess.ExecuteSQLStatement(query, ref rowsAffected);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// adds item to table(itemcode, itemdesc, cost) in the database and its values
        /// </summary>
        /// <param name="item"></param>
        /// <param name="invoice"></param>
        /// <param name="lineItemNum"></param>
        public void AddItem(ItemDesc item)
        {
            try
            {
                int rowsAffected = 0;
                string query = $"INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost) VALUES ('{item.Code}', '{item.Desc}', {item.Cost});";
                dataAccess.ExecuteSQLStatement(query, ref rowsAffected);
            }
            catch (Exception e)
            {
                  throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// gets the max or most recently inserted items and returns it as an object in memory
        /// </summary>
        /// <returns></returns>
        public ItemDesc getMaxItem()
        {
            int rowsAffected = 0;
            string maxQuery = "SELECT MAX(ItemCode) FROM ItemDesc";
            string maxItemID = (string)dataAccess.ExecuteSQLStatement(maxQuery, ref rowsAffected).Tables[0].Rows[0].ItemArray[0];
            string query = $"SELECT *  FROM ItemDesc WHERE ItemCode = '{maxItemID}';";
            object[] row = dataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows[0].ItemArray;

            return new ItemDesc((string)row[0], (string) row[1], (decimal)row[2]);
        }

        /// <summary>
        /// edits/update the date for a given item
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="dateTime"></param>
        public void EditItem(ItemDesc item, string Code)
        {
            try
            {
                int rowsAffected = 0;
                string query = $"UPDATE ItemDesc SET ItemDesc = '{item.Desc}' WHERE ItemCode = '{Code}';";
                dataAccess.ExecuteSQLStatement(query, ref rowsAffected);
                query = $"UPDATE ItemDesc SET Cost = '${item.Cost}' WHERE ItemCode = '{Code}';";
                dataAccess.ExecuteSQLStatement(query, ref rowsAffected);
            }
            catch (Exception e)
            {
                if (e.Message == "clsDataAccess.ExecuteSQLStatement -> Cannot find table 0.")
                {
                    int rowsAffected = 0;
                    string query = $"UPDATE ItemDesc SET Cost = '${item.Cost}' WHERE ItemCode = '{Code}';";
                    dataAccess.ExecuteSQLStatement(query, ref rowsAffected);
                }
                else
                {
                    throw new Exception(e.Message);
                }
            }
        }
        /// <summary>
        /// gets all available items available to add to database
        /// </summary>
        /// <returns></returns>
        public List<ItemDesc> GetAllItems()
        {
            List<ItemDesc> items = new List<ItemDesc>();
            int rowsAffected = 0;
            string query = "SELECT * FROM ItemDesc";
            DataRowCollection rows = dataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows;
            foreach (DataRow row in rows)
            {
                items.Add(new ItemDesc(row.ItemArray[0].ToString(), row.ItemArray[1].ToString(), (decimal)row.ItemArray[2]));
            }
            return items;
        }
        /// <summary>
        /// returns all invoices that contain item from argument
        /// </summary>
        /// <param name="item"></param>
        /// <returns>list of invoices</returns>
        public List<Invoices> GetInvoicesFromItem(ItemDesc item) {
            try
            {
                List<Invoices> invoices = new List<Invoices>();
                int rowsAffected = 0;
                string query = $"SELECT Invoices.InvoiceNum, InvoiceDate, TotalCost, ItemCode  FROM Invoices INNER JOIN LineItems ON LineItems.InvoiceNum = Invoices.InvoiceNum WHERE ItemCode = '{item.Code}';";
                DataRowCollection rows = dataAccess.ExecuteSQLStatement(query, ref rowsAffected).Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    invoices.Add(new Invoices(int.Parse(row[0].ToString()), DateTime.Parse(row[1].ToString()), decimal.Parse(row[2].ToString())));
                }
                return invoices;

            }
            catch (FormatException Fe)
            {

                throw new FormatException(Fe.Message);
            }

        }
    }
}
