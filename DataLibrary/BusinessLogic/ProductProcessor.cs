using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class ProductProcessor
    {
        public static int CreateProduct(int productId, string productName, string manufacturer, string style, double purchasePrice, double salePrice, int qty, double commissionPercentage)
        {
            ProductModel data = new ProductModel
            {
                ProductID = productId,
                ProductName = productName,
                Manufacturer = manufacturer,
                Style = style,
                PurchasePrice = purchasePrice,
                SalePrice = salePrice,
                Qty = qty,
                CommissionPercentage = commissionPercentage
            };

            string sql = @"insert into dbo.Products (ProductID, ProductName, Manufacturer, Style, PurchasePrice, SalePrice, Qty, CommissionPercentage )
                            values(@ProductID, @ProductName, @Manufacturer, @Style, @PurchasePrice, @SalePrice, @Qty, @CommissionPercentage);";


            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<ProductModel> LoadProducts()
        {
            string sql = @"select Id, ProductID, ProductName, Manufacturer, Style, PurchasePrice, SalePrice, Qty, CommissionPercentage 
                            from dbo.Products;";

            return SqlDataAccess.LoadData<ProductModel>(sql);
        }

        public static int UpdateProduct(int productId, string productName, string manufacturer, string style, double purchasePrice, double salePrice, int qty, double commissionPercentage)
        {
            ProductModel data = new ProductModel
            {
                ProductID = productId,
                ProductName = productName,
                Manufacturer = manufacturer,
                Style = style,
                PurchasePrice = purchasePrice,
                SalePrice = salePrice,
                Qty = qty,
                CommissionPercentage = commissionPercentage
            };

            string sql = @"Update dbo.Products
                           Set ProductName = @ProductName, Manufacturer = @Manufacturer, Style = @Style, PurchasePrice = @PurchasePrice, SalePrice = @SalePrice, Qty = @Qty, CommissionPercentage = @CommissionPercentage
                           Where ProductID = @ProductID";


            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
