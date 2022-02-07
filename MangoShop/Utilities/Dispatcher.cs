using MangoShop.Models;
using MangoShop.Decoraters;

namespace MangoShop.Utilities
{
    public class Dispatcher
    {
        public static DecoratedProduct dispatch(Product product) {
            switch (product.Type) {
                case "ITEM":
                    return new ItemProduct(product);
                case "LOTTERY":
                    return new LotteryProduct(product);
                default:
                    return new NullProduct(product);
            }
        }
    }
}