using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class CustomerProcessor
    {
        public static List<CustomerModel> LoadCustomers()
        {
            string sql = @"select Id, CustomerID, FName, LName, Address, Phone, StartDate 
                            from dbo.Customer;";

            return SqlDataAccess.LoadData<CustomerModel>(sql);
        }
    }
}
