using System;
using Rocket.Unturned.Player;
using MangoShop.Models;

namespace MangoShop.Decoraters
{
    public class NullProduct : DecoratedProduct
    {
        public NullProduct(Product product) : base(product) {}

        public override DecoratedProduct PurchasedBy(UnturnedPlayer player, byte amount)
        {
            throw new InvalidOperationException("Null Product");
        }

        public override DecoratedProduct SoldBy(UnturnedPlayer player, byte amount)
        {
            throw new InvalidOperationException("Null Product");
        }
    }
}