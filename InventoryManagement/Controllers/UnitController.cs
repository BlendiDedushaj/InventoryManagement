﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Data;
using InventoryManagement.Interfaces;
using InventoryManagement.Repositories;
using Microsoft.Data.SqlClient;
using SortOrder = InventoryManagement.Models.SortOrder;

namespace InventoryManagement.Controllers
{

    public class UnitController : Controller
    {
        public IActionResult Index(string sortExpression="")                //read method of the crud operation
        {
            ViewData["SortParamName"] = "name";
            ViewData["SortParamDesc"] = "description";

            ViewData["SortIconName"] = "";
            ViewData["SortIconDesc"] = "";

            SortOrder sortOrder;
            string sortproperty;

            switch (sortExpression.ToLower())
            {
                case "name_desc":
                    sortOrder = SortOrder.Descending;
                    sortproperty = "name";
                    ViewData["SortParamName"] = "name";
                    ViewData["SortIconName"] = "fa fa-arrow-up";
                    break;

                case "description":
                    sortOrder = SortOrder.Ascending;
                    sortproperty = "description";
                    ViewData["SortParamDesc"] = "description_desc";
                    ViewData["SortIconDesc"] = "fa fa-arrow-down";
                    break;

                case "description_desc":
                    sortOrder = SortOrder.Descending;
                    sortproperty = "description";
                    ViewData["SortParamDesc"] = "description";
                    ViewData["SortIconDesc"] = "fa fa-arrow-up";
                    break;
                default:
                    sortOrder = SortOrder.Ascending;
                    sortproperty = "name";
                    ViewData["SortIconName"]="fa fa-arrow-down";
                    ViewData["SortParamName"] = "name_desc";
                    break;
            }

            List<Unit> units = _unitRepo.GetItems(sortproperty,sortOrder);//_context.Units.ToList();
            return View(units);
        }


        private readonly IUnit _unitRepo;


        public UnitController(IUnit unitrepo)
        {
            _unitRepo = unitrepo;
        }

        public IActionResult Details(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }


        public IActionResult Create()
        {
            Unit unit = new Unit();
            return View(unit);
        }

        [HttpPost]
        public IActionResult Create( Unit unit)
        {
            try
            {
                unit = _unitRepo.Create(unit);
            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Edit(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Edit(Unit unit)
        {
          try
                {
                 unit = _unitRepo.Edit(unit);
                }
                catch
                {

                }
                return RedirectToAction(nameof(Index));
         
        }

        public IActionResult Delete(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Delete(Unit unit)
        {
            try
            {
                unit = _unitRepo.Delete(unit);
            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));

        }


    }
}