using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Linq;
using System.Collections.Generic;
using MangoShop.Models;
using MangoShop.Utilities;
using MangoShop.Decoraters;

namespace MangoShop.Commands
{
    public class BuyCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "buy";
        public string Help => "";
        public string Syntax => "<buy>";
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            // Verify if the given command is valid, prompt an hint if not
            Argument argument = new Argument("", 1);
            try
            {
                argument = argument.Parse(command);
            }
            catch (Exception)
            {
                UnturnedChat.Say(caller, MangoShop.Instance.Translate("CommandInvalid"), MangoShop.Instance.MessageColor);
                return;
            }

            // Select the product and verify if it exists
            string productName = argument.Name;
            Product product = new Product(){ ProductType = Product.NULL_TYPE, ProductName = Product.NULL_TYPE, BasePrice = 0 };
            try
            {
                product = MangoShop.Instance.Configuration.Instance.OnSaleProducts.First(p => p.GetProductName() == productName);;
            }
            catch (Exception)
            {
                product = MangoShop.Instance.Configuration.Instance.DefaultProduct;
                product.SetProductName(productName);
            }

            // Decorate the product
            DecoratedProduct decoratedProduct = Dispatcher.dispatch(product);

            // Buy the product
            UnturnedPlayer player = (UnturnedPlayer)caller;
            byte amount = argument.Amount;
            try
            {
                decoratedProduct.PurchasedBy(player, amount);
                UnturnedChat.Say(caller, MangoShop.Instance.Translate("PurchaseSucceed", $"{product.GetProductName()} x {amount}"), MangoShop.Instance.MessageColor);
            }
            catch (Exception)
            {
                UnturnedChat.Say(caller, MangoShop.Instance.Translate("PurchaseFailed"), MangoShop.Instance.MessageColor);
                return;
            }
        }
    }
}