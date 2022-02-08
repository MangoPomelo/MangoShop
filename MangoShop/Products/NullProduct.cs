using System;
using Rocket.Unturned.Player;
using MangoShop.Models;

namespace MangoShop.Products
{
    public class NullProduct : Product
    {
        public NullProduct(MetaProduct product) : base(product) {}

        public override Product PurchasedBy(UnturnedPlayer player, byte amount)
        {
            throw new InvalidOperationException("Null Product");
        }

        public override Product SoldBy(UnturnedPlayer player, byte amount)
        {
            throw new InvalidOperationException("Null Product");
        }
    }
}