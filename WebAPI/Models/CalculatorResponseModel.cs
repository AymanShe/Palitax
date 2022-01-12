using System.Collections.Generic;

namespace WebAPI.Models
{
    public class CalculatorResponseModel
    {
        public string CustomerName { get; set; }
        public List<ItemListResponseModel> ItemList{ get; set; }
        public float Tax { get; set; }
        public float SubTotal { get; set; }
        public float TotalPrice { get; set; }
        public CalculatorResponseModel()
        {
            ItemList = new List<ItemListResponseModel>();
        }
    }
}
