using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Search
{
    public class clsSearchLogic
    {
        /// <summary>
        /// delegate Action invoked when invoice is selected
        /// Invoke like this: onInvoiceSelected?.Invoke(selectedInvoice);
        /// </summary>
        public Action<Invoices> onInvoiceSelected;
        
    }

}
