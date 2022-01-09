namespace WebAPI.Models
{
    public class TaxJarRequestModel
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }
        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        public float amount { get; set; }
        public int shipping { get { return 0; } }
    }
}
