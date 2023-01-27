﻿using InventoryManagement.Interfaces;
using InventoryManagement.Migrations;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Drawing.Printing;
using static System.Net.Mime.MediaTypeNames;
using Product = InventoryManagement.Models.Product;
using Supplier = InventoryManagement.Models.Supplier;

namespace InventoryManagement.Controllers
{
    [Authorize]
    public class PurchaseOrderController : Controller
    {
        private readonly IPurchaseOrder _Repo;
        private readonly IProduct _ProductRepo;
        private readonly ISupplier _SupplierRepo;
        private readonly ICurrency _CurrencyRepo;
        public PurchaseOrderController(IPurchaseOrder repo, IProduct productRepo, ISupplier supplierRepo, ICurrency currencyRepo) // here the repository will be passed by the dependency injection.
        {
            _Repo = repo;
            _ProductRepo = productRepo;
            _SupplierRepo = supplierRepo;
            _CurrencyRepo = currencyRepo;
        }
        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("Id");
            sortModel.AddColumn("PoNumber");
            sortModel.AddColumn("PoDate");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<PoHeader> items = _Repo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(items.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;
            return View(items);
        }

        public IActionResult Create()
        {
            PoHeader item = new PoHeader();
            item.PoDetails.Add(new PoDetail() { Id = 1 });
            ViewBag.ProductList = GetProducts();
            ViewBag.SupplierList = GetSuppliers();
            ViewBag.PoCurrencyList = GetPoCurrencies();
            ViewBag.BaseCurrencyList = GetBaseCurrencies();

            ViewBag.ExchangeRate = GetExchangeRate();
            ViewBag.UnitNames = GetUnitNames();
            item.PoNumber = _Repo.GetNewPONumber();

            return View(item);
        }

        [HttpPost]
        public IActionResult Create(PoHeader item)
        {
            item.PoDetails.RemoveAll(a => a.Quantity == 0);

            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = _Repo.Create(item);
            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }


            if (bolret == false)
            {
                errMessage = errMessage + " " + _Repo.GetErrors();

                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(item);
            }
            else
            {
                TempData["SuccessMessage"] = "" + item.PoNumber + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Details(int id)
        {
            PoHeader item = _Repo.GetItem(id);

            ViewBag.ProductList = GetProducts();
            ViewBag.SupplierList = GetSuppliers();
            ViewBag.PoCurrencyList = GetPoCurrencies();
            ViewBag.BaseCurrencyList = GetBaseCurrencies();

            return View(item);
        }
        private List<SelectListItem> GetProducts()
        {
            var lstProducts = new List<SelectListItem>();

            PaginatedList<Product> products = _ProductRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);

            lstProducts = products.Select(ut => new SelectListItem()
            {
                Value = ut.Code.ToString(),
                Text = ut.Name
            }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Product----"
            };
            lstProducts.Insert(0, defItem);
            return lstProducts;
        }

        private List<SelectListItem> GetSuppliers()
        {
            var lstSuppliers = new List<SelectListItem>();

            PaginatedList<Supplier> suppliers = _SupplierRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);

            lstSuppliers = suppliers.Select(sp => new SelectListItem()
            {
                Value = sp.Id.ToString(),
                Text = sp.Name
            }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Supplier----"
            };
            lstSuppliers.Insert(0, defItem);
            return lstSuppliers;
        }

        private List<SelectListItem> GetPoCurrencies()
        {
            var lstCurrencies = new List<SelectListItem>();

            PaginatedList<Currency> currencies = _CurrencyRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);

            lstCurrencies = currencies.Select(cr => new SelectListItem()
            {
                Value = cr.Id.ToString(),
                Text = cr.Name
            }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Currency----"
            };
            lstCurrencies.Insert(0, defItem);
            return lstCurrencies;
        }

        private List<SelectListItem> GetBaseCurrencies()
        {
            var lstCurrencies = new List<SelectListItem>();

            PaginatedList<Currency> currencies = _CurrencyRepo.GetItems("Name", SortOrder.Ascending, "EURO", 1, 1000);

            lstCurrencies = currencies.Select(cr => new SelectListItem()
            {
                Value = cr.Id.ToString(),
                Text = cr.Name
            }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Base Currency----"
            };
            lstCurrencies.Insert(0, defItem);
            return lstCurrencies;
        }

        private List<SelectListItem> GetExchangeRate()
        {
            var lstCurrencies = new List<SelectListItem>();
            PaginatedList<Currency> currencies = _CurrencyRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);

            lstCurrencies = currencies.Select(cr => new SelectListItem()
            {

                Value = cr.Id.ToString(),
                Text = cr.ExchangeRate.ToString()

            }).ToList();
            return lstCurrencies;
        }

        private List<SelectListItem> GetUnitNames()
        {
            var lstProducts = new List<SelectListItem>();
            PaginatedList<Product> products = _ProductRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
            lstProducts = products.Select(ut => new SelectListItem()
            {
                Value = ut.Code.ToString(),
                Text = ut.Units.Name
            }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "--Select Unit----"
            };
            lstProducts.Insert(0, defItem);
            return lstProducts;
        }
    }
}
