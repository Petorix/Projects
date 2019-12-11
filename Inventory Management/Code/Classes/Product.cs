using System.ComponentModel;

namespace InventorySystem_PeterWilliams
{
    public class Product
    {
        public BindingList<Part> AssociatedParts = new BindingList<Part>();
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public void addAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }

        public bool removeAssociatedPart(int index)
        {
            try
            {
                AssociatedParts.Remove(AssociatedParts[index]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Part lookupAssociatedPart(int index)
        {
            return AssociatedParts[index];
        }

        public void UpdateProduct(string name, decimal price, int inv, int min, int max)
        {
            Name = name;
            Price = price;
            InStock = inv;
            Min = min;
            Max = max;
        }
    }
}
