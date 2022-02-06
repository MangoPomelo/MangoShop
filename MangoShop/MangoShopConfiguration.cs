using Rocket.API;

namespace MangoShop
{
    public class MangoShopConfiguration : IRocketPluginConfiguration
    {
        public string LoadMessage { get; set; }
        public void LoadDefaults()
        {
            LoadMessage = "This is mango shop plugin!";
        }
    }
}