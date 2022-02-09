using System;
using System.Linq;
using System.Collections.Generic;
using SDG.Unturned;
using Rocket.Unturned.Player;
using MangoShop.Models;
using Rocket.Unturned.Chat;

namespace MangoShop.Products
{
    public class ItemProduct : Product
    {
        public static bool DoesMetaProductFit(MetaProduct metaProduct)
        {
            // Product type must be either MetaProduct.ITEM_TYPE or MetaProduct.UNKNOWN_TYPE
            string productType = metaProduct.GetProductType();
            if (productType != MetaProduct.ITEM_TYPE && productType != MetaProduct.UNKNOWN_TYPE)
            {
                return false;
            }

            // Product name must be strictly splitted into two parts
            string[] splitted = metaProduct.GetProductName().Split('.');
            if (splitted.Length != 2)
            {
                return false;
            }

            string prefix = splitted[0];
            string suffix = splitted[1];

            // Prefix must be "i"
            if (prefix != "i")
            {
                return false;
            }
            // Suffix must be an interger
            if (!(suffix != "" && suffix.All(char.IsDigit)))
            {
                return false;
            }

            return true;
        }
        public static Product CreateProduct(MetaProduct metaProduct)
        {
            if (!ItemProduct.DoesMetaProductFit(metaProduct))
            {
                throw new InvalidOperationException("Wrong meta product has been provided");
            }
            return new ItemProduct(metaProduct);
        }

        private ItemProduct(MetaProduct meta) : base(meta) {}

        public override void PurchasedBy(UnturnedPlayer player, byte amount)
        {
            // Check if the player has sufficient money
            uint totalCost = amount * this.GetPurchasePrice();
            if (player.Experience < totalCost) {
                throw new InvalidOperationException("Player does not have enough money");
            }

            // Effect on the player
            ushort itemId = this._mapProductNameToItemId(this.GetProductName());
            player.GiveItem(itemId, amount);

            // Payment
            player.Experience -= totalCost;

            // Increase scarcity
            this.IncreaseScarcity(amount);
        }

        public override void SoldBy(UnturnedPlayer player, byte amount)
        {
            // Check if the player has sufficient items
            ushort itemId = this._mapProductNameToItemId(this.GetProductName());
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
            this.DecreaseScarcity(amount);
        }

        private ushort _mapProductNameToItemId(string productName)
        {
            string suffix = productName.Split('.')[1];
            return Convert.ToUInt16(suffix);
        }
    }
}