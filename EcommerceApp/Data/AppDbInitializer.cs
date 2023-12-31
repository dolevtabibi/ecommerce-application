﻿using EcommerceApp.Data.enums;
using EcommerceApp.Models;

namespace EcommerceApp.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Customer
                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(new List<Customer>()
                    {
                        new Customer()
                        {
                            fullName = "Dolev Tabibi",
                            Gender = "Male",
                            Email ="dolevtabibi@gmail.com",
                            phoneNumber = "0549051997",
                            profilePictureFile = null
                        },
                        new Customer()
                        {
                            fullName = "Eden Hatan",
                            Gender = "Female",
                            Email ="edenhatan7@gmail.com",
                            phoneNumber = "0527766586",
                            profilePictureFile = null
                        }
                    });
                    context.SaveChanges();
                }
                //Product
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            productName = typeOfService.Pedicure.ToString(),
                            Price = 100,
                            productPictureFile = File.ReadAllBytes("C:/Users/dolev/source/repos/EcommerceApp/EcommerceApp/wwwroot/Images/background.jpg"),
                            IsAvailable = false
                        },
                        new Product()
                        {
                            productName = typeOfService.GelX.ToString(),
                            Price = 80,
                            productPictureFile = File.ReadAllBytes("C:/Users/dolev/source/repos/EcommerceApp/EcommerceApp/wwwroot/Images/background.jpg"),

                            IsAvailable = true
                        },

                    });
                    context.SaveChanges();
                }
                //Appointments
                if (!context.Appointments.Any())
                {
                    context.Appointments.AddRange(new List<Appointment>()
                    {
                        new Appointment()
                        {
                            customerFullName = "Dolev Tabibi",
                            dateOfAppointment = DateTime.Now,
                            Remarks = "Alergic to",
                            Paid = false,
                            customerPhoneNumber = "0549051997",
                            Products = new List<Product>()
                            {
                                new Product
                                {
                                    Price = 100,
                                    productName = "Test",
                                    productPictureFile = File.ReadAllBytes("C:/Users/dolev/source/repos/EcommerceApp/EcommerceApp/wwwroot/Images/background.jpg"),
                                    IsAvailable = true
                                }
                            }
                        }
                    });
                    context.SaveChanges();
                }
                // Products & Customers
                if (!context.Products_Customers.Any())
                {
                    context.Products_Customers.AddRange(new List<Product_Customer>()
                    {
                        new Product_Customer()
                        {
                            ProductId = 1,
                            CustomerId = 2
                        }
                    });
                    context.SaveChanges();
                }

            }
        }
    }
}
