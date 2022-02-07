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
                default:
                    return new NullProduct(product);
            }
        }
    }
}