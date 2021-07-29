using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Items
{
   public class ItemDesc
    {
        public string Code { get; set; }
        public string Desc { get; set; }
        public decimal Cost { get; set; }

        public ItemDesc(string code, string desc, decimal cost)
        {
            Code = code;
            Desc = desc;
            Cost = cost;
        }
    }
}
