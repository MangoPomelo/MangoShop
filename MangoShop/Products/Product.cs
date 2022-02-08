using System;
using System.Collections.Generic;
using Rocket.Unturned.Player;
using MangoShop.Models;

namespace MangoShop.Products
{
    public abstract class Product
    {
        private MetaProduct _metaProduct;
        private static Dictionary<string, ulong> _scarcityMap = new Dictionary<string, ulong>();

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

        public Product SetScarcity(ulong newScarcity)
        {
            string productName = this.GetProductName();
            Product._scarcityMap[productName] = Math.Max(0, newScarcity);
            return this;
        }
        public ulong GetScarcity()
        {
            string productName = this.GetProductName();
            try
            {
                return Product._scarcityMap[productName];
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
        }

        public uint GetPurchasePrice()
        {
            uint basePrice = this.GetBasePrice();
            uint floatPrice = (uint)Math.Round(this.GetScarcity() * this.GetElasticity());
            return basePrice + floatPrice;
        }
        public uint GetSellingPrice()
        {
            uint purchasePrice = this.GetPurchasePrice();
            uint depreciationPrice = (uint)Math.Round(this.GetDepreciationRate() * purchasePrice);
            return purchasePrice - depreciationPrice;
        }

        public abstract Product PurchasedBy(UnturnedPlayer player, byte amount);
        public abstract Product SoldBy(UnturnedPlayer player, byte amount);
    }
}