using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeSpokedBikes.Models
{
    public class SalesListModel
    {
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public string Manufacturer { get; set; }
        public string Style { get; set; }
        [Display(Name = "C. First Name")]
        public string CustomerFName { get; set; }
        [Display(Name = "C. Last Name")]
        public string CustomerLName { get; set; }
        [DataType(DataType.Date), Display(Name = "Sale Date")]
        public DateTime SaleDate { get; set; }
        [DataType(DataType.Currency), Display(Name = "Sale Price")]
        public double SalePrice { get; set; }
        [Display(Name = "S. First Name")]
        public string SalesPersonFName { get; set; }
        [Display(Name = "S. Last Name")]
        public string SalesPersonLName { get; set; }
        public double Commission { get; set; }
    }
}