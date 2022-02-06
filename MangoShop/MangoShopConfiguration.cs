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
                new Product(){ ID = 17, Price = 100, Type = "ITEM" }, // Military Drum
                new Product(){ ID = 43, Price = 50, Type = "ITEM" }, // Low Caliber Military Ammunition Crate
                new Product(){ ID = 44, Price = 50, Type = "ITEM" }, // Low Caliber Civilian Ammunition Box
                new Product(){ ID = 66, Price = 5, Type = "ITEM" }, // Cloth
                new Product(){ ID = 67, Price = 5, Type = "ITEM" }, // Metal Scrap
                new Product(){ ID = 113, Price = 15, Type = "ITEM" }, // 12 Gauge Shells
                new Product(){ ID = 119, Price = 20, Type = "ITEM" }, // 	Low Caliber Ranger Ammunition Box
                new Product(){ ID = 125, Price = 50, Type = "ITEM" }, // Ranger Drum
				new Product(){ ID = 301, Price = 5, Type = "ITEM" }, // Rail
				new Product(){ ID = 381, Price = 15, Type = "ITEM" }, // 20 Gauge Shells
				new Product(){ ID = 489, Price = 15, Type = "ITEM" }, // Desert Falcon Magazine
				new Product(){ ID = 520, Price = 5, Type = "ITEM" }, // Rocket
				new Product(){ ID = 1113, Price = 5, Type = "ITEM" }, // Snare
				new Product(){ ID = 1192, Price = 50, Type = "ITEM" }, // High Caliber Military Ammunition Crate
				new Product(){ ID = 1193, Price = 50, Type = "ITEM" }, // High Caliber Ranger Ammunition Box
				new Product(){ ID = 1194, Price = 2000, Type = "ITEM" }, // Horde Beacon
				new Product(){ ID = 1209, Price = 5, Type = "ITEM" }, // Explosive Arrow
				new Product(){ ID = 1219, Price = 200, Type = "ITEM" }, // Pump Jack
				new Product(){ ID = 1302, Price = 20, Type = "ITEM" }, // Missile
				new Product(){ ID = 1365, Price = 250, Type = "ITEM" }, // Hell's Fury Drum
				new Product(){ ID = 3502, Price = 5, Type = "ITEM" }, // MLRS Rocket
				new Product(){ ID = 3518, Price = 5, Type = "ITEM" }, // Lancer Rocket
            };
        }
    }
}