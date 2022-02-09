using Rocket.API;
using MangoShop.Models;

namespace MangoShop
{
    public class MangoShopConfiguration : IRocketPluginConfiguration
    {
        public string MessageColor { get; set; }
        public string LoadMessage { get; set; }
        public float DecreaseGlobalScarcityInterval { get; set; }
        public MetaProduct DefaultMetaItemProduct { get; set; }
        public MetaProduct[] OnSaleProducts { get; set; }

        public void LoadDefaults()
        {
            // Load message configuration
            MessageColor = "yellow";
            LoadMessage = "This is mango shop plugin!";
            // Load scarcity decrease routine interval
            DecreaseGlobalScarcityInterval = 900;
            // Load default configuration for products
            DefaultMetaItemProduct = new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = MetaProduct.ITEM_TYPE, BasePrice = 100, DepreciationRate = 0.8, Elasticity = 1 };
            OnSaleProducts = new MetaProduct[]
            {
                new MetaProduct(){ ProductType = MetaProduct.BANNED_TYPE, ProductName = "i.1099", BasePrice = 0, DepreciationRate = 1.0, Elasticity = 0 }, // 4 Seater Makeshift Vehicle
				new MetaProduct(){ ProductType = MetaProduct.BANNED_TYPE, ProductName = "i.1111", BasePrice = 0, DepreciationRate = 1.0, Elasticity = 0 }, // 6 Seater Makeshift Vehicle
				new MetaProduct(){ ProductType = MetaProduct.BANNED_TYPE, ProductName = "i.1112", BasePrice = 0, DepreciationRate = 1.0, Elasticity = 0 }, // 1 Seater Makeshift Vehicle
				new MetaProduct(){ ProductType = MetaProduct.BANNED_TYPE, ProductName = "i.2021", BasePrice = 0, DepreciationRate = 1.0, Elasticity = 0 }, // Raft Makeshift Vehicle
				new MetaProduct(){ ProductType = MetaProduct.BANNED_TYPE, ProductName = "i.2022", BasePrice = 0, DepreciationRate = 1.0, Elasticity = 0 }, // Gyro Makeshift Vehicle
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.17", BasePrice = 100, DepreciationRate = 0.4, Elasticity = 1 }, // Military Drum
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.43", BasePrice = 50, DepreciationRate = 0.4, Elasticity = 1 }, // Low Caliber Military Ammunition Crate
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.44", BasePrice = 50, DepreciationRate = 0.4, Elasticity = 1 }, // Low Caliber Civilian Ammunition Box
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.66", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 0.2 }, // Cloth
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.67", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 0.2 }, // Metal Scrap
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.113", BasePrice = 15, DepreciationRate = 0.4, Elasticity = 1 }, // 12 Gauge Shells
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.119", BasePrice = 20, DepreciationRate = 0.4, Elasticity = 1 }, // Low Caliber Ranger Ammunition Box
                new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.125", BasePrice = 50, DepreciationRate = 0.4, Elasticity = 1 }, // Ranger Drum
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.301", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 0.2 }, // Rail
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.381", BasePrice = 15, DepreciationRate = 0.4, Elasticity = 1 }, // 20 Gauge Shells
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.489", BasePrice = 15, DepreciationRate = 0.4, Elasticity = 1 }, // Desert Falcon Magazine
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.520", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 0.2 }, // Rocket
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.1113", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 0.2 }, // Snare
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.1192", BasePrice = 50, DepreciationRate = 0.4, Elasticity = 1 }, // High Caliber Military Ammunition Crate
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.1193", BasePrice = 50, DepreciationRate = 0.4, Elasticity = 1 }, // High Caliber Ranger Ammunition Box
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.1194", BasePrice = 2000, DepreciationRate = 0.4, Elasticity = 250 }, // Horde Beacon
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.1209", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 1 }, // Explosive Arrow
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.1219", BasePrice = 200, DepreciationRate = 0.4, Elasticity = 100 }, // Pump Jack
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.1302", BasePrice = 20, DepreciationRate = 0.4, Elasticity = 2 }, // Missile
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.1365", BasePrice = 250, DepreciationRate = 0.4, Elasticity = 10 }, // Hell's Fury Drum
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.3502", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 0.2 }, // MLRS Rocket
				new MetaProduct(){ ProductType = MetaProduct.ITEM_TYPE, ProductName = "i.3518", BasePrice = 5, DepreciationRate = 0.4, Elasticity = 0.2 }, // Lancer Rocket
                new MetaProduct(){ ProductType = MetaProduct.LOTTERY_TYPE, ProductName = "lottery", BasePrice = 100, DepreciationRate = 1.0, Elasticity = 0 }, // Lottery
            };
        }
    }
}