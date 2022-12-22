
namespace RackUI
{
	partial class MainForm
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
			this.labelHeight = new System.Windows.Forms.Label();
			this.labelWidthSupport = new System.Windows.Forms.Label();
			this.labelAmtHooks = new System.Windows.Forms.Label();
			this.labelWidthHooks = new System.Windows.Forms.Label();
			this.labelWidthRack = new System.Windows.Forms.Label();
			this.labelLengthSupport = new System.Windows.Forms.Label();
			this.textBoxHeigthRack = new System.Windows.Forms.TextBox();
			this.textBoxWidthSupport = new System.Windows.Forms.TextBox();
			this.textBoxAmtHooks = new System.Windows.Forms.TextBox();
			this.textBoxWidthHooks = new System.Windows.Forms.TextBox();
			this.textBoxWidthRack = new System.Windows.Forms.TextBox();
			this.textBoxLengthSupport = new System.Windows.Forms.TextBox();
			this.buttonBuild = new System.Windows.Forms.Button();
			this.labelHeightValue = new System.Windows.Forms.Label();
			this.labelWidthSupportValue = new System.Windows.Forms.Label();
			this.labelAmtHooksValue = new System.Windows.Forms.Label();
			this.labelWidthHooksValue = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelLengthStandValue = new System.Windows.Forms.Label();
			this.textBoxLengthStand = new System.Windows.Forms.TextBox();
			this.labelLengthStand = new System.Windows.Forms.Label();
			this.sampleImage = new System.Windows.Forms.PictureBox();
			this.labelLengthSupportValue = new System.Windows.Forms.Label();
			this.labelWidthRackValue = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sampleImage)).BeginInit();
			this.SuspendLayout();
			// 
			// labelHeight
			// 
			this.labelHeight.AutoSize = true;
			this.labelHeight.Location = new System.Drawing.Point(4, 11);
			this.labelHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelHeight.Name = "labelHeight";
			this.labelHeight.Size = new System.Drawing.Size(153, 20);
			this.labelHeight.TabIndex = 0;
			this.labelHeight.Text = "Высота вешалки H";
			// 
			// labelWidthSupport
			// 
			this.labelWidthSupport.AutoSize = true;
			this.labelWidthSupport.Location = new System.Drawing.Point(4, 57);
			this.labelWidthSupport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelWidthSupport.Name = "labelWidthSupport";
			this.labelWidthSupport.Size = new System.Drawing.Size(139, 20);
			this.labelWidthSupport.TabIndex = 1;
			this.labelWidthSupport.Text = "Ширина опоры s1";
			// 
			// labelAmtHooks
			// 
			this.labelAmtHooks.AutoSize = true;
			this.labelAmtHooks.Location = new System.Drawing.Point(4, 108);
			this.labelAmtHooks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelAmtHooks.Name = "labelAmtHooks";
			this.labelAmtHooks.Size = new System.Drawing.Size(181, 20);
			this.labelAmtHooks.TabIndex = 2;
			this.labelAmtHooks.Text = "Количество крючков n";
			// 
			// labelWidthHooks
			// 
			this.labelWidthHooks.AutoSize = true;
			this.labelWidthHooks.Location = new System.Drawing.Point(4, 157);
			this.labelWidthHooks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelWidthHooks.Name = "labelWidthHooks";
			this.labelWidthHooks.Size = new System.Drawing.Size(215, 20);
			this.labelWidthHooks.TabIndex = 3;
			this.labelWidthHooks.Text = "Ширина между крючками ln";
			// 
			// labelWidthRack
			// 
			this.labelWidthRack.AutoSize = true;
			this.labelWidthRack.Location = new System.Drawing.Point(4, 206);
			this.labelWidthRack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelWidthRack.Name = "labelWidthRack";
			this.labelWidthRack.Size = new System.Drawing.Size(151, 20);
			this.labelWidthRack.TabIndex = 4;
			this.labelWidthRack.Text = "Ширина вешалки L";
			// 
			// labelLengthSupport
			// 
			this.labelLengthSupport.AutoSize = true;
			this.labelLengthSupport.Location = new System.Drawing.Point(4, 254);
			this.labelLengthSupport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelLengthSupport.Name = "labelLengthSupport";
			this.labelLengthSupport.Size = new System.Drawing.Size(195, 20);
			this.labelLengthSupport.TabIndex = 5;
			this.labelLengthSupport.Text = "Длина опоры вешалки S";
			// 
			// textBoxHeigthRack
			// 
			this.textBoxHeigthRack.Location = new System.Drawing.Point(242, 6);
			this.textBoxHeigthRack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBoxHeigthRack.Name = "textBoxHeigthRack";
			this.textBoxHeigthRack.Size = new System.Drawing.Size(73, 26);
			this.textBoxHeigthRack.TabIndex = 6;
			this.textBoxHeigthRack.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
			this.textBoxHeigthRack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_KeyPress);
			// 
			// textBoxWidthSupport
			// 
			this.textBoxWidthSupport.Location = new System.Drawing.Point(242, 52);
			this.textBoxWidthSupport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBoxWidthSupport.Name = "textBoxWidthSupport";
			this.textBoxWidthSupport.Size = new System.Drawing.Size(73, 26);
			this.textBoxWidthSupport.TabIndex = 7;
			this.textBoxWidthSupport.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
			this.textBoxWidthSupport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_KeyPress);
			// 
			// textBoxAmtHooks
			// 
			this.textBoxAmtHooks.Location = new System.Drawing.Point(242, 103);
			this.textBoxAmtHooks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBoxAmtHooks.Name = "textBoxAmtHooks";
			this.textBoxAmtHooks.Size = new System.Drawing.Size(73, 26);
			this.textBoxAmtHooks.TabIndex = 8;
			this.textBoxAmtHooks.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
			this.textBoxAmtHooks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_KeyPress);
			// 
			// textBoxWidthHooks
			// 
			this.textBoxWidthHooks.Location = new System.Drawing.Point(242, 152);
			this.textBoxWidthHooks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBoxWidthHooks.Name = "textBoxWidthHooks";
			this.textBoxWidthHooks.Size = new System.Drawing.Size(73, 26);
			this.textBoxWidthHooks.TabIndex = 9;
			this.textBoxWidthHooks.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
			this.textBoxWidthHooks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_KeyPress);
			// 
			// textBoxWidthRack
			// 
			this.textBoxWidthRack.Location = new System.Drawing.Point(242, 202);
			this.textBoxWidthRack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBoxWidthRack.Name = "textBoxWidthRack";
			this.textBoxWidthRack.Size = new System.Drawing.Size(73, 26);
			this.textBoxWidthRack.TabIndex = 10;
			this.textBoxWidthRack.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
			this.textBoxWidthRack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_KeyPress);
			// 
			// textBoxLengthSupport
			// 
			this.textBoxLengthSupport.Location = new System.Drawing.Point(242, 249);
			this.textBoxLengthSupport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBoxLengthSupport.Name = "textBoxLengthSupport";
			this.textBoxLengthSupport.Size = new System.Drawing.Size(73, 26);
			this.textBoxLengthSupport.TabIndex = 11;
			this.textBoxLengthSupport.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
			this.textBoxLengthSupport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_KeyPress);
			// 
			// buttonBuild
			// 
			this.buttonBuild.Location = new System.Drawing.Point(82, 363);
			this.buttonBuild.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonBuild.Name = "buttonBuild";
			this.buttonBuild.Size = new System.Drawing.Size(146, 52);
			this.buttonBuild.TabIndex = 12;
			this.buttonBuild.Text = "Построить";
			this.buttonBuild.UseVisualStyleBackColor = true;
			this.buttonBuild.Click += new System.EventHandler(this.ButtonBuild_Click);
			// 
			// labelHeightValue
			// 
			this.labelHeightValue.AutoSize = true;
			this.labelHeightValue.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.labelHeightValue.Location = new System.Drawing.Point(24, 28);
			this.labelHeightValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelHeightValue.Name = "labelHeightValue";
			this.labelHeightValue.Size = new System.Drawing.Size(167, 20);
			this.labelHeightValue.TabIndex = 13;
			this.labelHeightValue.Text = "(от 1000 до 1300 мм)";
			// 
			// labelWidthSupportValue
			// 
			this.labelWidthSupportValue.AutoSize = true;
			this.labelWidthSupportValue.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.labelWidthSupportValue.Location = new System.Drawing.Point(24, 77);
			this.labelWidthSupportValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelWidthSupportValue.Name = "labelWidthSupportValue";
			this.labelWidthSupportValue.Size = new System.Drawing.Size(149, 20);
			this.labelWidthSupportValue.TabIndex = 14;
			this.labelWidthSupportValue.Text = "(от 200 до 300 мм)";
			// 
			// labelAmtHooksValue
			// 
			this.labelAmtHooksValue.AutoSize = true;
			this.labelAmtHooksValue.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.labelAmtHooksValue.Location = new System.Drawing.Point(24, 128);
			this.labelAmtHooksValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelAmtHooksValue.Name = "labelAmtHooksValue";
			this.labelAmtHooksValue.Size = new System.Drawing.Size(87, 20);
			this.labelAmtHooksValue.TabIndex = 15;
			this.labelAmtHooksValue.Text = "(от 2 до 7)";
			// 
			// labelWidthHooksValue
			// 
			this.labelWidthHooksValue.AutoSize = true;
			this.labelWidthHooksValue.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.labelWidthHooksValue.Location = new System.Drawing.Point(24, 177);
			this.labelWidthHooksValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelWidthHooksValue.Name = "labelWidthHooksValue";
			this.labelWidthHooksValue.Size = new System.Drawing.Size(140, 20);
			this.labelWidthHooksValue.TabIndex = 16;
			this.labelWidthHooksValue.Text = "(от 50 до 100 мм)";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.labelLengthStandValue);
			this.panel1.Controls.Add(this.textBoxLengthStand);
			this.panel1.Controls.Add(this.labelLengthStand);
			this.panel1.Controls.Add(this.sampleImage);
			this.panel1.Controls.Add(this.labelLengthSupportValue);
			this.panel1.Controls.Add(this.buttonBuild);
			this.panel1.Controls.Add(this.labelWidthRackValue);
			this.panel1.Controls.Add(this.textBoxLengthSupport);
			this.panel1.Controls.Add(this.labelHeight);
			this.panel1.Controls.Add(this.textBoxWidthRack);
			this.panel1.Controls.Add(this.labelWidthHooksValue);
			this.panel1.Controls.Add(this.textBoxWidthHooks);
			this.panel1.Controls.Add(this.labelHeightValue);
			this.panel1.Controls.Add(this.textBoxAmtHooks);
			this.panel1.Controls.Add(this.labelAmtHooksValue);
			this.panel1.Controls.Add(this.textBoxWidthSupport);
			this.panel1.Controls.Add(this.labelWidthSupport);
			this.panel1.Controls.Add(this.textBoxHeigthRack);
			this.panel1.Controls.Add(this.labelWidthSupportValue);
			this.panel1.Controls.Add(this.labelAmtHooks);
			this.panel1.Controls.Add(this.labelLengthSupport);
			this.panel1.Controls.Add(this.labelWidthHooks);
			this.panel1.Controls.Add(this.labelWidthRack);
			this.panel1.Location = new System.Drawing.Point(4, 3);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(654, 444);
			this.panel1.TabIndex = 17;
			// 
			// labelLengthStandValue
			// 
			this.labelLengthStandValue.AutoSize = true;
			this.labelLengthStandValue.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.labelLengthStandValue.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.labelLengthStandValue.Location = new System.Drawing.Point(24, 325);
			this.labelLengthStandValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelLengthStandValue.Name = "labelLengthStandValue";
			this.labelLengthStandValue.Size = new System.Drawing.Size(92, 20);
			this.labelLengthStandValue.TabIndex = 22;
			this.labelLengthStandValue.Text = "(от 100 до)";
			// 
			// textBoxLengthStand
			// 
			this.textBoxLengthStand.Location = new System.Drawing.Point(242, 300);
			this.textBoxLengthStand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBoxLengthStand.Name = "textBoxLengthStand";
			this.textBoxLengthStand.Size = new System.Drawing.Size(73, 26);
			this.textBoxLengthStand.TabIndex = 21;
			this.textBoxLengthStand.TextChanged += new System.EventHandler(this.Textbox_TextChanged);
			this.textBoxLengthStand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_KeyPress);
			// 
			// labelLengthStand
			// 
			this.labelLengthStand.AutoSize = true;
			this.labelLengthStand.Location = new System.Drawing.Point(4, 305);
			this.labelLengthStand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelLengthStand.Name = "labelLengthStand";
			this.labelLengthStand.Size = new System.Drawing.Size(237, 20);
			this.labelLengthStand.TabIndex = 20;
			this.labelLengthStand.Text = "Длина подсавки для обуви L2";
			// 
			// sampleImage
			// 
			this.sampleImage.Image = global::RackUI.Properties.Resources.RackIMG;
			this.sampleImage.Location = new System.Drawing.Point(326, 6);
			this.sampleImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.sampleImage.Name = "sampleImage";
			this.sampleImage.Size = new System.Drawing.Size(324, 378);
			this.sampleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.sampleImage.TabIndex = 19;
			this.sampleImage.TabStop = false;
			// 
			// labelLengthSupportValue
			// 
			this.labelLengthSupportValue.AutoSize = true;
			this.labelLengthSupportValue.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.labelLengthSupportValue.Location = new System.Drawing.Point(24, 274);
			this.labelLengthSupportValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelLengthSupportValue.Name = "labelLengthSupportValue";
			this.labelLengthSupportValue.Size = new System.Drawing.Size(92, 20);
			this.labelLengthSupportValue.TabIndex = 18;
			this.labelLengthSupportValue.Text = "(от 400 до)";
			// 
			// labelWidthRackValue
			// 
			this.labelWidthRackValue.AutoSize = true;
			this.labelWidthRackValue.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.labelWidthRackValue.Location = new System.Drawing.Point(24, 226);
			this.labelWidthRackValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelWidthRackValue.Name = "labelWidthRackValue";
			this.labelWidthRackValue.Size = new System.Drawing.Size(61, 20);
			this.labelWidthRackValue.TabIndex = 17;
			this.labelWidthRackValue.Text = "(от до)";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(674, 461);
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "MainForm";
			this.Text = "Вешалка для одежды";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.sampleImage)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelHeight;
		private System.Windows.Forms.Label labelWidthSupport;
		private System.Windows.Forms.Label labelAmtHooks;
		private System.Windows.Forms.Label labelWidthHooks;
		private System.Windows.Forms.Label labelWidthRack;
		private System.Windows.Forms.Label labelLengthSupport;
		private System.Windows.Forms.TextBox textBoxHeigthRack;
		private System.Windows.Forms.TextBox textBoxWidthSupport;
		private System.Windows.Forms.TextBox textBoxAmtHooks;
		private System.Windows.Forms.TextBox textBoxWidthHooks;
		private System.Windows.Forms.TextBox textBoxWidthRack;
		private System.Windows.Forms.TextBox textBoxLengthSupport;
		private System.Windows.Forms.Button buttonBuild;
		private System.Windows.Forms.Label labelHeightValue;
		private System.Windows.Forms.Label labelWidthSupportValue;
		private System.Windows.Forms.Label labelAmtHooksValue;
		private System.Windows.Forms.Label labelWidthHooksValue;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox sampleImage;
		private System.Windows.Forms.Label labelLengthSupportValue;
		private System.Windows.Forms.Label labelWidthRackValue;
		private System.Windows.Forms.Label labelLengthStandValue;
		private System.Windows.Forms.TextBox textBoxLengthStand;
		private System.Windows.Forms.Label labelLengthStand;
	}
}

