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
        public Invoices currentInvoice;


        public void UpdateInvoice(Invoices newInvoice) {
            currentInvoice = newInvoice;
        }

    }
}
