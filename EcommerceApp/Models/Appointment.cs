using EcommerceApp.Data.enums;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
    public class Appointment
    {
        [Key]
        public int appointmentId { get; set; }
        public bool Paid { get; set; } = false;
        public string customerFullName { get; set; }
        public string customerPhoneNumber { get; set; }
        public DateTime dateOfAppointment { get; set; }
        public typeOfService TypeOfService { get; set; }
        public string Remarks { get; set; }

        //Relationships
        public List<Product> Products { get; set; }
    }
}
