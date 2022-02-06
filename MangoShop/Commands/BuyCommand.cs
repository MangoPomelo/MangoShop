using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Linq;
using System.Collections.Generic;
using MangoShop.Models;
using MangoShop.Utilities;

namespace MangoShop.Commands
{
    public class BuyCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "buy";
        public string Help => "";
        public string Syntax => "<name>";
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string>();
        public void Execute(IRocketPlayer caller, string[] command)
        {
            // Verify if the given command is valid, prompt an hint if not
            Argument argument = this._tryParseCommand(command);
            if (argument == null) {
                UnturnedChat.Say(caller, "Given command is invalid!");
                return;
            }

            // DEBUG:
            if (MangoShop.Instance == null) {
                UnturnedChat.Say(caller, "MangoShop.Instance is null");
            } else if (MangoShop.Instance.Configuration == null) {
                UnturnedChat.Say(caller, "MangoShop.Instance.Configuration is null");
            }

            // Select the product and verify if it exists
            Product product = this._tryFindProduct(argument.GetID());
            if (product == null) {
                UnturnedChat.Say(caller, "Product not found");
                return;
            }

            // Buy the product
            UnturnedPlayer player = (UnturnedPlayer)caller;
            player.GiveItem(product.ID, argument.GetAmount());
            UnturnedChat.Say(caller, $"You received {product.ID}!");

        }
        private Argument _tryParseCommand(string[] command) {
            try {
                Argument argument = new Argument(command);
                return argument;
            } catch (ArgumentException) {
                return null;
            }
        }
        private Product _tryFindProduct(ushort productID) {
            try {
                Product found = MangoShop.Instance.Configuration.Instance.Products.First(p => p.ID == productID);
                return found;
            } catch (ArgumentNullException) {
                return null;
            }
        }
    }
}