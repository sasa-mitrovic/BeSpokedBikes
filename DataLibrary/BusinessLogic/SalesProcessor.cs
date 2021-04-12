using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class SalesProcessor
    {
        public static int CreateSale(int ProductID, int SalesPersonID, int CustomerID, DateTime SaleDate)
        {
            SalesModel data = new SalesModel
            {
                ProductID = ProductID,
                SalesPersonID = SalesPersonID,
                CustomerID = CustomerID, 
                SaleDate = SaleDate
            };

            string sql = @"insert into dbo.Sales ( ProductID, SalesPersonID, CustomerID, SaleDate )
                            values(@ProductID, @SalesPersonID, @CustomerID, @SaleDate);";


            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<SalesListModel> LoadSales(DateTime beginDate, DateTime endDate)
        {
            string sql = @"select p.ProductName, p.Manufacturer, p.Style, c.FName as 'CustomerFName', c.LName as 'CustomerLName', s.SaleDate, p.SalePrice, sp.FName as 'SalesPersonFName', sp.LName as 'SalesPersonLName',(p.SalePrice * (p.CommissionPercentage/100)) as 'Commission'
                                from Sales s
                                join Customer c on s.CustomerID=c.CustomerID
                                join Products p on s.ProductID=p.ProductID
                                join SalesPerson sp on s.SalesPersonID=sp.SalesPersonID
                                where s.SaleDate BETWEEN '"+ beginDate + "' AND '"+ endDate + "' ";

            return SqlDataAccess.LoadData<SalesListModel>(sql);
        }

        public static List<CommissionReportModel> LoadCommissionReport()
        {
            string sql = @"select p.ProductName, p.SalePrice, p.CommissionPercentage, (p.SalePrice * (p.CommissionPercentage/100)) as 'Commission', sp.FName as 'SalesPersonFName', sp.LName as 'SalesPersonLName', s.SaleDate
                                from Products p
                                join Sales s on s.ProductID=p.ProductID
                                join SalesPerson sp on sp.SalesPersonID = s.SalesPersonID
                                where s.SaleDate BETWEEN '4/1/2021' AND '6/30/2021'
                                order by SalesPersonLName";

            return SqlDataAccess.LoadData<CommissionReportModel>(sql);
        }
    }
}
