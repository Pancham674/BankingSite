namespace BankingSite
{
	partial class AssociatedDataTables
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
			this.dgvAssosiatedDataTable = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvAssosiatedDataTable)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvAssosiatedDataTable
			// 
			this.dgvAssosiatedDataTable.AllowUserToAddRows = false;
			this.dgvAssosiatedDataTable.AllowUserToDeleteRows = false;
			this.dgvAssosiatedDataTable.AllowUserToResizeColumns = false;
			this.dgvAssosiatedDataTable.AllowUserToResizeRows = false;
			this.dgvAssosiatedDataTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvAssosiatedDataTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvAssosiatedDataTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvAssosiatedDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAssosiatedDataTable.Location = new System.Drawing.Point(12, 12);
			this.dgvAssosiatedDataTable.MultiSelect = false;
			this.dgvAssosiatedDataTable.Name = "dgvAssosiatedDataTable";
			this.dgvAssosiatedDataTable.ReadOnly = true;
			this.dgvAssosiatedDataTable.RowHeadersWidth = 4;
			this.dgvAssosiatedDataTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvAssosiatedDataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvAssosiatedDataTable.ShowEditingIcon = false;
			this.dgvAssosiatedDataTable.Size = new System.Drawing.Size(620, 237);
			this.dgvAssosiatedDataTable.TabIndex = 1;
			// 
			// AssociatedDataTables
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(644, 261);
			this.Controls.Add(this.dgvAssosiatedDataTable);
			this.MinimumSize = new System.Drawing.Size(660, 300);
			this.Name = "AssociatedDataTables";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AssotiatedDataTables";
			this.Load += new System.EventHandler(this.AssociatedDataTables_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvAssosiatedDataTable)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvAssosiatedDataTable;
	}
}