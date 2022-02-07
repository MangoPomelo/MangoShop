using System;
using Rocket.Unturned.Player;
using MangoShop.Models;

namespace MangoShop.Decoraters
{
    public abstract class DecoratedProduct
    {
        private Product _wrappeeProduct;

        public DecoratedProduct(Product product)
        {
            this._wrappeeProduct = product;
        }

        public DecoratedProduct SetProductType(string newType)
        {
            this._wrappeeProduct = this._wrappeeProduct.SetProductType(newType);
            return this;
        }
        public string GetProductType()
        {
            return this._wrappeeProduct.GetProductType();
        }

        public DecoratedProduct SetProductName(string newName)
        {
            this._wrappeeProduct = this._wrappeeProduct.SetProductName(newName);
            return this;
        }
        public string GetProductName()
        {
            return this._wrappeeProduct.GetProductName();
        }

        public DecoratedProduct SetBasePrice(uint newBasePrice)
        {
            this._wrappeeProduct = this._wrappeeProduct.SetBasePrice(newBasePrice);
            return this;
        }
        public uint GetBasePrice()
        {
            return this._wrappeeProduct.GetBasePrice();
        }

        public DecoratedProduct SetDepreciationRate(double newDepreciationRate)
        {
            this._wrappeeProduct = this._wrappeeProduct.SetDepreciationRate(newDepreciationRate);
            return this;
        }
        public double GetDepreciationRate()
        {
            return this._wrappeeProduct.GetDepreciationRate();
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

        public abstract DecoratedProduct PurchasedBy(UnturnedPlayer player, byte amount);
        public abstract DecoratedProduct SoldBy(UnturnedPlayer player, byte amount);
    }
}