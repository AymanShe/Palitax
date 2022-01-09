using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string State { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ZipCode { get; set; }

    }
}
