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

        public abstract DecoratedProduct PurchasedBy(UnturnedPlayer player, byte amount);
        public abstract DecoratedProduct SoldBy(UnturnedPlayer player, byte amount);
    }
}