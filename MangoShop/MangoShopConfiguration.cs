using Rocket.API;
using MangoShop.Models;

namespace MangoShop
{
    public class MangoShopConfiguration : IRocketPluginConfiguration
    {
        public string MessageColor { get; set; }
        public string LoadMessage { get; set; }
        public MetaProduct DefaultProduct { get; set; }
        public MetaProduct[] OnSaleProducts { get; set; }

        public void LoadDefaults()
        {
            // Load message configuration
            MessageColor = "yellow";
            LoadMessage = "This is mango shop plugin!";
            // Load default configuration for products
            DefaultProduct = new MetaProduct(){ ProductType = MetaProduct.DEFAULT_TYPE, ProductName = MetaProduct.DEFAULT_TYPE, BasePrice = 100, DepreciationRate = 0.8, Elasticity = 1 };
            OnSaleProducts = new MetaProduct[]
            {
                new MetaProduct(){ ProductType = MetaProduct.BANNED_TYPE, ProductName = "1099", BasePrice = 0, DepreciationRate = 1.0, Elasticity = 0 }, // 4 Seater Makeshift Vehicle
				new MetaProduct(){ ProductType = MetaProduct.BANNED_TYPE, ProductName = "1111", BasePrice = 0, DepreciationRate = 1.0, Elasticity = 0 }, // 6 Seater Makeshift Vehicle
				new MetaProduct(){ ProductType = MetaProduct.BANNED_TYPE, ProductName = "1112", BasePrice = 0, DepreciationRate = 1.0, Elasticity = 0 }, // 1 Seater Makeshift Vehicle
				new MetaProduct(){ ProductType = MetaProduct.BANNED_TYPE, ProductName = "2021", BasePrice = 0, DepreciationRate = 1.0, Elasticity = 0 }, // Raft Makeshift Vehicle
				new MetaProduct(){ ProductType = MetaProduct.BANNED_TYPE, ProductName = "2022", BasePrice = 0, DepreciationRate = 1.0, Elasticity = 0 }, // Gyro Makeshift Vehicle
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "17", BasePrice = 100, DepreciationRate = 0.4, Elasticity = 1 }, // Military Drum
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "43", BasePrice = 50, DepreciationRate = 0.4, Elasticity = 1 }, // Low Caliber Military Ammunition Crate
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "44", BasePrice = 50, DepreciationRate = 0.4, Elasticity = 1 }, // Low Caliber Civilian Ammunition Box
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "66", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 0.2 }, // Cloth
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "67", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 0.2 }, // Metal Scrap
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "113", BasePrice = 15, DepreciationRate = 0.4, Elasticity = 1 }, // 12 Gauge Shells
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "119", BasePrice = 20, DepreciationRate = 0.4, Elasticity = 1 }, // Low Caliber Ranger Ammunition Box
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "125", BasePrice = 50, DepreciationRate = 0.4, Elasticity = 1 }, // Ranger Drum
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "301", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 0.2 }, // Rail
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "381", BasePrice = 15, DepreciationRate = 0.4, Elasticity = 1 }, // 20 Gauge Shells
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "489", BasePrice = 15, DepreciationRate = 0.4, Elasticity = 1 }, // Desert Falcon Magazine
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "520", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 0.2 }, // Rocket
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "1113", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 0.2 }, // Snare
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "1192", BasePrice = 50, DepreciationRate = 0.4, Elasticity = 1 }, // High Caliber Military Ammunition Crate
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "1193", BasePrice = 50, DepreciationRate = 0.4, Elasticity = 1 }, // High Caliber Ranger Ammunition Box
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "1194", BasePrice = 2000, DepreciationRate = 0.4, Elasticity = 250 }, // Horde Beacon
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "1209", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 1 }, // Explosive Arrow
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "1219", BasePrice = 200, DepreciationRate = 0.4, Elasticity = 100 }, // Pump Jack
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "1302", BasePrice = 20, DepreciationRate = 0.4, Elasticity = 2 }, // Missile
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "1365", BasePrice = 250, DepreciationRate = 0.4, Elasticity = 10 }, // Hell's Fury Drum
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "3502", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 0.2 }, // MLRS Rocket
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "3518", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 0.2 }, // Lancer Rocket
                new MetaProduct(){ ProductType = MetaProduct.LOTTERY_TYPE, ProductName = "lottery", BasePrice = 100, DepreciationRate = 1.0, Elasticity = 0 }, // Lottery
            };
        }
    }
}