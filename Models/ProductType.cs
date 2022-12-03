using System.ComponentModel.DataAnnotations;

namespace ProductsManagementAPI.Models
{
    public class ProductType
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string ProductTypeName { get; set; } = string.Empty;
    }
}
