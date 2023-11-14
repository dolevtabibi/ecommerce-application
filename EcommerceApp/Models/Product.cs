using EcommerceApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
    public class Product : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Picture")]
        [Required(ErrorMessage = "Picture is required")]
        public byte[] productPictureFile { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [Display(Name = "Product Name")]
        public string productName { get; set; }

        [Required(ErrorMessage = "Product Price is required")]
        [Display(Name = "Product Price")]
        public int Price { get; set; }

        [Display(Name = "Availability")]
        public bool IsAvailable { get; set; }

        //Realtionships
        public List<Product_Customer>? Products_Customers { get; set; }
    }
}
