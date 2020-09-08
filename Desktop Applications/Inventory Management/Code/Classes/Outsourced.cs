namespace InventorySystem_PeterWilliams
{
    public class Outsourced : Part
    {
        public string CompanyName { get; set; }

        public Outsourced(string name, decimal price, int instock, int min, int max, string compName)
        {
            Name = name;
            Price = price;
            InStock = instock;
            Min = min;
            Max = max;
            CompanyName = compName;
        }
    }
}
