﻿using GFresh.Core.Data;
using GFresh.Core.DTO;
using GFresh.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace GFresh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateCategory([FromBody] Category category)
        {
            return _adminService.CreateCategory(category);
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        public List<Category> GetAllCategories()
        {
            return _adminService.GetAllCategories();
        }
        [HttpPut]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateCategory([FromBody] Category category)
        {
            return _adminService.UpdateCategory(category);
        }
        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public bool DeleteCategory(int id)
        {
            return _adminService.DeleteCategory(id);
        }
        [HttpPost]
        [Route("Product")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateProduct([FromBody] Product product)
        {
            return _adminService.CreateProduct(product);
        }
        [HttpGet]
        [Route("Product")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        public List<Product> GetAllProducts()
        {
            return _adminService.GetAllProducts();
        }
        [HttpPut]
        [Route("Product")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateProduct([FromBody] Product product)
        {
            return _adminService.UpdateProduct(product);
        }
        [HttpDelete]
        [Route("Product/{id}")]
        public bool DeleteProduct(int id)
        {
            return _adminService.DeleteProduct(id);
        }
        [HttpPost]
        [Route("UploadImg")]
        public Category UploadImage()
        {
            try
            {
                var Image = Request.Form.Files[0];
                var ImageName = Guid.NewGuid().ToString() + Image.FileName;
                var fullPath = Path.Combine("C:\\Users\\moham\\Desktop\\Batch12Angular\\src\\assets\\images", ImageName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                Category category = new Category();
                category.ImageName = ImageName;
                return category;
            }
            catch
            {
                return null;
            }
        }
        [HttpGet]
        [Route("NumberOfCustomers")]
        public NumOfRegisteredCustomers NumberOfCustomers()
        {
            return _adminService.NumberOfCustomers();
        }
        [HttpPost]
        [Route("SerachDates")]
        public List<SerachOrdersDate> SerachOrdersBetweenTwoDates([FromBody]DateTime DateFrom,DateTime DateTo)
        {
            return _adminService.SerachOrdersBetweenTwoDates(DateFrom, DateTo);
        }
        [HttpGet]
        [Route("MonthlyReport")]
        public List<MonthlyRep> MonthlyReport()
        {
            return _adminService.MonthlyReport();
        }
    }
}
