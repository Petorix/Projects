using System.ComponentModel;

namespace InventorySystem_PeterWilliams
{
    class Inventory
    {
        public BindingList<Product> Products = new BindingList<Product>();
        public BindingList<Part> Parts = new BindingList<Part>();

        public void addProduct(Product product)
        {
            Products.Add(product);
        }

        public bool removeProduct(int remove)
        {
            try
            {
                Products.Remove(Products[remove]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Product lookupProduct(int index)
        {
            return Products[index];
        }

        public void updateProduct(int index, Product product)
        {
            Products[index] = product;
        }

        public void addPart(Part part)
        {
            Parts.Add(part);
        }

        public bool deletePart(Part part)
        {
            try
            {
                Parts.Remove(part);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Part lookupPart(int index)
        {
            return Parts[index];
        }

        public void updatePart(int index, Part part)
        {
            Parts[index] = part;
        }
    }
}
