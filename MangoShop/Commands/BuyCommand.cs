﻿using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Linq;
using System.Collections.Generic;
using MangoShop.Models;
using MangoShop.Utilities;
using MangoShop.Products;

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
            catch (FormatException)
            {
                UnturnedChat.Say(caller, MangoShop.Instance.Translate("CommandInvalid"), MangoShop.Instance.MessageColor);
                return;
            }

            // Select the product and verify if it exists
            string productName = argument.Name;
            MetaProduct metaProduct = new MetaProduct(){ ProductType = MetaProduct.NULL_TYPE, ProductName = MetaProduct.NULL_TYPE, BasePrice = 0, DepreciationRate = 1.0, Elasticity = 0 };
            try
            {
                metaProduct = MangoShop.Instance.Configuration.Instance.OnSaleProducts.First(p => p.GetProductName() == productName);;
            }
            catch (InvalidOperationException)
            {
                metaProduct = new MetaProduct(){ ProductType = MetaProduct.UNKNOWN_TYPE, ProductName = productName, BasePrice = 0, DepreciationRate = 1.0, Elasticity = 0 };
            }

            // Generate the product
            Product product = Dispatcher.dispatch(metaProduct);

            // Buy the product
            UnturnedPlayer player = (UnturnedPlayer)caller;
            byte amount = argument.Amount;
            try
            {
                product.PurchasedBy(player, amount);
                UnturnedChat.Say(caller, MangoShop.Instance.Translate("PurchaseSucceed", $"{product.GetProductName()} x {amount}"), MangoShop.Instance.MessageColor);
            }
            catch (InvalidOperationException)
            {
                UnturnedChat.Say(caller, MangoShop.Instance.Translate("PurchaseFailed"), MangoShop.Instance.MessageColor);
                return;
            }
            catch (NullReferenceException)
            {
                UnturnedChat.Say(caller, MangoShop.Instance.Translate("ProductNotFound"), MangoShop.Instance.MessageColor);
                return;
            }
        }
    }
}