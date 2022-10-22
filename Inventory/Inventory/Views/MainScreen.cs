using System.ComponentModel;

namespace Inventory
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            InitializeDataViews();
        }
        
        /**
         * <summary>
         * Method <c>InitializeDataViews</c> configures the datasources of the DataGridViews to the Inventory's
         * respective BindingLists
         * </summary>
         */
        private void InitializeDataViews()
        {
            BindingSource bsPart = new() { DataSource = Inventory.Parts };
            dgvParts.DataSource = bsPart;

            BindingSource bsProduct = new() { DataSource = Inventory.Products };
            dgvProducts.DataSource = bsProduct;
        }

        /**
         * <summary>
         * Method <c>BtnRefreshParts_Click</c> resets the Parts DataGridView to refresh after a search
         * </summary>
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnRefreshParts_Click(object sender, EventArgs e)
        {
            BindingSource bsPart = new() { DataSource = Inventory.Parts };
            dgvParts.DataSource = bsPart;
        }

        /**
         * <summary>
         * Method <c>BtnRefreshProducts_Click</c> resets the Products DataGridView to refresh after a search
         * </summary>
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnRefreshProducts_Click(object sender, EventArgs e)
        {
            BindingSource bsProduct = new() { DataSource = Inventory.Products };
            dgvProducts.DataSource = bsProduct;
        }

        /**
         * <summary>
         * Method <c>BtnSearchParts_Click</c> updates the Parts DataGridView to Parts containing the
         * text found in the <c>txtSearchParts</c> TextBox
         * </summary>
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnSearchParts_Click(object sender, EventArgs e)
        {
            if (!(txtSearchParts.Text.Length > 0)) return;
            
            txtSearchParts.Text = txtSearchParts.Text.Trim();
            try
            {
                BindingList<Part> foundParts = Inventory.SearchParts(txtSearchParts.Text);
                BindingSource bsPart = new() { DataSource = foundParts };
                dgvParts.DataSource = bsPart;
            }
            catch (KeyNotFoundException)
            {
                string message = "No parts found containing \'" + txtSearchParts.Text + "\'.";
                string title = "No Results";
                MessageBox.Show(message, title);
            }
        }

        /**
         * <summary>
         * Method <c>BtnSearchProducts_Click</c> updates the Products DataGridView to Products containing the
         * text found in the txtSearchProducts TextBox
         * </summary>
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnSearchProducts_Click(object sender, EventArgs e)
        {
            if (!(txtSearchProducts.Text.Length > 0)) return;

            txtSearchProducts.Text = txtSearchProducts.Text.Trim();
            try
            {
                BindingList<Product> foundProducts = Inventory.SearchProducts(txtSearchProducts.Text);
                BindingSource bsProduct = new() { DataSource = foundProducts };
                dgvProducts.DataSource = bsProduct;
            }
            catch (KeyNotFoundException)
            {
                string message = "No products found containing \'" + txtSearchProducts.Text + "\'.";
                string title = "No Results";
                MessageBox.Show(message, title);
            }
        }

        /**
         * <summary>
         * Method <c>BtnAddPart_Click</c> opens the AddPartScreen Form and adds a listener for the Form closing
         * </summary>
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnAddPart_Click(object sender, EventArgs e)
        {
            AddPartScreen addPartScreen = new AddPartScreen();
            addPartScreen.FormClosing += AddPartScreen_FormClosing;
            addPartScreen.Show();
        }

        /**
         * <summary>
         * Method <c>AddPartScreen_FormClosing</c> refreshes the Parts DataGridView when the AddPartScreen is being closed
         * </summary>
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void AddPartScreen_FormClosing(object? sender, FormClosingEventArgs e)
        {
            dgvParts.Refresh();
        }

        /**
         * <summary>
         * Method <c>BtnModifyPart_Click</c> opens the ModifyPartScreen Form passing the selected Part as a param
         * and adds a listener for the Form closing
         * </summary>
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnModifyPart_Click(object sender, EventArgs e)
        {
            ModifyPartScreen modifyPartScreen;
            if (dgvParts.SelectedRows[0].DataBoundItem.GetType() == typeof(InhousePart))
            {
                modifyPartScreen = new ModifyPartScreen((InhousePart)dgvParts.SelectedRows[0].DataBoundItem);
            }
            else
            {
                modifyPartScreen = new ModifyPartScreen((OutsourcedPart)dgvParts.SelectedRows[0].DataBoundItem);
            }
            modifyPartScreen.FormClosing += ModifyParttScreen_FormClosing;
            modifyPartScreen.Show();
        }
        /**
         * <summary>
         * Method <c>ModifyPartScreen_FormClosing</c> refreshes the Parts DataGridView when the ModifyPartScreen is being closed
         * </summary>
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void ModifyParttScreen_FormClosing(object? sender, FormClosingEventArgs e)
        {
            dgvParts.Update();
        }

        /**
         * <summary>
         * Method <c>BtnDeletePart_Click</c> deletes the selected Part or Parts after a confirmation
         * </summary>
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnDeletePart_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete " + dgvParts.SelectedRows.Count + " parts?";
            string title = "Confirm Delete";
            DialogResult confirmDelete = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            if (confirmDelete == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvParts.SelectedRows)
                {
                    Inventory.DeletePart(Inventory.LookupPart(Convert.ToInt32(row.Cells[0].Value.ToString())));
                }
                BindingSource bsProduct = new() { DataSource = Inventory.Products };
                dgvProducts.DataSource = bsProduct;
            }
            else
            {
                message = "Did not delete selected parts.";
                title = "Delete Canceled";
                MessageBox.Show(message, title);
            }
            
        }

        /**
         * <summary>
         * Method <c>BtnAddProduct_Click</c> opens the AddProductScreen Form
         * </summary>
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            new AddProductScreen().Show();
        }

        /**
         * <summary>
         * Method <c>BtnModifyProduct_Click</c> opens the ModifyProductScreen Form passing the selected Product as a param
         * and adds a listener for the Form closing
         * </summary>
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnModifyProduct_Click(object sender, EventArgs e)
        {
            int idOfSelected = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells[0].Value.ToString());
            ModifyProductScreen modifyProductScreen = new ModifyProductScreen(Inventory.LookupProduct(idOfSelected));
            modifyProductScreen.FormClosing += ModifyProductScreen_FormClosing;
            modifyProductScreen.Show();
        }

        /**
         * <summary>
         * Method <c>ModifyProductScreen_FormClosing</c> refreshes the Product DataGridView when the ModifyProductScreen
         * Form is being closed
         * </summary>
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void ModifyProductScreen_FormClosing(object? sender, FormClosingEventArgs e)
        {
            dgvProducts.Refresh();
        }

        /**
         * <summary>
         * Method <c>BtnDeleteProduct_Click</c> deletes the selected Product or Products after confirming
         * and catches if the Product cannot be deleted due to having associated Parts
         * </summary>
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnDeleteProduct_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete " + dgvProducts.SelectedRows.Count + " products?";
            string title = "Confirm Delete";
            DialogResult confirmDelete = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            if (confirmDelete == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvProducts.SelectedRows)
                {
                    try
                    {
                        Inventory.RemoveProduct(Convert.ToInt32(row.Cells[0].Value.ToString()));
                    }
                    catch (InvalidOperationException)
                    {
                        message = "Product \'" + row.Cells[1].Value.ToString() + "\' has associated parts and cannot be deleted.";
                        title = "Failed to Delete";
                        MessageBox.Show(message, title);
                    }
                }
                BindingSource bsProduct = new() { DataSource = Inventory.Products };
                dgvProducts.DataSource = bsProduct;
            }
            else
            {
                message = "Did not delete selected products.";
                title = "Delete Canceled";
                MessageBox.Show(message, title);
            }
        }

        /**
         * <summary>
         * Method <c>BtnExit_Click</c> closes the program
         * </summary>
         * <param name="sender">Reference to object raising the event</param>
         * <param name="e">Event data</param>
         */
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}