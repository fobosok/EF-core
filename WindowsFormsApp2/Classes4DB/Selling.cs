using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Salling
    {
        public int Id { get; set; }

        public DateTime DateOFProduct { get; set; }

        public int SallerId { get; set; }
        public Saller Saller { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Product> Products { get; set; }
    }
}
