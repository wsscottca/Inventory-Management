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
     * Class <c>AddProductScreen</c> is a Form used for adding new Products into the Inventory
     * </summary>
     */
    public partial class AddProductScreen : Form
    {
        private readonly Product Product;
        private readonly BindingList<Part> CandidateParts;

        /**
         * <summary>
         * Method <c>AddProductScreen</c> instantiates the object, initalizes the GUI
         * and assigns Inventory Parts to the candidate Parts DataGridView
         * </summary>
         */
        public AddProductScreen()
        {
            InitializeComponent();

            Product = new();
            txtId.Text = Product.IdCount.ToString();

            BindingList<Part> associatedParts = Product.AssociatedParts;
            CandidateParts = new();
            foreach (Part part in Inventory.Parts)
            {
                if (!associatedParts.Contains(part))
                {
                    CandidateParts.Add(part);
                }
            }

            BindingSource bsCandParts = new() { DataSource = CandidateParts };
            dgvCandParts.DataSource = bsCandParts;

            BindingSource bsAssocParts = new() { DataSource = Product.AssociatedParts };
            dgvAssocParts.DataSource = bsAssocParts;
        }

        /**
         * <summary>
         * Method <c>BtnRefresh_Click</c> resets the candidate Parts DataGridView after a search was run
         * </summary>
         * 
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            BindingSource bsCandParts = new() { DataSource = CandidateParts };
            dgvCandParts.DataSource = bsCandParts;
        }

        /**
         * <summary>
         * Method <c>BtnSearch_Click</c> searches candidate Parts BindingList for Parts whose name contains the string
         * supplied in <c>txtSearch</c> TextBox
         * </summary>
         * 
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (!(txtSearch.Text.Length > 0)) return;

            txtSearch.Text = txtSearch.Text.Trim();
            try
            {
                BindingList<Part> foundParts = Inventory.SearchParts(txtSearch.Text);
                foreach (Part part in foundParts)
                {
                    if (!CandidateParts.Contains(part))
                    {
                        foundParts.Remove(part);
                    }
                }
                BindingSource bsPart = new() { DataSource = foundParts };
                dgvCandParts.DataSource = bsPart;
            }
            catch (KeyNotFoundException)
            {
                string message = "No parts found containing \'" + txtSearch.Text + "\'.";
                string title = "No Results";
                MessageBox.Show(message, title);
            }
        }

        /**
         * <summary>
         * Method <c>BtnAdd_Click</c> moves selected Part from candidate Parts BindingList to Product's associated Parts BindingList
         * </summary>
         * 
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Part part = Inventory.LookupPart(Convert.ToInt32(dgvCandParts.SelectedRows[0].Cells[0].Value.ToString()));
            Product.AddAssociatedPart(part);
            CandidateParts.Remove(part);
            dgvAssocParts.Update();
        }

        /**
         * <summary>
         * Method <c>BtnDelete_Click</c> moves selected Part from Product's associated Parts BindingList to candidate Parts BindingList 
         * </summary>
         * 
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int idOfSelected = Convert.ToInt32(dgvAssocParts.SelectedRows[0].Cells[0].Value.ToString());
            Product.RemoveAssociatedPart(idOfSelected);

            Part part = Inventory.LookupPart(idOfSelected);
            CandidateParts.Add(part);
        }

        /**
         * <summary>
         * Method <c>BtnSave_Click</c> performs basic input validation then adds Product to Inventory's Products BindingList
         * </summary>
         * 
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Product.Name = txtName.Text;
            Product.ProductID = Convert.ToInt32(txtId.Text);
            Product.IdCount++;
            string message;
            string title;

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
                    Product.InStock = Convert.ToInt32(txtInventory.Text);
                    Product.Min = Convert.ToInt32(txtMin.Text);
                    Product.Max = Convert.ToInt32(txtMax.Text);

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
                    Product.Price = Convert.ToDecimal(txtPrice.Text);
                }
                catch (FormatException)
                {
                    message = "Price must be in decimal format. (Ex. 10.99)";
                    title = "Invalid Input";
                    MessageBox.Show(message, title);
                    return;
                }

                if (Product.Min > Product.Max)
                {
                    message = "Product Min must be lower than product Max.";
                    title = "Invalid Input";
                    MessageBox.Show(message, title);
                }
                else if (Product.InStock < Product.Min || Product.InStock > Product.Max)
                {
                    message = "Product Inventory must be between product Min and Max.";
                    title = "Invalid Input";
                    MessageBox.Show(message, title);
                }
                else
                {
                    Inventory.AddProduct(Product);
                    Close();
                }
            }
        }

        /**
         * <summary>
         * Method <c>BtnCancel_Click</c> closes the AddProductScreen, returning to the MainScreen
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
