using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FullName = "Bruno Mars",
                    Country = "US",
                    State = "NY",
                    ZipCode = "10118"
                },
                new Customer
                {
                    Id = 2,
                    FullName = "Jim Carrey",
                    Country = "CA",
                    State = "BC",
                    ZipCode = "V6G 3E2"
                },
                new Customer
                {
                    Id = 3,
                    FullName = "Thierry Henry",
                    Country = "FR",
                    ZipCode = "75008"
                },
                new Customer
                {
                    Id = 4,
                    FullName = "Nicole Kidman",
                    Country = "AU",
                    ZipCode = "NSW 2000"
                },
                new Customer
                {
                    Id = 5,
                    FullName = "Carey Price",
                    Country = "CA",
                    State = "QC",
                    ZipCode = "H3G 0B7"
                },
                new Customer
                {
                    Id = 6,
                    FullName = "Jean Reno",
                    Country = "FR",
                    ZipCode = "13281"
                },
                new Customer
                {
                    Id = 7,
                    FullName = "Mel Gibson",
                    Country = "AU",
                    ZipCode = "VIC 3002"
                });

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Description = "Hand Sanitizer",
                    Price = 13.95f
                },
                new Item
                {
                    Id = 2,
                    Description = "Dell p2419h Monitor",
                    Price = 449.99f
                },
                new Item
                {
                    Id = 3,
                    Description = "Delonghi Dedica Coffee Machine",
                    Price = 269.99f
                },
                new Item
                {
                    Id = 4,
                    Description = "Logitech MX Master 3 Mouse",
                    Price = 129.99f
                },
                new Item
                {
                    Id = 5,
                    Description = "BlackVue DR900X-2CH Plus DASH​CAM",
                    Price = 489.99f
                },
                new Item
                {
                    Id = 6,
                    Description = "Arduino Uno Rev3",
                    Price = 23f
                });
        }
    }
}
