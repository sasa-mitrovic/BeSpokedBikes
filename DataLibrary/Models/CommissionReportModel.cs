using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class CommissionReportModel
    {
        public string ProductName { get; set; }
        public double SalePrice { get; set; }
        public double CommissionPercentage { get; set; }
        public double Commission { get; set; }
        public string SalesPersonFName { get; set; }
        public string SalesPersonLName { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
