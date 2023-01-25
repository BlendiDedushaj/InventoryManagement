﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models;
//using CodesByAniz.Tools;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Interfaces
{
    public interface IProductAttribute
    {
        PaginatedList<ProductAttribute> GetItems(AttributeType attributeType, string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        ProductAttribute GetItem(int id); // read particular item

        ProductAttribute Create(ProductAttribute unit);
        ProductAttribute Edit(ProductAttribute unit);

        ProductAttribute Delete(ProductAttribute unit);

        public bool IsItemExists(string name, AttributeType attributeType);
        public bool IsItemExists(string name, int Id, AttributeType attributeType);


    }
}


