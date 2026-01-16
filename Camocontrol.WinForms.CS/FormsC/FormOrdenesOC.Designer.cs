namespace Camocontrol.WinForms.CS.FormsC
{
    partial class FormOrdenesOC
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
            btnCargar = new Button();
            dgvOrdenes = new DataGridView();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).BeginInit();
            SuspendLayout();
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(542, 406);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(100, 36);
            btnCargar.TabIndex = 0;
            btnCargar.Text = "button1";
            btnCargar.UseVisualStyleBackColor = true;
            // 
            // dgvOrdenes
            // 
            dgvOrdenes.AllowUserToAddRows = false;
            dgvOrdenes.AllowUserToDeleteRows = false;
            dgvOrdenes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrdenes.Location = new Point(12, 66);
            dgvOrdenes.Name = "dgvOrdenes";
            dgvOrdenes.ReadOnly = true;
            dgvOrdenes.RowHeadersWidth = 62;
            dgvOrdenes.Size = new Size(776, 266);
            dgvOrdenes.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(458, 358);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(59, 25);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "label1";
            // 
            // FormOrdenesOC
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTotal);
            Controls.Add(dgvOrdenes);
            Controls.Add(btnCargar);
            Name = "FormOrdenesOC";
            Text = "FormOrdenesOC";
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCargar;
        private DataGridView dgvOrdenes;
        private Label lblTotal;
    }
}