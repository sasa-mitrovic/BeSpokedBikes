using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class SalesPersonProcessor
    {
        public static int CreateSalesPerson(int SalesPersonID, string FName, string LName, string Address, string Phone, DateTime StartDate, DateTime TerminationDate, string Manager)
        {
            SalesPersonModel data = new SalesPersonModel
            {
                SalesPersonID = SalesPersonID,
                FName = FName,
                LName = LName,
                Address = Address,
                Phone = Phone,
                StartDate = StartDate,
                TerminationDate = TerminationDate,
                Manager = Manager
            };

            string sql = @"insert into dbo.SalesPerson (SalesPersonID, FName, LName, Address, Phone, StartDate, TerminationDate, Manager )
                            values(@SalesPersonID, @FName, @LName, @Address, @Phone, @StartDate, @TerminationDate, @Manager);";


            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<SalesPersonModel> LoadSalesPerson()
        {
            string sql = @"select Id, SalesPersonID, FName, LName, Address, Phone, StartDate, TerminationDate, Manager 
                            from dbo.SalesPerson;";

            return SqlDataAccess.LoadData<SalesPersonModel>(sql);
        }

        public static int UpdateSalesPerson(int SalesPersonID, string FName, string LName, string Address, string Phone, DateTime StartDate, DateTime TerminationDate, string Manager)
        {
            SalesPersonModel data = new SalesPersonModel
            {
                SalesPersonID = SalesPersonID,
                FName = FName,
                LName = LName,
                Address = Address,
                Phone = Phone,
                StartDate = StartDate,
                TerminationDate = TerminationDate,
                Manager = Manager
            };

            string sql = @"Update dbo.SalesPerson
                           Set FName = @FName, LName = @LName, Address = @Address, Phone = @Phone, StartDate = @StartDate, TerminationDate = @TerminationDate, Manager = @Manager
                           Where SalesPersonID = @SalesPersonID";


            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
