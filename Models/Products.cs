using System.ComponentModel.DataAnnotations;

namespace ProductsManagementAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public int ProductTypeId { get; set; }

        public ProductType? ProductTypes { get; set; }

        public bool Active { get; set; }
    }
}
