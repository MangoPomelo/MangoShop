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
            Products = GetDefaultProducts();
        }
        private Product[] GetDefaultProducts()
        {
            return new Product[]
            {
                new Product(){ Name = "Eaglefire", Price = 0, ItemId = 4 },
                new Product(){ Name = "Timberwolf", Price = 0, ItemId = 18 },
                new Product(){ Name = "1911", Price = 0, ItemId = 97 },
                new Product(){ Name = "Cobra", Price = 0, ItemId = 99 }
            };
        }
    }
}