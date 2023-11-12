using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }

        [Display(Name = "Product Picture URL")]
        public string productPictureURL { get; set; }

        [Display(Name = "Product Name")]
        public string productName { get; set; }

        [Display(Name = "Product Price")]
        public int Price { get; set; }

        [Display(Name = "Availablity")]
        public bool IsAvailable { get; set; }

        //Realtionships
        public List<Product_Customer> Products_Customers { get; set; }
    }
}
