using InventoryManagement.Data;
using InventoryManagement.Interfaces;
using InventoryManagement.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using SortOrder = InventoryManagement.Models.SortOrder;

namespace InventoryManagement.Repositories
{
    public class UnitRepository : IUnit
    {
        private readonly InventoryContext _context;

        public UnitRepository(InventoryContext context)
        {
            _context = context;
        }

        public Unit Create(Unit unit)
        {
            _context.Units.Add(unit);
            _context.SaveChanges();
            return unit;    
        }

        public Unit Delete(Unit unit)
        {
            _context.Units.Attach(unit);
            _context.Entry(unit).State = EntityState.Deleted;
            _context.SaveChanges();
            return unit;
        }

        public Unit Edit(Unit unit)
        {
            _context.Units.Attach(unit);
            _context.Entry(unit).State = EntityState.Modified;
            _context.SaveChanges();
            return unit;
        }

        public List<Unit> GetItems(string SortProperty, SortOrder sortOrder) 
        {
            List<Unit> units = _context.Units.ToList();

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                    units = units.OrderBy(n => n.Name).ToList();
                else 
                    units = units.OrderByDescending(n => n.Name).ToList();
            }
            else
            {

                if (sortOrder == SortOrder.Ascending)
                    units = units.OrderBy(d => d.Description).ToList();
                else
                    units = units.OrderByDescending(d => d.Description).ToList();
            }

            return units;
        }

        public Unit GetUnit(int id) 
        {
            Unit unit = _context.Units.Where(u => u.Id == id).FirstOrDefault();
            return unit;
        }

    }
}
