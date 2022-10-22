namespace Inventory
{
    partial class ModifyProductScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvCandParts = new System.Windows.Forms.DataGridView();
            this.dgvAssocParts = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCandParts = new System.Windows.Forms.Label();
            this.lblAssocParts = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblInventory = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtInventory = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssocParts)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(153, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Modify Product";
            // 
            // dgvCandParts
            // 
            this.dgvCandParts.AllowUserToAddRows = false;
            this.dgvCandParts.AllowUserToDeleteRows = false;
            this.dgvCandParts.AllowUserToResizeColumns = false;
            this.dgvCandParts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCandParts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCandParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCandParts.EnableHeadersVisualStyles = false;
            this.dgvCandParts.ReadOnly = true;
            this.dgvCandParts.RowHeadersVisible = false;
            this.dgvCandParts.RowTemplate.Height = 25;
            this.dgvCandParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCandParts.TabIndex = 1;
            this.dgvCandParts.Location = new System.Drawing.Point(515, 87);
            this.dgvCandParts.Name = "dgvCandParts";
            this.dgvCandParts.Size = new System.Drawing.Size(566, 171);
            // 
            // dgvAssocParts
            // 
            this.dgvAssocParts.AllowUserToAddRows = false;
            this.dgvAssocParts.AllowUserToDeleteRows = false;
            this.dgvAssocParts.AllowUserToResizeColumns = false;
            this.dgvAssocParts.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAssocParts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAssocParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssocParts.EnableHeadersVisualStyles = false;
            this.dgvAssocParts.Location = new System.Drawing.Point(33, 109);
            this.dgvAssocParts.Name = "dgvAssocParts";
            this.dgvAssocParts.ReadOnly = true;
            this.dgvAssocParts.RowHeadersVisible = false;
            this.dgvAssocParts.RowTemplate.Height = 25;
            this.dgvAssocParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssocParts.Size = new System.Drawing.Size(528, 271);
            this.dgvAssocParts.TabIndex = 1;
            this.dgvAssocParts.Location = new System.Drawing.Point(515, 336);
            this.dgvAssocParts.Name = "dgvAssocParts";
            this.dgvAssocParts.Size = new System.Drawing.Size(566, 171);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(865, 58);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(216, 23);
            this.txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(784, 58);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // lblCandParts
            // 
            this.lblCandParts.AutoSize = true;
            this.lblCandParts.Location = new System.Drawing.Point(515, 66);
            this.lblCandParts.Name = "lblCandParts";
            this.lblCandParts.Size = new System.Drawing.Size(107, 15);
            this.lblCandParts.TabIndex = 5;
            this.lblCandParts.Text = "All Candidate Parts";
            // 
            // lblAssocParts
            // 
            this.lblAssocParts.AutoSize = true;
            this.lblAssocParts.Location = new System.Drawing.Point(515, 315);
            this.lblAssocParts.Name = "lblAssocParts";
            this.lblAssocParts.Size = new System.Drawing.Size(110, 15);
            this.lblAssocParts.TabIndex = 6;
            this.lblAssocParts.Text = "All Associated Parts";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1017, 264);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 35);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1017, 513);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 35);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblId.Location = new System.Drawing.Point(60, 190);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(25, 21);
            this.lblId.TabIndex = 9;
            this.lblId.Text = "ID";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(60, 235);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 21);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Name";
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInventory.Location = new System.Drawing.Point(60, 280);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(76, 21);
            this.lblInventory.TabIndex = 11;
            this.lblInventory.Text = "Inventory";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrice.Location = new System.Drawing.Point(60, 325);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(44, 21);
            this.lblPrice.TabIndex = 12;
            this.lblPrice.Text = "Price";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMax.Location = new System.Drawing.Point(60, 370);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(39, 21);
            this.lblMax.TabIndex = 13;
            this.lblMax.Text = "Max";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMin.Location = new System.Drawing.Point(244, 370);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(37, 21);
            this.lblMin.TabIndex = 14;
            this.lblMin.Text = "Min";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(160, 190);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(166, 23);
            this.txtId.TabIndex = 15;
            this.txtId.Enabled = false;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(160, 235);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(166, 23);
            this.txtName.TabIndex = 16;
            // 
            // txtInventory
            // 
            this.txtInventory.Location = new System.Drawing.Point(160, 280);
            this.txtInventory.Name = "txtInventory";
            this.txtInventory.Size = new System.Drawing.Size(166, 23);
            this.txtInventory.TabIndex = 17;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(160, 325);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(166, 23);
            this.txtPrice.TabIndex = 18;
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(115, 370);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(107, 23);
            this.txtMax.TabIndex = 19;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(296, 370);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(107, 23);
            this.txtMin.TabIndex = 20;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1017, 574);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 35);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(947, 574);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 35);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(703, 58);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 23;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // ModifyProductScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 639);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtInventory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblInventory);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblAssocParts);
            this.Controls.Add(this.lblCandParts);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvAssocParts);
            this.Controls.Add(this.dgvCandParts);
            this.Controls.Add(this.lblTitle);
            this.Name = "ModifyProductScreen";
            this.Text = "Product";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssocParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvCandParts;
        private DataGridView dgvAssocParts;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label lblCandParts;
        private Label lblAssocParts;
        private Button btnAdd;
        private Button btnDelete;
        private Label lblId;
        private Label lblName;
        private Label lblInventory;
        private Label lblPrice;
        private Label lblMax;
        private Label lblMin;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtInventory;
        private TextBox txtPrice;
        private TextBox txtMax;
        private TextBox txtMin;
        private Button btnCancel;
        private Button btnSave;
        private Button btnRefresh;
    }
}