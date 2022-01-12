namespace WebAPI.Models
{
    public class ItemListResponseModel
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public float Total { get; set; }
    }
}