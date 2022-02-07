using Rocket.API;
using MangoShop.Models;

namespace MangoShop
{
    public class MangoShopConfiguration : IRocketPluginConfiguration
    {
        public string MessageColor { get; set; }
        public string LoadMessage { get; set; }
        public Product DefaultProduct { get; set; }
        public Product[] OnSaleProducts { get; set; }

        public void LoadDefaults()
        {
            // Load message configuration
            MessageColor = "yellow";
            LoadMessage = "This is mango shop plugin!";
            // Load default configuration for products
            DefaultProduct = new Product(){ ProductType = Product.DEFAULT_TYPE, ProductName = Product.DEFAULT_TYPE, BasePrice = 100 };
            OnSaleProducts = new Product[]
            {
                new Product(){ ProductType = Product.BANNED_TYPE, ProductName = "1099", BasePrice = 0 }, // 4 Seater Makeshift Vehicle
				new Product(){ ProductType = Product.BANNED_TYPE, ProductName = "1111", BasePrice = 0 }, // 6 Seater Makeshift Vehicle
				new Product(){ ProductType = Product.BANNED_TYPE, ProductName = "1112", BasePrice = 0 }, // 1 Seater Makeshift Vehicle
				new Product(){ ProductType = Product.BANNED_TYPE, ProductName = "2021", BasePrice = 0 }, // Raft Makeshift Vehicle
				new Product(){ ProductType = Product.BANNED_TYPE, ProductName = "2022", BasePrice = 0 }, // Gyro Makeshift Vehicle
                new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "17", BasePrice = 100 }, // Military Drum
                new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "43", BasePrice = 50 }, // Low Caliber Military Ammunition Crate
                new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "44", BasePrice = 50 }, // Low Caliber Civilian Ammunition Box
                new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "66", BasePrice = 5 }, // Cloth
                new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "67", BasePrice = 5 }, // Metal Scrap
                new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "113", BasePrice = 15 }, // 12 Gauge Shells
                new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "119", BasePrice = 20 }, // Low Caliber Ranger Ammunition Box
                new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "125", BasePrice = 50 }, // Ranger Drum
				new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "301", BasePrice = 5 }, // Rail
				new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "381", BasePrice = 15 }, // 20 Gauge Shells
				new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "489", BasePrice = 15 }, // Desert Falcon Magazine
				new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "520", BasePrice = 5 }, // Rocket
				new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "1113", BasePrice = 5 }, // Snare
				new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "1192", BasePrice = 50 }, // High Caliber Military Ammunition Crate
				new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "1193", BasePrice = 50 }, // High Caliber Ranger Ammunition Box
				new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "1194", BasePrice = 2000 }, // Horde Beacon
				new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "1209", BasePrice = 5 }, // Explosive Arrow
				new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "1219", BasePrice = 200 }, // Pump Jack
				new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "1302", BasePrice = 20 }, // Missile
				new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "1365", BasePrice = 250 }, // Hell's Fury Drum
				new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "3502", BasePrice = 5 }, // MLRS Rocket
				new Product(){ ProductType = Product.ITEM_TYPE, ProductName = "3518", BasePrice = 5 }, // Lancer Rocket
                new Product(){ ProductType = Product.LOTTERY_TYPE, ProductName = "lottery", BasePrice = 100 }, // Lottery
            };
        }
    }
}