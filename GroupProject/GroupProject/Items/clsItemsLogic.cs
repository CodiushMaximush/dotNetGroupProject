using GroupProject.Items;
using GroupProject.Search;
using GroupProject.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Items
{
    public class clsItemsLogic
    {
        /// <summary>
        /// called whenever UI needs to be updated because data changed. 
        /// </summary>
        public Action dataUpdated;

        /// <summary>
        /// cursor object for current invoice
        /// </summary>
        public ItemDesc currentItem;
        /// <summary>
        /// list of items available in database
        /// </summary>
        public List<ItemDesc> availableItems;
        /// <summary>
        /// class containing abstracted SQL queries
        /// </summary>
        private clsItemsSQL itemSQL = new clsItemsSQL();
        /// <summary>
        /// default constructor
        /// </summary>
        public clsItemsLogic()
        {
            availableItems = itemSQL.GetAllItems();

        }
        /// <summary>
        /// adds a new invoice to the database then sets it to the current invoice. also invokes dataupdated
        /// </summary>
        public void CreateItem()
        {
            //insert a new invoice into the database
            itemSQL.insertNewItem();
            //set currentInvoice to newest invoice from database
            currentItem = itemSQL.getMaxItem();
            dataUpdated?.Invoke();
        }
        /// <summary>
        /// deletes current invoice from the database and sets currentInvoice to null, triggers dataupdated
        /// </summary>
        public void DeleteItem(ItemDesc item)
        {
            try
            {
                currentItem = item;
                List<Invoices> InvoiceItem = itemSQL.GetInvoicesFromItem(item);
                //delete current invoice from database
                if (InvoiceItem.Count > 0)
                {
                    string err = "Error cannot delete item selected it is on the following invoices:\n";
                    foreach (Invoices inv in InvoiceItem) {
                        err += $"Invoice number {inv.Num} with total cost {inv.TotalCost} created on Date {inv.Date.ToString()}\n";
                    }
                    throw new InvalidOperationException(err);
                }
                itemSQL.DeleteItem(currentItem);        
                currentItem = null;
                dataUpdated?.Invoke();
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException(ioe.Message);
               
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// adds item to invoice selected from a combobox, triggers dataupdated
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(ItemDesc item)
        {
            try
            {
                //insert selected item into database
                currentItem = item;
                itemSQL.AddItem(currentItem);
                //update our item list
                availableItems = itemSQL.getItems();
                dataUpdated?.Invoke();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// calls the getItems method from the clsitemsSQL class
        /// </summary>
        /// <returns></returns>
        public List<ItemDesc> GetItems() {
            return itemSQL.getItems();
        }
        
        public void EditItem(ItemDesc item, string Code) {
            try
            {
               
                currentItem = item;
                itemSQL.EditItem(currentItem, Code);
                currentItem = null;
                dataUpdated?.Invoke();
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException(ioe.Message);
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
