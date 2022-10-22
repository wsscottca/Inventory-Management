using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    /**<summary>
     * Class <c>InhousePart</c> inheirits from abstract Part used for Parts imported by the company.
     * </summary>
     */
    public class OutsourcedPart : Part
    {
        public string CompanyName { get; set; }
        public OutsourcedPart()
        {
            PartID = -1;
            Name = "";
            Price = -1;
            InStock = -1;
            Min = -1;
            Max = -1;
            CompanyName = "";
        }
        public OutsourcedPart(string name, decimal price, int inStock, int min, int max, string companyName)
        {
            PartID = IdCount;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
            CompanyName = companyName;

            IdCount++;
        }
        public OutsourcedPart(int partID, string name, decimal price, int inStock, int min, int max, string companyName)
        {
            PartID = partID;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
            CompanyName = companyName;

            IdCount++;
        }
    }
}
