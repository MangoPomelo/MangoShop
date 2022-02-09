using System;
using Rocket.Unturned.Player;
using MangoShop.Models;

namespace MangoShop.Products
{
    public class UnknownProduct : Product
    {
        public static bool DoesMetaProductFit(MetaProduct metaProduct)
        {
            // Product type must be MetaProduct.UNKNOWN_TYPE
            string productType = metaProduct.GetProductType();
            if (productType != MetaProduct.UNKNOWN_TYPE)
            {
                return false;
            }

            return true;
        }
        public static Product CreateProduct(MetaProduct metaProduct)
        {
            // Check if the meta fits ItemProduct, use DefaultMetaItemProduct to generate ItemProduct when it's true
            if (ItemProduct.DoesMetaProductFit(metaProduct))
            {
                MetaProduct DefaultMetaItemProduct = MangoShop.Instance.Configuration.Instance.DefaultMetaItemProduct.SetProductName(metaProduct.GetProductName());
                return ItemProduct.CreateProduct(DefaultMetaItemProduct);
            }

            // Check if the meta fits VehicleProduct, use DefaultMetaVehicleProduct to generate VehicleProduct when it's true
            // (WIP)

            // default regard it as NullProduct
            return NullProduct.CreateProduct(metaProduct);
        }

        private UnknownProduct(MetaProduct meta) : base(meta) {}

        public override void PurchasedBy(UnturnedPlayer player, byte amount)
        {
            throw new NotImplementedException();
        }

        public override void SoldBy(UnturnedPlayer player, byte amount)
        {
            throw new NotImplementedException();
        }
    }
}