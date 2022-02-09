using MangoShop.Models;
using MangoShop.Products;

namespace MangoShop.Utilities
{
    public class Dispatcher
    {
        public static Product dispatch(MetaProduct metaProduct) {
            switch (metaProduct.GetProductType()) {
                case MetaProduct.ITEM_TYPE:
                    return ItemProduct.CreateProduct(metaProduct);
                case MetaProduct.VEHICLE_TYPE:
                    return VehicleProduct.CreateProduct(metaProduct);
                case MetaProduct.HELP_TYPE:
                    return HelpProduct.CreateProduct(metaProduct);
                case MetaProduct.LOTTERY_TYPE:
                    return LotteryProduct.CreateProduct(metaProduct);
                case MetaProduct.BANNED_TYPE:
                    return BannedProduct.CreateProduct(metaProduct);
                case MetaProduct.UNKNOWN_TYPE:
                    return UnknownProduct.CreateProduct(metaProduct);
                default:
                    return NullProduct.CreateProduct(metaProduct);
            }
        }
    }
}