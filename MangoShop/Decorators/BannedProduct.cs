using System;
using Rocket.Unturned.Player;
using MangoShop.Models;

namespace MangoShop.Decoraters
{
    public class BannedProduct : DecoratedProduct
    {
        public BannedProduct(Product product) : base(product) {}

        public override DecoratedProduct PurchasedBy(UnturnedPlayer player, byte amount)
        {
            throw new InvalidOperationException("This product is banned");
        }

        public override DecoratedProduct SoldBy(UnturnedPlayer player, byte amount)
        {
            throw new InvalidOperationException("This product is banned");
        }
    }
}