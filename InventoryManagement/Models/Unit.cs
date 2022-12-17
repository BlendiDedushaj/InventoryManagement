using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public enum ScortOrder { Ascending=0, Descending=1 }
    public class Unit
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        public string Description { get; set; }

    }
}
