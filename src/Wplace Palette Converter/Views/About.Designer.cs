using WplacePaletteConverter.Views.CustomControls;

namespace WplacePaletteConverter.Views
{
	partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            label1 = new System.Windows.Forms.Label();
            lblVersion = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            lnkGitHub = new System.Windows.Forms.LinkLabel();
            lnkNewtonsoftJson = new System.Windows.Forms.LinkLabel();
            label3 = new System.Windows.Forms.Label();
            lnkColourful = new System.Windows.Forms.LinkLabel();
            lnkLicense = new System.Windows.Forms.LinkLabel();
            label4 = new System.Windows.Forms.Label();
            lnkFlameHorizon = new System.Windows.Forms.LinkLabel();
            label5 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(346, 37);
            label1.TabIndex = 0;
            label1.Text = "Wplace Palette Converter";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new System.Drawing.Point(358, 31);
            lblVersion.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(40, 15);
            lblVersion.TabIndex = 1;
            lblVersion.Text = "vX.X.X";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 66);
            label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(472, 45);
            label2.TabIndex = 2;
            label2.Text = "WPPC is a free open source project to convert image colors to the Wplace colors palette.\r\n\r\nMade in C# .NET 8 by Criper98.";
            // 
            // lnkGitHub
            // 
            lnkGitHub.AutoSize = true;
            lnkGitHub.Location = new System.Drawing.Point(12, 121);
            lnkGitHub.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            lnkGitHub.Name = "lnkGitHub";
            lnkGitHub.Size = new System.Drawing.Size(45, 15);
            lnkGitHub.TabIndex = 3;
            lnkGitHub.TabStop = true;
            lnkGitHub.Text = "GitHub";
            lnkGitHub.LinkClicked += lnkGitHub_LinkClicked;
            // 
            // lnkNewtonsoftJson
            // 
            lnkNewtonsoftJson.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lnkNewtonsoftJson.AutoSize = true;
            lnkNewtonsoftJson.Location = new System.Drawing.Point(12, 293);
            lnkNewtonsoftJson.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            lnkNewtonsoftJson.Name = "lnkNewtonsoftJson";
            lnkNewtonsoftJson.Size = new System.Drawing.Size(126, 15);
            lnkNewtonsoftJson.TabIndex = 4;
            lnkNewtonsoftJson.TabStop = true;
            lnkNewtonsoftJson.Text = "Newtonsoft.Json (MIT)";
            lnkNewtonsoftJson.LinkClicked += lnkNewtonsoftJson_LinkClicked;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 268);
            label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(246, 15);
            label3.TabIndex = 5;
            label3.Text = "WPPC uses the following third-party libraries:";
            // 
            // lnkColourful
            // 
            lnkColourful.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lnkColourful.AutoSize = true;
            lnkColourful.Location = new System.Drawing.Point(12, 318);
            lnkColourful.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            lnkColourful.Name = "lnkColourful";
            lnkColourful.Size = new System.Drawing.Size(88, 15);
            lnkColourful.TabIndex = 6;
            lnkColourful.TabStop = true;
            lnkColourful.Text = "Colourful (MIT)";
            lnkColourful.LinkClicked += lnkColourful_LinkClicked;
            // 
            // lnkLicense
            // 
            lnkLicense.AutoSize = true;
            lnkLicense.Location = new System.Drawing.Point(60, 121);
            lnkLicense.Margin = new System.Windows.Forms.Padding(0, 10, 3, 0);
            lnkLicense.Name = "lnkLicense";
            lnkLicense.Size = new System.Drawing.Size(46, 15);
            lnkLicense.TabIndex = 7;
            lnkLicense.TabStop = true;
            lnkLicense.Text = "License";
            lnkLicense.LinkClicked += lnkLicense_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 176);
            label4.Margin = new System.Windows.Forms.Padding(3, 40, 3, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(99, 15);
            label4.TabIndex = 8;
            label4.Text = "Special thanks to:";
            // 
            // lnkFlameHorizon
            // 
            lnkFlameHorizon.AutoSize = true;
            lnkFlameHorizon.Location = new System.Drawing.Point(12, 201);
            lnkFlameHorizon.Margin = new System.Windows.Forms.Padding(3, 10, 0, 0);
            lnkFlameHorizon.Name = "lnkFlameHorizon";
            lnkFlameHorizon.Size = new System.Drawing.Size(81, 15);
            lnkFlameHorizon.TabIndex = 9;
            lnkFlameHorizon.TabStop = true;
            lnkFlameHorizon.Text = "FlameHorizon";
            lnkFlameHorizon.LinkClicked += lnkFlameHorizon_LinkClicked;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(93, 201);
            label5.Margin = new System.Windows.Forms.Padding(0, 10, 3, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(175, 15);
            label5.TabIndex = 10;
            label5.Text = "- Color conversion optimization";
            // 
            // About
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(494, 356);
            Controls.Add(label5);
            Controls.Add(lnkFlameHorizon);
            Controls.Add(label4);
            Controls.Add(lnkLicense);
            Controls.Add(lnkColourful);
            Controls.Add(label3);
            Controls.Add(lnkNewtonsoftJson);
            Controls.Add(lnkGitHub);
            Controls.Add(label2);
            Controls.Add(lblVersion);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "About";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "About";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel lnkGitHub;
		private System.Windows.Forms.LinkLabel lnkNewtonsoftJson;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.LinkLabel lnkColourful;
		private System.Windows.Forms.LinkLabel lnkLicense;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lnkFlameHorizon;
        private System.Windows.Forms.Label label5;
    }
}