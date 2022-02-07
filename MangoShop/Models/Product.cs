namespace MangoShop.Models
{
    public class Product
    {
        public const string NULL_TYPE = "Null";
        public const string DEFAULT_TYPE = "Default";
        public const string BANNED_TYPE = "Banned";
        public const string ITEM_TYPE = "Item";
        public const string LOTTERY_TYPE = "Lottery";

        public string ProductType { private get; set; }
        public string ProductName { private get; set; }
        public uint BasePrice { private get; set; }

        public Product SetProductType(string newType)
        {
            this.ProductType = newType;
            return this;
        }
        public string GetProductType()
        {
            return this.ProductType;
        }

        public Product SetProductName(string newName)
        {
            this.ProductName = newName;
            return this;
        }
        public string GetProductName()
        {
            return this.ProductName;
        }

        public Product SetBasePrice(uint newBasePrice)
        {
            this.BasePrice = newBasePrice;
            return this;
        }
        public uint GetBasePrice()
        {
            return this.BasePrice;
        }

    }
}