using System;
using System.Collections.Generic;
using SDG.Unturned;
using Rocket.Unturned.Player;
using MangoShop.Models;

namespace MangoShop.Decoraters
{
    public class DefaultProduct : DecoratedProduct
    {
        public DefaultProduct(Product product) : base(product) {}

        public override DecoratedProduct PurchasedBy(UnturnedPlayer player, byte amount)
        {
            // Check if the player has sufficient money
            uint totalCost = amount * this.Price;
            if (player.Experience < totalCost) {
                throw new InvalidOperationException("Player does not have enough money");
            }

            // Effect on the player
            ushort itemId = this._convertNameToItemId(this.Name);
            player.GiveItem(itemId, amount);

            // Payment
            player.Experience -= totalCost;

            return this;
        }

        public override DecoratedProduct SoldBy(UnturnedPlayer player, byte amount)
        {
            // Check if the player has sufficient items
            ushort itemId = this._convertNameToItemId(this.Name);
            uint totalGain = amount * this.Price;
            List<InventorySearch> list = player.Inventory.search(itemId, true, true);
            if (list.Count < amount)
            {
                throw new InvalidOperationException("Player does not have enough items");
            }

            // Effect on the player
            while (list.Count > 0) {
                player.Inventory.removeItem(list[0].page, player.Inventory.getIndex(list[0].page, list[0].jar.x, list[0].jar.y));
                list.RemoveAt(0);
            }

            // Payment
            player.Experience += totalGain;

            return this;
        }

        private ushort _convertNameToItemId(string name)
        {
            try
            {
                return Convert.ToUInt16(name);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Cannot convert the product name to item id");
            }
        }
    }
}