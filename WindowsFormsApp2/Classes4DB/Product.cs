using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
        public string ProductPrice { get; set; }

        public Salling Salling { get; set; }
    }
}
