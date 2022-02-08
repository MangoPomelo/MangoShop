using System;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using MangoShop.Models;

namespace MangoShop.Products
{
    public class LotteryProduct : Product
    {
        public LotteryProduct(MetaProduct product) : base(product) {}

        public override Product PurchasedBy(UnturnedPlayer player, byte amount)
        {
            // Check if the player has sufficient money
            uint totalCost = amount * this.GetPurchasedPrice();
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
                UnturnedChat.Say($"{player.CharacterName} won {prize}! Congratulations!");
            }

            return this;
        }

        private uint _generatePrice(byte amount)
        {
            uint prize = 0; // Default prize
            uint roundPrize = this.GetPurchasedPrice(); // Amount of experience gaining if bingo on each round
            double probability = 0.6; // Chance of winning prize
            for (int i = 0; i < amount; i++) {
                prize += this._bingo(probability) ? roundPrize : 0;
            }
            return prize;
        }

        private bool _bingo(double probability)
        {
            Random random = new System.Random();
            return random.NextDouble() <= probability;
        }

        public override Product SoldBy(UnturnedPlayer player, byte amount)
        {
            throw new InvalidOperationException("Lottery cannot be sold");
        }
    }
}