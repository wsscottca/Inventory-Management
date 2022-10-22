using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    /**<summary>
     * Class <c>ModifyPartScreen</c> is a Form used for modifying existing Parts in the Inventory
     * </summary>
     */
    public partial class ModifyPartScreen : Form
    {
        public InhousePart? InhousePart { get; }
        public OutsourcedPart? OutsourcedPart { get; }
        public int OriginalID { get; }

        /**
         * <summary>
         * Method <c>ModifyPartScreen(InhousePart)</c> instantiates the object, initalizes the GUI, saves ID of Part to be modified,
         * and assigns the inputs to the Part's current member values. Constructor for use of ModifyPartScreen with InhousePart.
         * </summary>
         * 
         * <param name="part">InhousePart to Modify</param>
         */
        public ModifyPartScreen(InhousePart part)
        {
            InitializeComponent();
            InhousePart = part;
            InitializeInhouse();
            txtId.Text = part.PartID.ToString();
            txtName.Text = part.Name;
            txtInventory.Text = part.InStock.ToString();
            txtPrice.Text = part.Price.ToString();
            txtMin.Text = part.Min.ToString();
            txtMax.Text = part.Max.ToString();
            txtMachineId.Text = part.MachineID.ToString();
            OriginalID = part.PartID;
        }

        /**
         * <summary>
         * Method <c>ModifyPartScreen(OutsourcedPart)</c> instantiates the object, initalizes the GUI, saves ID of Part to be modified,
         * and assigns the inputs to the Part's current member values. Constructor for use of ModifyPartScreen with OutsourcedPart.
         * </summary>
         * 
         * <param name="part">OutsourcedPart to Modify</param>
         */
        public ModifyPartScreen(OutsourcedPart part)
        {
            InitializeComponent();
            OutsourcedPart = part;
            InitializeOutsourced();
            txtId.Text = part.PartID.ToString();
            txtName.Text = part.Name;
            txtInventory.Text = part.InStock.ToString();
            txtPrice.Text = part.Price.ToString();
            txtMin.Text = part.Min.ToString();
            txtMax.Text = part.Max.ToString();
            txtCompany.Text = part.CompanyName;
            OriginalID = part.PartID;
        }

        /**
         * <summary>
         * Method <c>InializeInhouse</c> adjusts GUI for modifying an InhousePart
         * </summary>
         * 
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void InitializeInhouse()
        {
            radioInHouse.Checked = true;
            lblCompany.Visible = false;
            txtCompany.Visible = false;
            txtCompany.Enabled = false;
            txtCompany.Text = "";

            lblMachineId.Visible = true;
            txtMachineId.Visible = true;
            txtMachineId.Enabled = true;
        }

        /**
         * <summary>
         * Method <c>InializeOutsourced</c> adjusts GUI for modifying an OutsourcedPart
         * </summary>
         * 
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void InitializeOutsourced()
        {
            radioOutsource.Checked = true;
            lblCompany.Visible = true;
            txtCompany.Visible = true;
            txtCompany.Enabled = true;

            lblMachineId.Visible = false;
            txtMachineId.Visible = false;
            txtMachineId.Enabled = false;
            txtMachineId.Text = "";
        }

        /**
         * <summary>
         * Method <c>RadioInHousePart_Checked</c> adjusts GUI based on which radio button is checked
         * </summary>
         * 
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void RadioInHousePart_Checked(object sender, EventArgs e)
        {
            if (radioInHouse.Checked)
            {
                InitializeInhouse();
                if (InhousePart != null)
                {
                    txtMachineId.Text = InhousePart.MachineID.ToString();
                }
            }
            else
            {
                InitializeOutsourced();
                if (OutsourcedPart != null)
                {
                    txtCompany.Text = OutsourcedPart.CompanyName;
                }
            }
        }

        /**
         * <summary>
         * Method <c>BtnSave_Click</c> performs basic input validation then saves the updated Part to Inventory's Parts BindingList
         * </summary>
         * 
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string message;
            string title;
            int inventory;
            int min;
            int max;
            decimal price;

            if (txtName.Text == "" || txtPrice.Text == "" || txtInventory.Text == "" || txtMin.Text == "" || txtMax.Text == "")
            {
                message = "All fields required.";
                title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            else
            {

                try
                {
                    inventory = Convert.ToInt32(txtInventory.Text);
                    min = Convert.ToInt32(txtMin.Text);
                    max = Convert.ToInt32(txtMax.Text);

                }
                catch (FormatException)
                {
                    message = "Inventory, Min, and Max must be integers.";
                    title = "Invalid Input";
                    MessageBox.Show(message, title);
                    return;
                }

                try
                {
                    price = Convert.ToDecimal(txtPrice.Text);
                }
                catch (FormatException)
                {
                    message = "Price must be in decimal format. (Ex. 10.99)";
                    title = "Invalid Input";
                    MessageBox.Show(message, title);
                    return;
                }

                if (min > max)
                {
                    message = "Product Min must be lower than product Max.";
                    title = "Invalid Input";
                    MessageBox.Show(message, title);
                }
                else if (inventory < min || inventory > max)
                {
                    message = "Product Inventory must be between product Min and Max.";
                    title = "Invalid Input";
                    MessageBox.Show(message, title);
                }
                else
                {
                    if (radioInHouse.Checked)
                    {
                        int machineID;
                        try
                        {
                            machineID = Convert.ToInt32(txtMachineId.Text);
                        }
                        catch (FormatException)
                        {
                            message = "Machine ID must be an integer.";
                            title = "Invalid Input";
                            MessageBox.Show(message, title);
                            return;
                        }
                        Inventory.UpdatePart(OriginalID, new InhousePart(OriginalID, name, price, inventory, min, max, machineID));
                    }
                    else
                    {
                        if (txtCompany.Text != "")
                        {
                            Inventory.UpdatePart(OriginalID, new OutsourcedPart(OriginalID, name, price, inventory, min, max, txtCompany.Text));
                        }
                        else
                        {
                            message = "Company name must be entered.";
                            title = "Invalid Input";
                            MessageBox.Show(message, title);
                            return;
                        }
                    }
                    
                    Close();
                }
            }
            
        }

        /**
         * <summary>
         * Method <c>BtnCancel_Click</c> closes the ModifyPartScreen, returning to the MainScreen without saving updates
         * </summary>
         * 
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
