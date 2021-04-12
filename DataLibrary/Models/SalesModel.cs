using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class SalesModel
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int SalesPersonID { get; set; }
        public int CustomerID { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
