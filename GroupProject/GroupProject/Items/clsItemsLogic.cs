using GroupProject.Items;
using GroupProject.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Main
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
        private clsItemsSQL mainSQL = new clsItemsSQL();
        /// <summary>
        /// default constructor
        /// </summary>
        public clsItemsLogic()
        {
            availableItems = mainSQL.GetAllItems();

        }
        /// <summary>
        /// adds a new invoice to the database then sets it to the current invoice. also invokes dataupdated
        /// </summary>
        public void CreateItem()
        {
            //insert a new invoice into the database
            mainSQL.insertNewItem();
            //set currentInvoice to newest invoice from database
            currentItem = mainSQL.getMaxItem();
            dataUpdated?.Invoke();
        }
        /// <summary>
        /// deletes current invoice from the database and sets currentInvoice to null, triggers dataupdated
        /// </summary>
        public void DeleteItem()
        {
            //delete current invoice from database
            mainSQL.DeleteItem(currentItem);        // to DO: DO NOT DELETE IF ITEM IS IN INVOICE
            //set currentInvoice to Empty
            currentItem = null;
            dataUpdated?.Invoke();
        }
        /// <summary>
        /// adds item to invoice selected from a combobox, triggers dataupdated
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(ItemDesc item)
        {
            //insert selected item into database
            mainSQL.AddItem(item);
            //update our item list
            availableItems = mainSQL.getItems();
            dataUpdated?.Invoke();
        }
    }
}
