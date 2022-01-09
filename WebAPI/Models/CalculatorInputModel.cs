using System.Collections.Generic;

namespace WebAPI.Models
{
    public class CalculatorInputModel
    {
        //TODO add swagger summary
        public int CustomerId { get; set; }
        public List<ItemListInputModel> ItemsList { get; set; }
        public CalculatorInputModel()
        {
            ItemsList = new List<ItemListInputModel>();
        }

    }
}
