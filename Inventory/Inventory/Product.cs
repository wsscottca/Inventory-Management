using System.ComponentModel;

namespace Inventory
{
    /**<summary>
     * Class <c>Product</c> is used for all Products in the company Inventory, Products can have associated Parts.
     * </summary>
     */
    public class Product
    {
        public BindingList<Part> AssociatedParts { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public static int IdCount { get; set; } = 1;

        public Product()
        {
            AssociatedParts = new BindingList<Part>();
            ProductID = -1;
            Name = "";
            Price = -1;
            InStock = -1;
            Min = -1;
            Max = -1;
        }

        public Product(string name, decimal price, int inStock, int min, int max)
        {
            AssociatedParts = new BindingList<Part>();
            ProductID = IdCount;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;

            IdCount++;
        }

        public Product(BindingList<Part> associatedParts, string name, decimal price, int inStock, int min, int max)
        {
            AssociatedParts = associatedParts;
            ProductID = IdCount;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;

            IdCount++;
        }

        /**<summary>
         * Method <c>AddAssociatedPart</c> adds Part to Product's associated Parts BindingList
         * </summary>
         * 
         * <param name="part">Part to be added</param>
         */
        public void AddAssociatedPart(Part part) { AssociatedParts.Add(part); }

        /**<summary>
         * Method <c>RemoveAssociatedPart</c> removes Part from Product's associated Parts BindingList
         * catches KeyNotFoundException and returns false if Part is not in Product's associated Parts BindingList
         * </summary>
         * 
         * <param name="id">ID of Part to be removed</param>
         */
        public bool RemoveAssociatedPart(int id)
        {
            try 
            {
                AssociatedParts.Remove(LookupAssoicatedPart(id));
                return true;
            } 
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        /**<summary>
         * Method <c>LookupAssociatedPart</c> checks if Product has Part with specified ID in Product's associated Parts BindingList
         * </summary>
         * 
         * <param name="id">ID of Part to be removed</param>
         * <exception cref="KeyNotFoundException">Throws KeyNotFoundException if the Part is not found</exception>
         */
        public Part LookupAssoicatedPart(int id)
        {
            foreach (Part p in AssociatedParts)
            {
                if (p.PartID == id)
                {
                    return p;
                }
            }
            throw new KeyNotFoundException();
        }

        /**<summary>
         * Method <c>HasAssociatedParts</c> checks if Product has any Parts in Product's associated Parts BindingList
         * </summary>
         */
        public bool HasAssociatedParts()
        {
            return AssociatedParts.Count > 0;
        }
    }
}