namespace MangoShop.Models
{
    public class Product
    {
        public const string NULL_TYPE = "Null";
        public const string DEFAULT_TYPE = "Default";
        public const string BANNED_TYPE = "Banned";
        public const string ITEM_TYPE = "Item";
        public const string LOTTERY_TYPE = "Lottery";

        public string Name { get; set; }
        public uint Price { get; set; }
        public string Type { get; set; }
    }
}