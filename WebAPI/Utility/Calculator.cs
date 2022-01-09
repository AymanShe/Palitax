using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Utility
{
    public static class Calculator
    {
        public static async Task<float> GetTotalTax(Customer customer, float amount, ITaxJarService taxJarService)
        {
            if (taxJarService is null) throw new ArgumentNullException("taxJarService");
            return await taxJarService.GetTotalTax(customer.Country, customer.State, customer.ZipCode, amount);
        }


        public static float GetTotal(List<Item> items, List<ItemListInputModel> itemListInputModels)
        {
            var total = 0f;
            foreach (var item in items)
            {
                total += item.Price * itemListInputModels.Where(x => x.Id == item.Id).First().Quantity;
            }
            return total;
        }
    }
}
