using Rocket.Unturned.Player;
using MangoShop.Models;

namespace MangoShop.Decoraters
{
    public abstract class DecoratedProduct
    {
        public ushort ID;
        public uint Price;
        public string Type;
        public DecoratedProduct(Product product)
        {
            this.ID = product.ID;
            this.Price = product.Price;
            this.Type = product.Type;
        }
        public abstract bool PurchasedBy(UnturnedPlayer player, byte amount);
    }
}