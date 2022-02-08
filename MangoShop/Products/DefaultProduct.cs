using System;
using System.Collections.Generic;
using SDG.Unturned;
using Rocket.Unturned.Player;
using MangoShop.Models;

namespace MangoShop.Products
{
    public class DefaultProduct : Product
    {
        public DefaultProduct(MetaProduct product) : base(product) {}

        public override Product PurchasedBy(UnturnedPlayer player, byte amount)
        {
            // Check if the player has sufficient money
            uint totalCost = amount * this.GetPurchasePrice();
            if (player.Experience < totalCost) {
                throw new InvalidOperationException("Player does not have enough money");
            }

            // Effect on the player
            ushort itemId = this._convertNameToItemId(this.GetProductName());
            player.GiveItem(itemId, amount);

            // Payment
            player.Experience -= totalCost;

            // Increase scarcity
            this.SetScarcity(this.GetScarcity() + amount);

            return this;
        }

        public override Product SoldBy(UnturnedPlayer player, byte amount)
        {
            // Check if the player has sufficient items
            ushort itemId = this._convertNameToItemId(this.GetProductName());
            uint totalGain = amount * this.GetSellingPrice();
            List<InventorySearch> list = player.Inventory.search(itemId, true, true);
            if (list.Count < amount)
            {
                throw new InvalidOperationException("Player does not have enough items");
            }

            // Effect on the player
            for (int n = 0; n < amount; n++) {
                player.Inventory.removeItem(list[0].page, player.Inventory.getIndex(list[0].page, list[0].jar.x, list[0].jar.y));
                list.RemoveAt(0);
            }

            // Payment
            player.Experience += totalGain;

            // Decrease scarcity
            this.SetScarcity(this.GetScarcity() - amount);

            return this;
        }

        private ushort _convertNameToItemId(string name)
        {
            try
            {
                return Convert.ToUInt16(name);
            }
            catch (FormatException)
            {
                throw new InvalidOperationException("Cannot convert the product name to item id");
            }
        }
    }
}