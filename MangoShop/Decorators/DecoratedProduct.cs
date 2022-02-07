using Rocket.Unturned.Player;
using MangoShop.Models;

namespace MangoShop.Decoraters
{
    public abstract class DecoratedProduct
    {
        public string Name;
        public uint Price;
        public string Type;

        public DecoratedProduct(Product product)
        {
            this.Name = product.Name;
            this.Price = product.Price;
            this.Type = product.Type;
        }

        public abstract DecoratedProduct PurchasedBy(UnturnedPlayer player, byte amount);
        public abstract DecoratedProduct SoldBy(UnturnedPlayer player, byte amount);
    }
}