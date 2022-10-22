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
     * Class <c>AddPartScreen</c> is a Form used for adding new Parts into the Inventory
     * </summary>
     */
    public partial class AddPartScreen : Form
    {
        /**
         * <summary>
         * Method <c>AddPartScreen</c> instantiates the object, initalizes the GUI
         * and assigns the next Part ID number
         * </summary>
         */
        public AddPartScreen()
        {
            InitializeComponent();

            txtId.Text = Part.IdCount.ToString();
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
                lblCompany.Visible = false;
                txtCompany.Visible = false;
                txtCompany.Enabled = false;
                txtCompany.Text = "";

                lblMachineId.Visible = true;
                txtMachineId.Visible = true;
                txtMachineId.Enabled = true;
            }
            else
            {
                lblCompany.Visible = true;
                txtCompany.Visible = true;
                txtCompany.Enabled = true;

                lblMachineId.Visible = false;
                txtMachineId.Visible = false;
                txtMachineId.Enabled = false;
                txtMachineId.Text = "";
            }
        }

        /**
         * <summary>
         * Method <c>BtnSave_Click</c> performs basic input validation then adds Part to Inventory's Parts BindingList
         * </summary>
         * 
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string message;
            string title;
            int id = Part.IdCount;
            string name = txtName.Text;
            decimal price;
            int inventory;
            int max;
            int min;
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
                        
                        InhousePart part = new(name, price, inventory, min, max, machineID);
                        Inventory.AddPart(part);
                    }
                    else
                    {
                        string companyName;
                        if (txtCompany.Text != "")
                        {
                            companyName = txtCompany.Text;
                        }
                        else
                        {
                            message = "Please enter company name.";
                            title = "Invalid Input";
                            MessageBox.Show(message, title);
                            return;
                        }
                        OutsourcedPart part = new(name, price, inventory, min, max, companyName);
                        Inventory.AddPart(part);
                    }
                    Close();
                }
            }
        }

        /**
         * <summary>
         * Method <c>BtnCancel_Click</c> closes the AddPartScreen, returning to the MainScreen
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
