using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class SalesListModel
    {
        public string ProductName { get; set; }
        public string Manufacturer { get; set; }
        public string Style { get; set; }
        public string CustomerFName { get; set; }
        public string CustomerLName { get; set; }
        public DateTime SaleDate { get; set; }
        public double SalePrice { get; set; }
        public string SalesPersonFName { get; set; }
        public string SalesPersonLName { get; set; }
        public double Commission { get; set; }
    }
}
