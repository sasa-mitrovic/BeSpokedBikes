using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeSpokedBikes.Models
{
    public class SalesPersonModel
    {
        [Required, Range(100000, 999999), Display(Name = "Salesperson ID")]
        public int SalesPersonID { get; set; }

        [Required, Display(Name = "First Name"), MaxLength(50)]
        public string FName { get; set; }

        [Required, Display(Name = "Last Name"), MaxLength(50)]
        public string LName { get; set; }

        [Required, MaxLength(250)]
        public string Address { get; set; }

        [Required, MaxLength(15), DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required, Display(Name = "Start Date"), DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required, Display(Name = "Termination Date"), DataType(DataType.Date)]
        public DateTime TerminationDate { get; set; }

        [Required, MaxLength(100)]
        public string Manager { get; set; }
    }
}