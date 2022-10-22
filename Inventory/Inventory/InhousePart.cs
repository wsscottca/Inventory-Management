using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    /**<summary>
     * Class <c>InhousePart</c> inheirits from abstract Part used for Parts made by the company
     * </summary>
     */
    public class InhousePart : Part
    {
        public int MachineID { get; set; }
        public InhousePart()
        {
            PartID = -1;
            Name = "";
            Price = -1;
            InStock = -1;
            Min = -1;
            Max = -1;
            MachineID = -1;
        }
        public InhousePart(string name, decimal price, int inStock, int min, int max, int machineID)
        {
            PartID = IdCount;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
            MachineID = machineID;

            IdCount++;
        }
        public InhousePart(int partID, string name, decimal price, int inStock, int min, int max, int machineID)
        {
            PartID = partID;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
            MachineID = machineID;

            IdCount++;
        }
    }
}
