using Rocket.Core.Plugins;
using Rocket.Core.Logging;

namespace MangoShop
{
    public class MangoShop : RocketPlugin<MangoShopConfiguration>
    {
        public static MangoShop Instance { get; private set; }
        protected override void Load()
        {
            Logger.Log(Configuration.Instance.LoadMessage);
            Logger.Log($"{Name} {Assembly.GetName().Version} has been loaded!");
        }

        protected override void Unload()
        {
            Logger.Log($"{Name} has been unloaded!");
        }
    }
}