﻿using EcommerceApp.Data;
using EcommerceApp.Data.Services;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersService _service;

        public CustomersController(ICustomersService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await this._service.GetAllAsync();
            return View(data);
        }

        //Get: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("fullName, Email, phoneNumber,Gender,profilePictureFile")]Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return View(customer);
            }
            else
            {
               await _service.AddAsync(customer);
               return RedirectToAction(nameof(Index));
            }
        }

        //Get: Customers/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var customerDetails = await _service.GetByIdAsync(id);
            if(customerDetails == null) 
            {
                return View("Empty");
            }
            return View(customerDetails);
        }
    }
}