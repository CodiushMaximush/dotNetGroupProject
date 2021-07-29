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
        public Action dataUpdated;

        public Invoices currentInvoice;
        public List<ItemDesc> items = new List<ItemDesc>();
        private clsMainSQL mainSQL = new clsMainSQL();

        public void SelectInvoice(Invoices newInvoice) {
            currentInvoice = newInvoice;
            //get items for current invoice


            dataUpdated?.Invoke();
        }

        public void CreateInvoice() {


        }

        public void DeleteInvoice() {


        }

        public void AddItem() {


        }

        public void DeleteItem() {


        }


    }
}
