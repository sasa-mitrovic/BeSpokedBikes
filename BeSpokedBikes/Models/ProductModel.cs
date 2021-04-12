using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace BeSpokedBikes.Models
{
    public class ProductModel
    {
        [Required, Range(100000,999999), Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Required, Display(Name = "Product Name"),StringLength(50)]
        public string ProductName { get; set; }

        [Required, StringLength(50)]
        public string Manufacturer { get; set; }

        [Required, StringLength(50)]
        public string Style { get; set; }

        [Required, Display(Name = "Purchase Price"), DataType(DataType.Currency)]
        public double PurchasePrice { get; set; }

        [Required, Display(Name = "Sale Price"), DataType(DataType.Currency)]
        public double SalePrice { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required, Display(Name = "Commission Percentage"), Range(0,100)]
        public double CommissionPercentage { get; set; }
    }
}