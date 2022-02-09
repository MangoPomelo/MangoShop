using System;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using MangoShop.Models;

namespace MangoShop.Products
{
    public class LotteryProduct : Product
    {
        public static bool DoesMetaProductFit(MetaProduct metaProduct)
        {
            // Product type must be either MetaProduct.LOTTERY_TYPE or MetaProduct.UNKNOWN_TYPE
            string productType = metaProduct.GetProductType();
            if (productType != MetaProduct.LOTTERY_TYPE && productType != MetaProduct.UNKNOWN_TYPE)
            {
                return false;
            }

            // Product name must be strictly "lottery"
            string productName = metaProduct.GetProductName();
            if (productName != "lottery")
            {
                return false;
            }

            return true;
        }
        public static Product CreateProduct(MetaProduct metaProduct)
        {
            if (!LotteryProduct.DoesMetaProductFit(metaProduct))
            {
                throw new InvalidOperationException("Wrong meta product has been provided");
            }
            return new LotteryProduct(metaProduct);
        }

        private Random _randomGenerator = new Random();
        private LotteryProduct(MetaProduct meta) : base(meta) {}

        public override void PurchasedBy(UnturnedPlayer player, byte amount)
        {
            // Check if the player has sufficient money
            uint totalCost = amount * this.GetPurchasePrice();
            if (player.Experience < totalCost) {
                throw new InvalidOperationException("Player does not have enough money");
            }

            // Effect on the player
            uint prize = this._generatePrice(amount);
            player.Experience += prize;

            // Payment
            player.Experience -= totalCost;

            // Congratulate the winner
            if (prize > 0) {
                UnturnedChat.Say($"{player.CharacterName} won {prize} xp! Congratulations!");
            }
        }

        private uint _generatePrice(byte amount)
        {
            uint prize = 0; // Default prize
            uint roundPrize = 2 * this.GetPurchasePrice(); // Amount of experience gaining if bingo on each round (Double purchase price)
            double probability = 0.6; // Chance of winning prize
            for (int i = 0; i < amount; i++) {
                prize += this._bingo(probability) ? roundPrize : 0;
            }
            return prize;
        }

        private bool _bingo(double probability)
        {
            double randomNumber = this._randomGenerator.NextDouble();
            return randomNumber <= probability;
        }

        public override void SoldBy(UnturnedPlayer player, byte amount)
        {
            throw new InvalidOperationException("Lottery cannot be sold");
        }
    }
}