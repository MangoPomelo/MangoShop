using Rocket.API;
using MangoShop.Models;

namespace MangoShop
{
    public class MangoShopConfiguration : IRocketPluginConfiguration
    {
        public string LoadMessage { get; set; }
        public Product[] OnSaleProducts { get; set; }

        public void LoadDefaults()
        {
            LoadMessage = "This is mango shop plugin!";
            // Load default configuration for on sale products
            OnSaleProducts = new Product[]
            {
                new Product(){ Type = Product.ITEM_TYPE, Name = "17", Price = 100 }, // Military Drum
                new Product(){ Type = Product.ITEM_TYPE, Name = "43", Price = 50 }, // Low Caliber Military Ammunition Crate
                new Product(){ Type = Product.ITEM_TYPE, Name = "44", Price = 50 }, // Low Caliber Civilian Ammunition Box
                new Product(){ Type = Product.ITEM_TYPE, Name = "66", Price = 5 }, // Cloth
                new Product(){ Type = Product.ITEM_TYPE, Name = "67", Price = 5 }, // Metal Scrap
                new Product(){ Type = Product.ITEM_TYPE, Name = "113", Price = 15 }, // 12 Gauge Shells
                new Product(){ Type = Product.ITEM_TYPE, Name = "119", Price = 20 }, // 	Low Caliber Ranger Ammunition Box
                new Product(){ Type = Product.ITEM_TYPE, Name = "125", Price = 50 }, // Ranger Drum
				new Product(){ Type = Product.ITEM_TYPE, Name = "301", Price = 5 }, // Rail
				new Product(){ Type = Product.ITEM_TYPE, Name = "381", Price = 15 }, // 20 Gauge Shells
				new Product(){ Type = Product.ITEM_TYPE, Name = "489", Price = 15 }, // Desert Falcon Magazine
				new Product(){ Type = Product.ITEM_TYPE, Name = "520", Price = 5 }, // Rocket
				new Product(){ Type = Product.ITEM_TYPE, Name = "1113", Price = 5 }, // Snare
				new Product(){ Type = Product.ITEM_TYPE, Name = "1192", Price = 50 }, // High Caliber Military Ammunition Crate
				new Product(){ Type = Product.ITEM_TYPE, Name = "1193", Price = 50 }, // High Caliber Ranger Ammunition Box
				new Product(){ Type = Product.ITEM_TYPE, Name = "1194", Price = 2000 }, // Horde Beacon
				new Product(){ Type = Product.ITEM_TYPE, Name = "1209", Price = 5 }, // Explosive Arrow
				new Product(){ Type = Product.ITEM_TYPE, Name = "1219", Price = 200 }, // Pump Jack
				new Product(){ Type = Product.ITEM_TYPE, Name = "1302", Price = 20 }, // Missile
				new Product(){ Type = Product.ITEM_TYPE, Name = "1365", Price = 250 }, // Hell's Fury Drum
				new Product(){ Type = Product.ITEM_TYPE, Name = "3502", Price = 5 }, // MLRS Rocket
				new Product(){ Type = Product.ITEM_TYPE, Name = "3518", Price = 5 }, // Lancer Rocket
                new Product(){ Type = Product.LOTTERY_TYPE, Name = "lottery", Price = 100 }, // Lottery
            };
        }
    }
}