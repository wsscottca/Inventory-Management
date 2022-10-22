namespace Inventory
{
    /**<summary>
     * Class <c>Part</c> is an abstract class for Parts to be built upon.
     * </summary>
     */
    abstract public class Part
    {
        public int PartID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public static int IdCount { get; set; } = 1;
    }
}