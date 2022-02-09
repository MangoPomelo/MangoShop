using System;
using Rocket.Unturned.Player;
using MangoShop.Models;
using MangoShop.Utilities;

namespace MangoShop.Products
{
    public class HelpProduct : Product
    {
        public static bool DoesMetaProductFit(MetaProduct metaProduct)
        {
            // Product type must be MetaProduct.HELP_TYPE
            string productType = metaProduct.GetProductType();
            if (productType != MetaProduct.HELP_TYPE)
            {
                return false;
            }

            // Product name must be strictly "help"
            string productName = metaProduct.GetProductName();
            if (productName != "help")
            {
                return false;
            }

            return true;
        }
        public static Product CreateProduct(MetaProduct metaProduct)
        {
            if (!HelpProduct.DoesMetaProductFit(metaProduct))
            {
                throw new InvalidOperationException("Wrong meta product has been provided");
            }
            return new HelpProduct(metaProduct);
        }

        private HelpProduct(MetaProduct meta) : base(meta) {}

        public override Message PurchasedBy(UnturnedPlayer player, byte amount)
        {
            return new Message($"\"/buy i.121\" = \"Buy item ID 121\"");
        }

        public override Message SoldBy(UnturnedPlayer player, byte amount)
        {
            return new Message($"\"/sell i.121\" = \"Sell item ID 121\"");
        }

        public override Message CheckedBy(UnturnedPlayer player, byte amount)
        {
            return new Message($"\"/check i.121\" = \"Check price of item ID 121\"");
        }
    }
}