using Rocket.Unturned.Player;
using MangoShop.Models;

namespace MangoShop.Decoraters
{
    public class ItemProduct : DecoratedProduct
    {
        public ItemProduct(Product product) : base(product) {}
        public override bool PurchasedBy(UnturnedPlayer player, byte amount)
        {
            uint totalCost = amount * this.Price;
            if (player.Experience < totalCost) {
                return false;
            }
            player.GiveItem(this.ID, amount);
            player.Experience -= totalCost;
            return true;
        }
    }
}