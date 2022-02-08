using System;
using Rocket.Unturned.Player;
using MangoShop.Models;

namespace MangoShop.Products
{
    public class BannedProduct : Product
    {
        public BannedProduct(MetaProduct meta) : base(meta) {}

        public override Product PurchasedBy(UnturnedPlayer player, byte amount)
        {
            throw new InvalidOperationException("This product is banned");
        }

        public override Product SoldBy(UnturnedPlayer player, byte amount)
        {
            throw new InvalidOperationException("This product is banned");
        }
    }
}