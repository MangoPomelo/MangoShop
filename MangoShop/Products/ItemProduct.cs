using System;
using System.Collections.Generic;
using SDG.Unturned;
using Rocket.Unturned.Player;
using MangoShop.Models;

namespace MangoShop.Products
{
    public class ItemProduct : Product
    {
        public ItemProduct(MetaProduct product) : base(product) {}

        public override Product PurchasedBy(UnturnedPlayer player, byte amount)
        {
            // Check if the player has sufficient money
            uint totalCost = amount * this.GetPurchasedPrice();
            if (player.Experience < totalCost) {
                throw new InvalidOperationException("Player does not have enough money");
            }

            // Effect on the player
            ushort itemId = this._mapNameToItemId(this.GetProductName());
            player.GiveItem(itemId, amount);

            // Payment
            player.Experience -= totalCost;

            return this;
        }

        public override Product SoldBy(UnturnedPlayer player, byte amount)
        {
            // Check if the player has sufficient items
            ushort itemId = this._mapNameToItemId(this.GetProductName());
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

            return this;
        }

        private ushort _mapNameToItemId(string name)
        {
            try 
            {
                return Convert.ToUInt16(name);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Cannot map the product name to item id");
            }
        }
    }
}