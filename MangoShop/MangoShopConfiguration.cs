using Rocket.API;
using MangoShop.Models;

namespace MangoShop
{
    public class MangoShopConfiguration : IRocketPluginConfiguration
    {
        public string LoadMessage { get; set; }
        public Product[] Products { get; set; }
        public void LoadDefaults()
        {
            LoadMessage = "This is mango shop plugin!";
            // Load default configuration for products
            Products = new Product[]
            {
                new Product(){ ID = 4, Price = 0 },
                new Product(){ ID = 18, Price = 0 },
                new Product(){ ID = 97, Price = 0 },
                new Product(){ ID = 99, Price = 0 }
            };
        }
    }
}