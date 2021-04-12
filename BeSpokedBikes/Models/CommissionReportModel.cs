using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeSpokedBikes.Models
{
    public class CommissionReportModel
    {
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Sale Price")]
        public double SalePrice { get; set; }
        [Display(Name = "Commission Percentage")]
        public double CommissionPercentage { get; set; }
        public double Commission { get; set; }
        [Display(Name = "S. First Name")]
        public string SalesPersonFName { get; set; }
        [Display(Name = "S. Last Name")]
        public string SalesPersonLName { get; set; }
        [Display(Name = "Sale Date"), DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }
    }
}