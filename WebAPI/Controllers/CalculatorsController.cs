﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;
using WebAPI.Utility;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorsController : ControllerBase
    {
        private readonly PalitaxDbContext _context;
        private readonly ITaxJarService _taxJarService;

        public CalculatorsController(PalitaxDbContext palitaxDbContext, ITaxJarService taxJarService)
        {
            _context = palitaxDbContext;
            _taxJarService = taxJarService;
        }


        // POST api/<CalculatorsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CalculatorInputModel inputModel)
        {
            //TODO rearrange awaits for max performance
            //TODO validate input

            CalculatorResponseModel response = new CalculatorResponseModel();
            //fetch user
            var customer = await _context.Customer.FindAsync(inputModel.CustomerId);
            if (customer == null)
            {
                return NotFound("Customer was not found");
            }
            response.CustomerName = customer.FullName;

            var itemList = new List<Item>();
            //fetch items
            foreach (var inputItem in inputModel.ItemsList)
            {
                var item = await _context.Item.FindAsync(inputItem.Id);
                if (item == null)
                {
                    return NotFound($"Item with ID {inputItem.Id} was not found");
                }
                //TODO what if there are duplicate items
                itemList.Add(item);
                response.ItemList.Add(new ItemListResponseModel
                {
                    Item = item,
                    Total = item.Price * inputItem.Quantity
                });
            }

            //calculate
            var priceBeforeTax = Calculator.GetTotal(itemList, inputModel.ItemsList);
            //TODO find a better way than method injection
            response.Tax = await Calculator.GetTotalTax(customer, priceBeforeTax, _taxJarService);
            response.TotalPrice = response.Tax + priceBeforeTax;

            return Ok(response);
        }
    }
}
