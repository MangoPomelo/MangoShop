using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Linq;
using System.Collections.Generic;
using MangoShop.Models;

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
            if (IsGivenCommandInvalid(command)) {
                UnturnedChat.Say(caller, "You must give a correct command");
                return;
            }

            // Select the product and verify if it exists
            var productName = command[0];
            var product = MangoShop.Instance.Configuration.Instance.Products.FirstOrDefault(p => p.Name == productName);
            if (IsGivenProductInvalid(product)) {
                UnturnedChat.Say(caller, "Product not found");
                return;
            }

            // Buy the product
            UnturnedPlayer player = (UnturnedPlayer)caller;
            player.GiveItem(product.ItemId, 1);
            UnturnedChat.Say(caller, $"You received {product.Name}!");

        }
        private bool IsGivenCommandInvalid(string[] command) {
            if (command.Length < 1) {
                return false;
            }
            return true;
        }
        private bool IsGivenProductInvalid(Product product) {
            return product == null;
        }
    }
}