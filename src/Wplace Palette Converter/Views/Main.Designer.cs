using System.Drawing;
using System.Windows.Forms;

namespace WplacePaletteConverter.Views
{
	partial class Main
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			openToolStripMenuItem = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			saveAsToolStripMenuItem = new ToolStripMenuItem();
			toolStripSeparator2 = new ToolStripSeparator();
			closeToolStripMenuItem = new ToolStripMenuItem();
			exitToolStripMenuItem = new ToolStripMenuItem();
			paletteToolStripMenuItem = new ToolStripMenuItem();
			aboutToolStripMenuItem = new ToolStripMenuItem();
			picInput = new WplacePaletteConverter.Views.CustomControls.ZoomablePictureBox();
			picOutput = new WplacePaletteConverter.Views.CustomControls.ZoomablePictureBox();
			label1 = new Label();
			label2 = new Label();
			cmbMethod = new ComboBox();
			lblLoadingInfo = new Label();
			label3 = new Label();
			label4 = new Label();
			lblWplaceColorName = new Label();
			lblWplaceColor = new Label();
			chkFitPicBoxSize = new CheckBox();
			trkContrast = new TrackBar();
			label5 = new Label();
			lblContrast = new Label();
			menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picInput).BeginInit();
			((System.ComponentModel.ISupportInitialize)picOutput).BeginInit();
			((System.ComponentModel.ISupportInitialize)trkContrast).BeginInit();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.BackColor = Color.White;
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, paletteToolStripMenuItem, aboutToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(854, 24);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, toolStripSeparator1, saveAsToolStripMenuItem, toolStripSeparator2, closeToolStripMenuItem, exitToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			openToolStripMenuItem.Image = Properties.Resources.open;
			openToolStripMenuItem.Name = "openToolStripMenuItem";
			openToolStripMenuItem.Size = new Size(180, 22);
			openToolStripMenuItem.Text = "Open...";
			openToolStripMenuItem.Click += openToolStripMenuItem_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(177, 6);
			// 
			// saveAsToolStripMenuItem
			// 
			saveAsToolStripMenuItem.Enabled = false;
			saveAsToolStripMenuItem.Image = Properties.Resources.save;
			saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			saveAsToolStripMenuItem.Size = new Size(180, 22);
			saveAsToolStripMenuItem.Text = "Save As...";
			saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(177, 6);
			// 
			// closeToolStripMenuItem
			// 
			closeToolStripMenuItem.Image = Properties.Resources.close;
			closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			closeToolStripMenuItem.Size = new Size(180, 22);
			closeToolStripMenuItem.Text = "Close";
			closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
			// 
			// exitToolStripMenuItem
			// 
			exitToolStripMenuItem.Image = Properties.Resources.exit;
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.Size = new Size(180, 22);
			exitToolStripMenuItem.Text = "Exit";
			exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
			// 
			// paletteToolStripMenuItem
			// 
			paletteToolStripMenuItem.Name = "paletteToolStripMenuItem";
			paletteToolStripMenuItem.Size = new Size(55, 20);
			paletteToolStripMenuItem.Text = "Palette";
			paletteToolStripMenuItem.Click += paletteToolStripMenuItem_Click;
			// 
			// aboutToolStripMenuItem
			// 
			aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			aboutToolStripMenuItem.Size = new Size(52, 20);
			aboutToolStripMenuItem.Text = "About";
			aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
			// 
			// picInput
			// 
			picInput.BackColor = SystemColors.ButtonHighlight;
			picInput.BackgroundImageLayout = ImageLayout.Center;
			picInput.Location = new Point(12, 89);
			picInput.Name = "picInput";
			picInput.Size = new Size(400, 400);
			picInput.TabIndex = 1;
			picInput.TabStop = false;
			picInput.DragDrop += picInput_DragDrop;
			picInput.DragEnter += picInput_DragEnter;
			// 
			// picOutput
			// 
			picOutput.BackColor = SystemColors.ButtonHighlight;
			picOutput.BackgroundImageLayout = ImageLayout.Center;
			picOutput.Location = new Point(442, 89);
			picOutput.Name = "picOutput";
			picOutput.Size = new Size(400, 400);
			picOutput.TabIndex = 2;
			picOutput.TabStop = false;
			picOutput.MouseMove += picOutput_MouseMove;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			label1.Location = new Point(12, 71);
			label1.Name = "label1";
			label1.Size = new Size(37, 15);
			label1.TabIndex = 3;
			label1.Text = "Input";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			label2.Location = new Point(442, 71);
			label2.Name = "label2";
			label2.Size = new Size(47, 15);
			label2.TabIndex = 4;
			label2.Text = "Output";
			// 
			// cmbMethod
			// 
			cmbMethod.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbMethod.FormattingEnabled = true;
			cmbMethod.Location = new Point(565, 38);
			cmbMethod.Margin = new Padding(3, 3, 10, 10);
			cmbMethod.Name = "cmbMethod";
			cmbMethod.Size = new Size(121, 23);
			cmbMethod.TabIndex = 5;
			cmbMethod.SelectedIndexChanged += cmbMethod_SelectedIndexChanged;
			// 
			// lblLoadingInfo
			// 
			lblLoadingInfo.Font = new Font("Segoe UI", 9F);
			lblLoadingInfo.Location = new Point(495, 71);
			lblLoadingInfo.Name = "lblLoadingInfo";
			lblLoadingInfo.Size = new Size(347, 15);
			lblLoadingInfo.TabIndex = 6;
			lblLoadingInfo.TextAlign = ContentAlignment.TopRight;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			label3.Location = new Point(442, 41);
			label3.Name = "label3";
			label3.Size = new Size(117, 15);
			label3.TabIndex = 7;
			label3.Text = "Distance Algorithm:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			label4.Location = new Point(442, 492);
			label4.Name = "label4";
			label4.Size = new Size(39, 15);
			label4.TabIndex = 8;
			label4.Text = "Color:";
			// 
			// lblWplaceColorName
			// 
			lblWplaceColorName.Font = new Font("Segoe UI", 9F);
			lblWplaceColorName.Location = new Point(487, 492);
			lblWplaceColorName.Name = "lblWplaceColorName";
			lblWplaceColorName.Size = new Size(100, 15);
			lblWplaceColorName.TabIndex = 9;
			// 
			// lblWplaceColor
			// 
			lblWplaceColor.Font = new Font("Segoe UI", 9F);
			lblWplaceColor.Location = new Point(593, 492);
			lblWplaceColor.Name = "lblWplaceColor";
			lblWplaceColor.Size = new Size(60, 15);
			lblWplaceColor.TabIndex = 10;
			// 
			// chkFitPicBoxSize
			// 
			chkFitPicBoxSize.AutoSize = true;
			chkFitPicBoxSize.Checked = true;
			chkFitPicBoxSize.CheckState = CheckState.Checked;
			chkFitPicBoxSize.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			chkFitPicBoxSize.Location = new Point(706, 41);
			chkFitPicBoxSize.Margin = new Padding(10, 3, 3, 3);
			chkFitPicBoxSize.Name = "chkFitPicBoxSize";
			chkFitPicBoxSize.Size = new Size(131, 19);
			chkFitPicBoxSize.TabIndex = 11;
			chkFitPicBoxSize.Text = "Fit PictureBox Size";
			chkFitPicBoxSize.UseVisualStyleBackColor = true;
			chkFitPicBoxSize.CheckedChanged += chkFitPicBoxSize_CheckedChanged;
			chkFitPicBoxSize.MouseHover += chkFitPicBoxSize_MouseHover;
			// 
			// trkContrast
			// 
			trkContrast.AutoSize = false;
			trkContrast.Location = new Point(12, 45);
			trkContrast.Maximum = 200;
			trkContrast.Minimum = 50;
			trkContrast.Name = "trkContrast";
			trkContrast.Size = new Size(167, 23);
			trkContrast.TabIndex = 12;
			trkContrast.TickStyle = TickStyle.None;
			trkContrast.Value = 100;
			trkContrast.ValueChanged += trkContrast_ValueChanged;
			trkContrast.MouseUp += trkContrast_MouseUp;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			label5.Location = new Point(17, 27);
			label5.Margin = new Padding(3, 0, 0, 0);
			label5.Name = "label5";
			label5.Size = new Size(57, 15);
			label5.TabIndex = 13;
			label5.Text = "Contrast:";
			// 
			// lblContrast
			// 
			lblContrast.AutoSize = true;
			lblContrast.Font = new Font("Segoe UI", 9F);
			lblContrast.Location = new Point(74, 27);
			lblContrast.Margin = new Padding(0, 0, 3, 0);
			lblContrast.Name = "lblContrast";
			lblContrast.Size = new Size(13, 15);
			lblContrast.TabIndex = 14;
			lblContrast.Text = "0";
			// 
			// Main
			// 
			AutoScaleDimensions = new SizeF(96F, 96F);
			AutoScaleMode = AutoScaleMode.Dpi;
			ClientSize = new Size(854, 521);
			Controls.Add(lblContrast);
			Controls.Add(label5);
			Controls.Add(trkContrast);
			Controls.Add(chkFitPicBoxSize);
			Controls.Add(lblWplaceColor);
			Controls.Add(lblWplaceColorName);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(lblLoadingInfo);
			Controls.Add(cmbMethod);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(picOutput);
			Controls.Add(picInput);
			Controls.Add(menuStrip1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip1;
			MaximizeBox = false;
			Name = "Main";
			Text = "Wplace Palette Converter";
			FormClosing += Main_FormClosing;
			Click += Main_Click;
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)picInput).EndInit();
			((System.ComponentModel.ISupportInitialize)picOutput).EndInit();
			((System.ComponentModel.ISupportInitialize)trkContrast).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem openToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem saveAsToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem aboutToolStripMenuItem;
		private ToolStripMenuItem closeToolStripMenuItem;
		private ToolStripMenuItem exitToolStripMenuItem;
		private CustomControls.ZoomablePictureBox picInput;
		private CustomControls.ZoomablePictureBox picOutput;
		private Label label1;
		private Label label2;
		private ComboBox cmbMethod;
		private ToolStripMenuItem paletteToolStripMenuItem;
		private Label lblLoadingInfo;
		private Label label3;
		private Label label4;
		private Label lblWplaceColorName;
		private Label lblWplaceColor;
		private CheckBox chkFitPicBoxSize;
		private TrackBar trkContrast;
		private Label label5;
		private Label lblContrast;
	}
}