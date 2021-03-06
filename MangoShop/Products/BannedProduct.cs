using System;
using Rocket.Unturned.Player;
using MangoShop.Models;
using MangoShop.Utilities;

namespace MangoShop.Products
{
    public class BannedProduct : Product
    {
        public static bool DoesMetaProductFit(MetaProduct metaProduct)
        {
            // Product type must be MetaProduct.BANNED_TYPE
            string productType = metaProduct.GetProductType();
            if (productType != MetaProduct.BANNED_TYPE)
            {
                return false;
            }

            return true;
        }
        public static Product CreateProduct(MetaProduct metaProduct)
        {
            if (!BannedProduct.DoesMetaProductFit(metaProduct))
            {
                throw new InvalidOperationException("Wrong meta product has been provided");
            }
            return new BannedProduct(metaProduct);
        }

        private BannedProduct(MetaProduct meta) : base(meta) {}

        public override Message PurchasedBy(UnturnedPlayer player, byte amount)
        {
            throw new NullReferenceException("Banned product cannot be purchased");
        }

        public override Message SoldBy(UnturnedPlayer player, byte amount)
        {
            throw new NullReferenceException("Banned product cannot be sold");
        }

        public override Message CheckedBy(UnturnedPlayer player, byte amount)
        {
            throw new NullReferenceException("Banned product cannot be checked");
        }
    }
}