using System;
using Rocket.Unturned.Player;
using MangoShop.Models;
using MangoShop.Utilities;

namespace MangoShop.Products
{
    public class NullProduct : Product
    {
        public static bool DoesMetaProductFit(MetaProduct metaProduct)
        {
            // All meta product can be downgraded as NullProduct
            return true;
        }
        public static Product CreateProduct(MetaProduct metaProduct)
        {
            if (!NullProduct.DoesMetaProductFit(metaProduct))
            {
                throw new InvalidOperationException("Wrong meta product has been provided");
            }
            return new NullProduct(metaProduct);
        }

        private NullProduct(MetaProduct meta) : base(meta) {}

        public override Message PurchasedBy(UnturnedPlayer player, byte amount)
        {
            throw new NullReferenceException("Null Product");
        }

        public override Message SoldBy(UnturnedPlayer player, byte amount)
        {
            throw new NullReferenceException("Null Product");
        }

        public override Message CheckedBy(UnturnedPlayer player, byte amount)
        {
            throw new NullReferenceException("Null Product");
        }
    }
}