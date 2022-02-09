using System;
using System.Linq;
using System.Collections.Generic;
using SDG.Unturned;
using Rocket.Unturned.Player;
using MangoShop.Models;
using MangoShop.Utilities;

namespace MangoShop.Products
{
    public class VehicleProduct : Product
    {
        public static bool DoesMetaProductFit(MetaProduct metaProduct)
        {
            // Product type must be either MetaProduct.VEHICLE_TYPE or MetaProduct.UNKNOWN_TYPE
            string productType = metaProduct.GetProductType();
            if (productType != MetaProduct.VEHICLE_TYPE && productType != MetaProduct.UNKNOWN_TYPE)
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

            // Prefix must be "v"
            if (prefix != "v")
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
            if (!VehicleProduct.DoesMetaProductFit(metaProduct))
            {
                throw new InvalidOperationException("Wrong meta product has been provided");
            }
            return new VehicleProduct(metaProduct);
        }

        private VehicleProduct(MetaProduct meta) : base(meta) {}

        public override Message PurchasedBy(UnturnedPlayer player, byte amount)
        {
            // Check if the player has sufficient money
            uint totalCost = amount * this.GetPurchasePrice();
            if (player.Experience < totalCost) {
                throw new InvalidOperationException("Player does not have enough money");
            }

            // Effect on the player
            ushort vehicleId = this._mapProductNameToVehicleId(this.GetProductName());
            for (int n = 0; n < amount; n++) {
                player.GiveVehicle(vehicleId);
            }

            // Payment
            player.Experience -= totalCost;

            // Increase scarcity
            this.IncreaseScarcity(amount);

            return new Message($"{this.GetProductName()} x {amount}");
        }

        public override Message SoldBy(UnturnedPlayer player, byte amount)
        {

            // Check if the player owning the vehicle
            InteractableVehicle vehicle = player.CurrentVehicle;
            if (vehicle == null) 
            {
                throw new NullReferenceException("Vehicle is not found");
            }
            ushort vehicleId = this._mapProductNameToVehicleId(this.GetProductName());
            if (vehicle.isLocked && vehicle.lockedOwner != player.CSteamID)
            {
                throw new InvalidOperationException("Player does not own the vehicle");
            }

            // Check if the amount is 1 and vehicleId equals vehicle.id
            if (amount != 1 || vehicleId != vehicle.id)
            {
                throw new InvalidOperationException("Given argument is wrong");
            }

            // Effect on the player (Remove the driving vehicle)
            VehicleManager.askVehicleDestroy(vehicle);

            // Payment
            uint totalGain = amount * this.GetSellingPrice();
            player.Experience += totalGain;

            // Decrease scarcity
            this.DecreaseScarcity(amount);

            return new Message($"+{totalGain} xp");
        }

        private ushort _mapProductNameToVehicleId(string productName)
        {
            string suffix = productName.Split('.')[1];
            return Convert.ToUInt16(suffix);
        }

        public override Message CheckedBy(UnturnedPlayer player, byte amount)
        {
            return new Message($"{amount * this.GetPurchasePrice()} xp");
        }
    }
}