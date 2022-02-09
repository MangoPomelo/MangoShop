namespace MangoShop.Models
{
    public class MetaProduct
    {
        public const string NULL_TYPE = "Null";
        public const string UNKNOWN_TYPE = "Unknown";
        public const string BANNED_TYPE = "Banned";
        public const string ITEM_TYPE = "Item";
        public const string VEHICLE_TYPE = "Vehicle";
        public const string LOTTERY_TYPE = "Lottery";
        public const string HELP_TYPE = "Help";

        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public uint BasePrice { get; set; }
        public double DepreciationRate { get; set; }
        public double Elasticity { get; set; }

        public MetaProduct SetProductType(string newType)
        {
            this.ProductType = newType;
            return this;
        }
        public string GetProductType()
        {
            return this.ProductType;
        }

        public MetaProduct SetProductName(string newName)
        {
            this.ProductName = newName;
            return this;
        }
        public string GetProductName()
        {
            return this.ProductName;
        }

        public MetaProduct SetBasePrice(uint newBasePrice)
        {
            this.BasePrice = newBasePrice;
            return this;
        }
        public uint GetBasePrice()
        {
            return this.BasePrice;
        }

        public MetaProduct SetDepreciationRate(double newDepreciationRate)
        {
            this.DepreciationRate = newDepreciationRate;
            return this;
        }
        public double GetDepreciationRate()
        {
            return this.DepreciationRate;
        }

        public MetaProduct SetElasticity(double newElasticity)
        {
            this.Elasticity = newElasticity;
            return this;
        }
        public double GetElasticity()
        {
            return this.Elasticity;
        }
    }
}