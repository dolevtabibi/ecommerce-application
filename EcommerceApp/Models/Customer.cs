using EcommerceApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
    public class Customer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "Full Name must be between 3 and 50 characters")]
        public string fullName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number is required")]
        public string phoneNumber { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Display(Name = "Picture")]
        public byte[]? profilePictureFile { get; set; }


        //Realtionships
        public List<Appointment>? Appointments { get; set; }
        public List<Product_Customer>? Products_Customers { get; set; }  

    }
}
