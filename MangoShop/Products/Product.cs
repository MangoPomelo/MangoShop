using System;
using System.Collections.Generic;
using Rocket.Unturned.Player;
using MangoShop.Models;
using MangoShop.Utilities;

namespace MangoShop.Products
{
    public abstract class Product
    {
        private MetaProduct _metaProduct;
        
        private static Dictionary<string, ulong> _scarcityMap = new Dictionary<string, ulong>();
        public static void DecreaseGlobalScarcity() {
            foreach(KeyValuePair<string, ulong> entry in Product._scarcityMap) {
                string productName = entry.Key;
                ulong scarcity = entry.Value;
                Product._scarcityMap[productName] = scarcity >= 1 ? scarcity - 1 : 0; // Watch out for underflow
            }
        }

        public Product(MetaProduct meta)
        {
            this._metaProduct = meta;
        }

        public Product SetProductType(string newType)
        {
            this._metaProduct = this._metaProduct.SetProductType(newType);
            return this;
        }
        public string GetProductType()
        {
            return this._metaProduct.GetProductType();
        }

        public Product SetProductName(string newName)
        {
            this._metaProduct = this._metaProduct.SetProductName(newName);
            return this;
        }
        public string GetProductName()
        {
            return this._metaProduct.GetProductName();
        }

        public Product SetBasePrice(uint newBasePrice)
        {
            this._metaProduct = this._metaProduct.SetBasePrice(newBasePrice);
            return this;
        }
        public uint GetBasePrice()
        {
            return this._metaProduct.GetBasePrice();
        }

        public Product SetDepreciationRate(double newDepreciationRate)
        {
            this._metaProduct = this._metaProduct.SetDepreciationRate(newDepreciationRate);
            return this;
        }
        public double GetDepreciationRate()
        {
            return this._metaProduct.GetDepreciationRate();
        }

        public Product SetElasticity(double newElasticity)
        {
            this._metaProduct = this._metaProduct.SetElasticity(newElasticity);
            return this;
        }
        public double GetElasticity()
        {
            return this._metaProduct.GetElasticity();;
        }

        public Product IncreaseScarcity(byte unit)
        {
            string productName = this.GetProductName();
            Product._scarcityMap[productName] = Product._scarcityMap.ContainsKey(productName) ? Product._scarcityMap[productName] + unit : unit;
            return this;
        }
        public Product DecreaseScarcity(byte unit)
        {
            string productName = this.GetProductName();
            // Check if the key exists and if it won't trigger underflow, set 0 if it will
            Product._scarcityMap[productName] = Product._scarcityMap.ContainsKey(productName) && Product._scarcityMap[productName] >= unit ? Product._scarcityMap[productName] - unit : 0;
            return this;
        }

        public uint GetPurchasePrice()
        {
            uint basePrice = this.GetBasePrice();
            uint floatPrice = (uint)Math.Round(this._getScarcity() * this.GetElasticity());
            return basePrice + floatPrice;
        }
        private ulong _getScarcity()
        {
            string productName = this.GetProductName();
            return Product._scarcityMap.ContainsKey(productName) ? Product._scarcityMap[productName] : 0;
        }
        public uint GetSellingPrice()
        {
            uint purchasePrice = this.GetPurchasePrice();
            uint depreciationPrice = (uint)Math.Round(this.GetDepreciationRate() * purchasePrice);
            return purchasePrice - depreciationPrice;
        }

        public abstract Message PurchasedBy(UnturnedPlayer player, byte amount);
        public abstract Message SoldBy(UnturnedPlayer player, byte amount);
        public abstract Message CheckedBy(UnturnedPlayer player, byte amount);
    }
}