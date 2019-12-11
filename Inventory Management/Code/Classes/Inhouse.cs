namespace InventorySystem_PeterWilliams
{
    public class Inhouse : Part
    {
        public int MachineID { get; set; }

        public Inhouse(string name, decimal price, int instock, int min, int max, int machID)
        {
            Name = name;
            Price = price;
            InStock = instock;
            Min = min;
            Max = max;
            MachineID = machID;
        }
    }
}
