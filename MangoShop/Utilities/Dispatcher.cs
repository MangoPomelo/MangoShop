using MangoShop.Models;
using MangoShop.Products;

namespace MangoShop.Utilities
{
    public class Dispatcher
    {
        public static Product dispatch(MetaProduct metaProduct) {
            switch (metaProduct.GetProductType()) {
                case MetaProduct.ITEM_TYPE:
                    return new ItemProduct(metaProduct);
                case MetaProduct.LOTTERY_TYPE:
                    return new LotteryProduct(metaProduct);
                case MetaProduct.BANNED_TYPE:
                    return new BannedProduct(metaProduct);
                case MetaProduct.DEFAULT_TYPE:
                    return new DefaultProduct(metaProduct);
                default:
                    return new NullProduct(metaProduct);
            }
        }
    }
}