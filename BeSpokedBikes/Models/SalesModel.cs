﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeSpokedBikes.Models
{
    public class SalesModel
    {
        [Required]
        public int ProductID { get; set; }

        [Required]
        public int SalesPersonID { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }
    }
}