namespace WplacePaletteConverter.Views
{
	partial class Palette
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Palette));
			btnSave = new System.Windows.Forms.Button();
			dgvColors = new System.Windows.Forms.DataGridView();
			cmbSelections = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)dgvColors).BeginInit();
			SuspendLayout();
			// 
			// btnSave
			// 
			btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			btnSave.Location = new System.Drawing.Point(297, 626);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(75, 23);
			btnSave.TabIndex = 0;
			btnSave.Text = "Save";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// dgvColors
			// 
			dgvColors.AllowUserToAddRows = false;
			dgvColors.AllowUserToDeleteRows = false;
			dgvColors.AllowUserToResizeRows = false;
			dgvColors.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgvColors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvColors.Location = new System.Drawing.Point(12, 41);
			dgvColors.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
			dgvColors.Name = "dgvColors";
			dgvColors.ReadOnly = true;
			dgvColors.RowHeadersVisible = false;
			dgvColors.Size = new System.Drawing.Size(360, 572);
			dgvColors.TabIndex = 1;
			dgvColors.CellClick += dgvColors_CellClick;
			dgvColors.SelectionChanged += dgvColors_SelectionChanged;
			// 
			// cmbSelections
			// 
			cmbSelections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmbSelections.FormattingEnabled = true;
			cmbSelections.Location = new System.Drawing.Point(132, 12);
			cmbSelections.Name = "cmbSelections";
			cmbSelections.Size = new System.Drawing.Size(121, 23);
			cmbSelections.TabIndex = 2;
			cmbSelections.SelectedIndexChanged += cmbSelections_SelectedIndexChanged;
			// 
			// Palette
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			ClientSize = new System.Drawing.Size(384, 661);
			Controls.Add(cmbSelections);
			Controls.Add(dgvColors);
			Controls.Add(btnSave);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "Palette";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Palette";
			Click += Palette_Click;
			((System.ComponentModel.ISupportInitialize)dgvColors).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.DataGridView dgvColors;
		private System.Windows.Forms.ComboBox cmbSelections;
	}
}