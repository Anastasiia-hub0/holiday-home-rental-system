namespace HolidayHomeRentalSystem
{
    partial class frmMyProperties
    {
    
        private System.ComponentModel.IContainer components = null;

        
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
            this.lblMyProperties = new System.Windows.Forms.Label();
            this.dgvMyProps = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAvailabiliies = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyProps)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMyProperties
            // 
            this.lblMyProperties.AutoSize = true;
            this.lblMyProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyProperties.Location = new System.Drawing.Point(369, 32);
            this.lblMyProperties.Name = "lblMyProperties";
            this.lblMyProperties.Size = new System.Drawing.Size(175, 29);
            this.lblMyProperties.TabIndex = 0;
            this.lblMyProperties.Text = "My Properties";
            // 
            // dgvMyProps
            // 
            this.dgvMyProps.AllowUserToAddRows = false;
            this.dgvMyProps.AllowUserToDeleteRows = false;
            this.dgvMyProps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyProps.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvMyProps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyProps.Location = new System.Drawing.Point(21, 93);
            this.dgvMyProps.MultiSelect = false;
            this.dgvMyProps.Name = "dgvMyProps";
            this.dgvMyProps.ReadOnly = true;
            this.dgvMyProps.RowHeadersVisible = false;
            this.dgvMyProps.RowHeadersWidth = 51;
            this.dgvMyProps.RowTemplate.Height = 24;
            this.dgvMyProps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyProps.Size = new System.Drawing.Size(877, 330);
            this.dgvMyProps.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClose.Location = new System.Drawing.Point(447, 450);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 46);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(600, 450);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(131, 46);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.LimeGreen;
            this.btnEdit.Location = new System.Drawing.Point(753, 450);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(131, 46);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAvailabiliies
            // 
            this.btnAvailabiliies.BackColor = System.Drawing.Color.DarkOrange;
            this.btnAvailabiliies.Location = new System.Drawing.Point(46, 450);
            this.btnAvailabiliies.Name = "btnAvailabiliies";
            this.btnAvailabiliies.Size = new System.Drawing.Size(190, 46);
            this.btnAvailabiliies.TabIndex = 5;
            this.btnAvailabiliies.Text = "Manage Availabilities";
            this.btnAvailabiliies.UseVisualStyleBackColor = false;
            this.btnAvailabiliies.Click += new System.EventHandler(this.btnAvailabiliies_Click);
            // 
            // frmMyProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(920, 517);
            this.Controls.Add(this.btnAvailabiliies);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvMyProps);
            this.Controls.Add(this.lblMyProperties);
            this.Name = "frmMyProperties";
            this.Text = "frmMyProperties";
            this.Load += new System.EventHandler(this.frmMyProperties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyProps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMyProperties;
        private System.Windows.Forms.DataGridView dgvMyProps;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAvailabiliies;
    }
}