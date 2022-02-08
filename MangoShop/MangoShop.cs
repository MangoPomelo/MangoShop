using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;

namespace MangoShop
{
    public class MangoShop : RocketPlugin<MangoShopConfiguration>
    {
        public static MangoShop Instance { get; private set; }

        public UnityEngine.Color MessageColor { get; private set; }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            // Command
            { "CommandInvalid", "You must specify product name!" },
            // Product name matching
            { "ProductNotFound", "Product not found!" },
            // BuyCommand
            { "PurchaseSucceed", "You received {0}!" },
            { "PurchaseFailed", "You don't have enough xp or the product is banned!" },
            // SellCommand
            { "SellingSucceed", "You received {0} xp!" },
            { "SellingFailed", "You don't have enough items or the product cannot be sold!" },
            // EvalCommand
            { "EvaluationSucceed", "Product costs {0} xp!" },
            { "EvaluationFailed", "Product cannot be evaluated!" }
        };

        protected override void Load()
        {
            Instance = this;

            MessageColor = UnturnedChat.GetColorFromName(Configuration.Instance.MessageColor, UnityEngine.Color.green);

            Logger.Log(Configuration.Instance.LoadMessage);
            Logger.Log($"{Name} {Assembly.GetName().Version} has been loaded!");
        }

        protected override void Unload()
        {
            StopAllCoroutines();

            Logger.Log($"{Name} has been unloaded!");
        }
    }
}