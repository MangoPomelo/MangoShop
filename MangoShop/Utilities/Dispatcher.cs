using MangoShop.Models;
using MangoShop.Decoraters;

namespace MangoShop.Utilities
{
    public class Dispatcher
    {
        public static DecoratedProduct dispatch(Product product) {
            // Return null if product is null
            if (product == null)
            {
                return null;
            }

            switch (product.Type) {
                case "ITEM":
                    return new ItemProduct(product);
                default:
                    return null;
            }
        }
    }
}