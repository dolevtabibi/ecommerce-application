﻿using EcommerceApp.Data.Base;
using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data.Services
{
    public class CustomerssService : EntityBaseRepository<Customer>, ICustomersService
    {
        public CustomerssService(AppDbContext context) : base(context)
        {

        }
    }
}
