using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    /**<summary>
     * Class <c>Inventory</c> stores all the company's Parts and Products.
     * </summary>
     */
    public class Inventory
    {
        public static BindingList<Product> Products { get; set; }
        public static BindingList<Part> Parts { get; set; }
        static Inventory()
        {
            Products = new BindingList<Product>();
            Parts = new BindingList<Part>();

            InitalizePartsData();
            InitializeProductData();
        }

        /**<summary>
         * Method <c>InitializeProductData</c> puts dummy Products into Inventory.
         * </summary>
         */
        private static void InitializeProductData()
        {
            Products.Add(new Product(new BindingList<Part> { LookupPart(1) }, "Door", 85.52m, 4, 1, 10));
            Products.Add(new Product("Floorboard", 2.99m, 80, 1, 100));
            Products.Add(new Product("Lumber", 8.54m, 1265, 500, 2500));
            Products.Add(new Product("Bicycle", 135.27m, 2, 1, 5));
            Products.Add(new Product("Playset", 4299.99m, 1, 1, 5));
            Products.Add(new Product("Panel", 42.42m, 87, 10, 100));
            Products.Add(new Product("Chest", 80.00m, 8, 5, 20));
        }

        /**<summary>
         * Method <c>InitializePartsData</c> puts dummy Parts into Inventory.
         * </summary>
         */
        private static void InitalizePartsData()
        {
            Parts.Add(new InhousePart("Screw", 0.25m, 5, 5, 100, 4));
            Parts.Add(new InhousePart("Nail", 0.20m, 65, 10, 100, 2));
            Parts.Add(new InhousePart("Washer", 0.05m, 465, 100, 1000, 9));
            Parts.Add(new InhousePart("Nut", 0.25m, 369, 100, 1000, 9));
            Parts.Add(new InhousePart("Bolt", 1.00m, 54, 10, 100, 4));
            Parts.Add(new OutsourcedPart("Wheel", 2.45m, 3, 2, 20, "ABC"));
            Parts.Add(new OutsourcedPart("Hinge", 1.15m, 70, 25, 250, "I MAKE THINGS"));
            Parts.Add(new OutsourcedPart("Bracket", 1.65m, 76, 15, 125, "FACTORY"));
            Parts.Add(new OutsourcedPart("Knob", 3.20m, 3, 3, 30, "MANUFACTURER"));
            Parts.Add(new OutsourcedPart("Switch", 1.85m, 195, 20, 200, "MADE IN CHINA"));
        }

        /**<summary>
         * Method <c>AddProduct</c> adds Product to Inventory.
         * </summary>
         * 
         * <param name="product">Product to add</param>
         */
        public static void AddProduct(Product product) { Products.Add(product); }

        /**<summary>
         * Method <c>RemoveProduct</c> removes Product from Inventory.
         * </summary>
         * 
         * <param name="id">ID of Product to remove</param>
         */
        public static bool RemoveProduct(int id)
        {
            Product p;
            try
            {
                p = LookupProduct(id);
            } catch (KeyNotFoundException)
            {
                throw;
            }
            
            if (!p.HasAssociatedParts())
            {
                Products.Remove(p);
                return true;
            }

            throw new InvalidOperationException();
        }

        /**<summary>
         * Method <c>LookupProduct</c> checks if Product is in Inventory.
         * </summary>
         * 
         * <param name="id">ID of Product to lookup</param>
         */
        public static Product LookupProduct(int id)
        {
            foreach (Product p in Products)
            {
                if (p.ProductID == id)
                {
                    return p;
                }
            }
            throw new KeyNotFoundException();
        }

        /**<summary>
         * Method <c>SearchProduct</c> searches Products in Inventory that contain a specified substring in their name.
         * </summary>
         * 
         * <param name="search">Substring to search</param>
         */
        public static BindingList<Product> SearchProducts(string search)
        {
            BindingList<Product> products = new();
            foreach (Product p in Products)
            {
                if (p.Name.ToLower().Contains(search.ToLower()))
                {
                    products.Add(p);
                }
            }
            if (products.Count > 0)
            {
                return products;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        /**<summary>
         * Method <c>UpdateProduct</c> updates a current Product in the Inventory.
         * </summary>
         * 
         * <param name="id">ID of Product to update</param>
         * <param name="updatedProduct">Updated product holding values</param>
         */
        public static void UpdateProduct(int id, Product updatedProduct)
        {
            try
            {
                Product product = LookupProduct(id);
                product.ProductID = updatedProduct.ProductID;
                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
                product.Max = updatedProduct.Max;
                product.Min = updatedProduct.Min;
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
        }

        /**<summary>
         * Method <c>AddPart</c> adds Partt to Inventory.
         * </summary>
         * 
         * <param name="part">Part to add</param>
         */
        public static void AddPart(Part part) { Parts.Add(part); }

        /**<summary>
         * Method <c>DeletePart</c> removes Part from Inventory.
         * </summary>
         * 
         * <param name="id">ID of Part to remove</param>
         */
        public static bool DeletePart(Part part) { return Parts.Remove(part); }

        /**<summary>
         * Method <c>LookupPart</c> checks if Part is in Inventory.
         * </summary>
         * 
         * <param name="id">ID of Part to lookup</param>
         */
        public static Part LookupPart(int id) 
        { 
            foreach (Part p in Parts)
            {
                if (p.PartID == id)
                {
                    return p;
                }
            }
            throw new KeyNotFoundException();
        }

        /**<summary>
         * Method <c>SearchParts</c> searches Parts in Inventory that contain a specified substring in their name.
         * </summary>
         * 
         * <param name="search">Substring to search</param>
         */
        public static BindingList<Part> SearchParts(string search)
        {
            BindingList<Part> parts = new();
            foreach (Part p in Parts)
            {
                if (p.Name.ToLower().Contains(search.ToLower()))
                {
                    parts.Add(p);
                }
            }

            if (parts.Count > 0)
            {
                return parts;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        /**<summary>
         * Method <c>UpdatePart</c> updates a current Part in the Inventory.
         * </summary>
         * 
         * <param name="id">ID of Part to update</param>
         * <param name="updatedPart">Updated Part</param>
         */
        public static void UpdatePart(int id, Part updatedPart)
        {
            Parts.Remove(LookupPart(id));
            Parts.Add(updatedPart);
        }
    }
}
