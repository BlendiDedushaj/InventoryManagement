using InventoryManagement.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using SortOrder = InventoryManagement.Models.SortOrder;

namespace InventoryManagement.Interfaces
{
    public interface IUnit
    {
        List<Unit> GetItems(string SortProperty,SortOrder sortOrder); //read all

        Unit GetUnit(int id); //read particular item

        Unit Create(Unit unit);

        Unit Edit(Unit unit);

        Unit Delete(Unit unit);
    }
}
