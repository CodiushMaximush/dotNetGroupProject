using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Search
{
    public class Invoices
    {
        public int Num;
        public DateTime Date;
        public decimal TotalCost;

        public Invoices(int num, DateTime date, decimal totalCost)
        {
            Num = num;
            Date = date;
            TotalCost = totalCost;
        }
    }
}
