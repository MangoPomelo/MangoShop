using System;
using Rocket.Unturned.Player;
using MangoShop.Models;

namespace MangoShop.Products
{
    public abstract class Product
    {
        private MetaProduct _metaProduct;

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

        public uint GetPurchasedPrice()
        {
            return this.GetBasePrice();
        }
        public uint GetSellingPrice()
        {
            uint basePrice = this.GetBasePrice();
            double depreciationRate = this.GetDepreciationRate();
            return (uint)Math.Round(basePrice * (1 - depreciationRate));
        }

        public abstract Product PurchasedBy(UnturnedPlayer player, byte amount);
        public abstract Product SoldBy(UnturnedPlayer player, byte amount);
    }
}