using BeSpokedBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.BusinessLogic;

namespace BeSpokedBikes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewProduct()
        {
            ViewBag.Message = "View product page.";

            var data = ProductProcessor.LoadProducts();
            List<ProductModel> products = new List<ProductModel>();

            foreach (var row in data)
            {
                products.Add(new ProductModel
                {
                    ProductID = row.ProductID,
                    ProductName = row.ProductName,
                    Manufacturer = row.Manufacturer,
                    Style = row.Style,
                    PurchasePrice = row.PurchasePrice,
                    SalePrice = row.SalePrice,
                    Qty = row.Qty,
                    CommissionPercentage = row.CommissionPercentage
                });
            }

            return View(products);
        }

        public ActionResult CreateProduct()
        {
            ViewBag.Message = "Create product page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(ProductModel model)
        {
            if (ModelState.IsValid)
            {

                List<DataLibrary.Models.ProductModel> products = ProductProcessor.LoadProducts();

                products = products.Where(a => a.ProductID == model.ProductID || a.ProductName == model.ProductName ).ToList();

                if (products.Count() > 0)
                {
                    TempData["DuplicateProduct"] = "You have entered a duplicate product, please enter a new product.";
                    return View();
                }
                else
                {
                    //left as int for testing purposes
                    int recordsCreated = ProductProcessor.CreateProduct(model.ProductID, model.ProductName, model.Manufacturer,
                        model.Style, model.PurchasePrice, model.SalePrice, model.Qty, model.CommissionPercentage);
                    return RedirectToAction("ViewProduct");
                }
                
            }
            return View();
        }

        public ActionResult UpdateProduct(int ProductID, string ProductName, string Manufacturer, string Style, double PurchasePrice, double SalePrice, int Qty, double CommissionPercentage)
        {
            ViewBag.Message = "Update product page.";
            ProductModel model = new ProductModel
            {
                ProductID = ProductID,
                ProductName = ProductName,
                Manufacturer = Manufacturer,
                Style = Style,
                PurchasePrice = PurchasePrice,
                SalePrice = SalePrice,
                Qty = Qty,
                CommissionPercentage = CommissionPercentage
            };

            Session["ProductUpdateModel"] = model;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProduct(ProductModel model)
        {
            if (ModelState.IsValid)
            {

                List<DataLibrary.Models.ProductModel> products = ProductProcessor.LoadProducts();

                ProductModel sessionModel = (ProductModel)Session["ProductUpdateModel"];

                //recreating list without the session model in it.
                products = products.Where(a => a.ProductID != sessionModel.ProductID).ToList();

                //isolate(if any) duplicates
                products = products.Where(a => a.ProductID == model.ProductID || a.ProductName == model.ProductName).ToList();

                //if the session model's identifying variable is the same as the parameter model, then it is okay to update (same account, same update)
                //if the session model's identifying variable is NOT the same, then it is NOT okay to update (updating the current model to a duplicate that already exists)

                //checking to see if the session model is the same as the parameter model. If same, update, if not, proceed.
                if (sessionModel.ProductName == model.ProductName)
                {
                    //left as int for testing purposes
                    int recordsCreated = ProductProcessor.UpdateProduct(model.ProductID, model.ProductName, model.Manufacturer,
                        model.Style, model.PurchasePrice, model.SalePrice, model.Qty, model.CommissionPercentage);
                    return RedirectToAction("ViewProduct");
                }
                else
                {
                    //if duplicates exist, throw alert and deny update.
                    if (products.Count() > 0)
                    {
                        TempData["DuplicateProduct"] = "You have entered a duplicate product, please enter a new product.";
                        return View();
                    }
                    else
                    {
                        //left as int for testing purposes
                        int recordsCreated = ProductProcessor.UpdateProduct(model.ProductID, model.ProductName, model.Manufacturer,
                            model.Style, model.PurchasePrice, model.SalePrice, model.Qty, model.CommissionPercentage);
                        return RedirectToAction("ViewProduct");
                    }
                }
            }

            return View();
        }

        public ActionResult CreateSalesPerson()
        {
            ViewBag.Message = "Create product page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSalesPerson(SalesPersonModel model)
        {
            if (ModelState.IsValid)
            {

                List<DataLibrary.Models.SalesPersonModel> salespersons = SalesPersonProcessor.LoadSalesPerson();

                salespersons = salespersons.Where(a => a.SalesPersonID == model.SalesPersonID || (a.FName == model.FName && a.LName == model.LName)).ToList();

                if(salespersons.Count() > 0)
                {
                    TempData["DuplicateSalesperson"] = "You have entered a duplicate Salesperson, please enter a new salesperson.";
                    return View();
                }
                else
                {
                    //left as int for testing purposes
                    int recordsCreated = SalesPersonProcessor.CreateSalesPerson(model.SalesPersonID, model.FName, model.LName,
                                            model.Address, model.Phone, model.StartDate, model.TerminationDate, model.Manager);
                    return RedirectToAction("ViewSalesPerson");
                }
                
            }
            return View();
        }

        public ActionResult ViewSalesPerson()
        {
            ViewBag.Message = "View Salesperson page.";

            var data = SalesPersonProcessor.LoadSalesPerson();
            List<SalesPersonModel> salespersons = new List<SalesPersonModel>();

            foreach (var row in data)
            {
                salespersons.Add(new SalesPersonModel
                {
                    SalesPersonID = row.SalesPersonID,
                    FName = row.FName,
                    LName = row.LName,
                    Address = row.Address,
                    Phone = row.Phone,
                    StartDate = row.StartDate,
                    TerminationDate = row.TerminationDate,
                    Manager = row.Manager
                });
            }

            return View(salespersons);
        }

        public ActionResult UpdateSalesPerson(int SalesPersonID, string FName, string LName, string Address, string Phone, DateTime StartDate, DateTime TerminationDate, string Manager)
        {
            ViewBag.Message = "Update Salesperson page.";
            SalesPersonModel model = new SalesPersonModel
            {
                SalesPersonID = SalesPersonID,
                FName = FName,
                LName = LName,
                Address = Address,
                Phone = Phone,
                StartDate = StartDate.Date,
                TerminationDate = TerminationDate.Date,
                Manager = Manager
            };

            Session["SalespersonUpdateModel"] = model;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSalesPerson(SalesPersonModel model)
        {
            if (ModelState.IsValid)
            {

                List<DataLibrary.Models.SalesPersonModel> salespersons = SalesPersonProcessor.LoadSalesPerson();

                SalesPersonModel sessionModel = (SalesPersonModel)Session["SalespersonUpdateModel"];

                //recreating list without the session model in it.
                salespersons = salespersons.Where(s => s.SalesPersonID != sessionModel.SalesPersonID ).ToList();

                //isolate(if any) duplicates
                salespersons = salespersons.Where(a => a.SalesPersonID == model.SalesPersonID || (a.FName == model.FName && a.LName == model.LName)).ToList();

                //if the session model's identifying variables are the same as the parameter model, then it is okay to update (same account, same update)
                //if the session model's identifying variables are NOT the same, then it is NOT okay to update (updating the current model to a duplicate that already exists)

                //checking to see if the session model is the same as the parameter model. If same, update, if not, proceed.
                if ( sessionModel.FName == model.FName && sessionModel.LName == model.LName)
                {
                    //left as int for testing purposes
                    int recordsCreated = SalesPersonProcessor.UpdateSalesPerson(model.SalesPersonID, model.FName, model.LName,
                        model.Address, model.Phone, model.StartDate, model.TerminationDate, model.Manager);
                    return RedirectToAction("ViewSalesPerson");
                }
                else
                {
                    //if duplicates exist, throw alert and deny update.
                    if (salespersons.Count() > 0)
                    {
                        TempData["DuplicateSalesperson"] = "You have entered a duplicate Salesperson, please enter a new salesperson.";
                        return View();
                    }
                    else
                    {
                        //left as int for testing purposes
                        int recordsCreated = SalesPersonProcessor.UpdateSalesPerson(model.SalesPersonID, model.FName, model.LName,
                            model.Address, model.Phone, model.StartDate, model.TerminationDate, model.Manager);
                        return RedirectToAction("ViewSalesPerson");
                    }
                    
                }
                
            }
            return View();
        }

        public ActionResult ViewCustomers()
        {
            ViewBag.Message = "View Customer page.";

            var data = CustomerProcessor.LoadCustomers();
            List<CustomerModel> customers = new List<CustomerModel>();

            foreach (var row in data)
            {
                customers.Add(new CustomerModel
                {
                    CustomerID = row.CustomerID,
                    FName = row.FName,
                    LName = row.LName,
                    Address = row.Address,
                    Phone = row.Phone,
                    StartDate = row.StartDate
                });
            }

            return View(customers);
        }

        public ActionResult CreateSale()
        {
            ViewBag.Message = "Create sale page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSale(SalesModel model)
        {
            if (ModelState.IsValid)
            {
                //left as int for testing purposes
                int recordsCreated = SalesProcessor.CreateSale(model.ProductID, model.SalesPersonID,
                                                               model.CustomerID, model.SaleDate);
                return RedirectToAction("Index");
                
            }
            return View();
        }

        public ActionResult ViewSales(string beginDate, string endDate)
        {
            ViewBag.Message = "View Sales page.";

            if((beginDate == "" || beginDate == null )||(endDate =="" || endDate == null))
            {
                beginDate = "4/1/2021 12:00:00 AM";
                endDate = "6/30/2021 12:00:00 AM";
                
            }

            var data = SalesProcessor.LoadSales(DateTime.Parse(beginDate), DateTime.Parse(endDate));
            List<SalesListModel> salesList = new List<SalesListModel>();

            foreach (var row in data)
            {
                salesList.Add(new SalesListModel
                {
                    ProductName = row.ProductName,
                    Manufacturer = row.Manufacturer,
                    Style = row.Style,
                    CustomerFName = row.CustomerFName,
                    CustomerLName = row.CustomerLName,
                    SaleDate = row.SaleDate,
                    SalePrice = row.SalePrice,
                    SalesPersonFName = row.SalesPersonFName,
                    SalesPersonLName = row.SalesPersonLName,
                    Commission = row.Commission
                });
            }

            return View(salesList);
        }

        public ActionResult ViewCommissionReport()
        {
            ViewBag.Message = "View Commission Report";

            var data = SalesProcessor.LoadCommissionReport();
            List<CommissionReportModel> commissionReports = new List<CommissionReportModel>();

            foreach (var row in data)
            {
                commissionReports.Add(new CommissionReportModel
                {
                    ProductName = row.ProductName,
                    SalePrice = row.SalePrice,
                    CommissionPercentage = row.CommissionPercentage,
                    Commission = row.Commission,
                    SalesPersonFName = row.SalesPersonFName,
                    SalesPersonLName = row.SalesPersonLName,
                    SaleDate = row.SaleDate
                });
            }

            return View(commissionReports);
        }
    }
}