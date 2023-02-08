using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Areas.Admin.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
