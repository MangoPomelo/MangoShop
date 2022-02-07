using MangoShop.Models;
using MangoShop.Decoraters;

namespace MangoShop.Utilities
{
    public class Dispatcher
    {
        public static DecoratedProduct dispatch(Product product) {
            switch (product.Type) {
                case Product.ITEM_TYPE:
                    return new ItemProduct(product);
                case Product.LOTTERY_TYPE:
                    return new LotteryProduct(product);
                case Product.BANNED_TYPE:
                    return new BannedProduct(product);
                case Product.DEFAULT_TYPE:
                    return new DefaultProduct(product);
                default:
                    return new NullProduct(product);
            }
        }
    }
}