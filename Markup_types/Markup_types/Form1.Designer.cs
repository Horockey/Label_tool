
namespace Markup_types
{
	partial class mainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
			this.currentDirrectoryLabel = new System.Windows.Forms.Label();
			this.changeDirectoryButton = new System.Windows.Forms.Button();
			this.currentImgPreviewPB = new System.Windows.Forms.PictureBox();
			this.saveToJsonButton = new System.Windows.Forms.Button();
			this.selectLabelCB = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.currentDirectoryListBox = new System.Windows.Forms.ListBox();
			this.helpButton = new System.Windows.Forms.Button();
			this.previousImageButton = new System.Windows.Forms.Button();
			this.nextImageButton = new System.Windows.Forms.Button();
			this.signature = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.currentImgPreviewPB)).BeginInit();
			this.SuspendLayout();
			// 
			// currentDirrectoryLabel
			// 
			this.currentDirrectoryLabel.AutoSize = true;
			this.currentDirrectoryLabel.Location = new System.Drawing.Point(12, 16);
			this.currentDirrectoryLabel.Name = "currentDirrectoryLabel";
			this.currentDirrectoryLabel.Size = new System.Drawing.Size(112, 15);
			this.currentDirrectoryLabel.TabIndex = 0;
			this.currentDirrectoryLabel.Text = "Directory undefined";
			// 
			// changeDirectoryButton
			// 
			this.changeDirectoryButton.Location = new System.Drawing.Point(12, 34);
			this.changeDirectoryButton.Name = "changeDirectoryButton";
			this.changeDirectoryButton.Size = new System.Drawing.Size(133, 23);
			this.changeDirectoryButton.TabIndex = 1;
			this.changeDirectoryButton.TabStop = false;
			this.changeDirectoryButton.Text = "Change directory";
			this.changeDirectoryButton.UseVisualStyleBackColor = true;
			this.changeDirectoryButton.Click += new System.EventHandler(this.changeDirectoryButton_Click);
			// 
			// currentImgPreviewPB
			// 
			this.currentImgPreviewPB.BackColor = System.Drawing.Color.White;
			this.currentImgPreviewPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.currentImgPreviewPB.Location = new System.Drawing.Point(22, 69);
			this.currentImgPreviewPB.Name = "currentImgPreviewPB";
			this.currentImgPreviewPB.Size = new System.Drawing.Size(400, 400);
			this.currentImgPreviewPB.TabIndex = 2;
			this.currentImgPreviewPB.TabStop = false;
			// 
			// saveToJsonButton
			// 
			this.saveToJsonButton.Location = new System.Drawing.Point(151, 34);
			this.saveToJsonButton.Name = "saveToJsonButton";
			this.saveToJsonButton.Size = new System.Drawing.Size(112, 23);
			this.saveToJsonButton.TabIndex = 3;
			this.saveToJsonButton.TabStop = false;
			this.saveToJsonButton.Text = "Save to JSON";
			this.saveToJsonButton.UseVisualStyleBackColor = true;
			this.saveToJsonButton.Click += new System.EventHandler(this.saveToJsonButton_Click);
			// 
			// selectLabelCB
			// 
			this.selectLabelCB.FormattingEnabled = true;
			this.selectLabelCB.Items.AddRange(new object[] {
            "",
            "Anime",
            "Architecture",
            "Animals",
            "People",
            "Nature",
            "NO_AVATAR"});
			this.selectLabelCB.Location = new System.Drawing.Point(313, 34);
			this.selectLabelCB.Name = "selectLabelCB";
			this.selectLabelCB.Size = new System.Drawing.Size(109, 23);
			this.selectLabelCB.TabIndex = 4;
			this.selectLabelCB.TabStop = false;
			this.selectLabelCB.SelectedIndexChanged += new System.EventHandler(this.selectLabelCB_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(269, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 15);
			this.label1.TabIndex = 5;
			this.label1.Text = "Label:";
			// 
			// currentDirectoryListBox
			// 
			this.currentDirectoryListBox.BackColor = System.Drawing.Color.White;
			this.currentDirectoryListBox.FormattingEnabled = true;
			this.currentDirectoryListBox.ItemHeight = 15;
			this.currentDirectoryListBox.Location = new System.Drawing.Point(428, 69);
			this.currentDirectoryListBox.Name = "currentDirectoryListBox";
			this.currentDirectoryListBox.Size = new System.Drawing.Size(360, 394);
			this.currentDirectoryListBox.TabIndex = 6;
			this.currentDirectoryListBox.SelectedIndexChanged += new System.EventHandler(this.currentDirectoryListBox_SelectedIndexChanged);
			this.currentDirectoryListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.currentDirectoryListBox_KeyDown);
			// 
			// helpButton
			// 
			this.helpButton.Location = new System.Drawing.Point(713, 34);
			this.helpButton.Name = "helpButton";
			this.helpButton.Size = new System.Drawing.Size(75, 23);
			this.helpButton.TabIndex = 7;
			this.helpButton.Text = "Help";
			this.helpButton.UseVisualStyleBackColor = true;
			this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
			// 
			// previousImageButton
			// 
			this.previousImageButton.Location = new System.Drawing.Point(428, 34);
			this.previousImageButton.Name = "previousImageButton";
			this.previousImageButton.Size = new System.Drawing.Size(102, 23);
			this.previousImageButton.TabIndex = 8;
			this.previousImageButton.Text = "Previous image";
			this.previousImageButton.UseVisualStyleBackColor = true;
			this.previousImageButton.Click += new System.EventHandler(this.previousImageButton_Click);
			// 
			// nextImageButton
			// 
			this.nextImageButton.Location = new System.Drawing.Point(536, 34);
			this.nextImageButton.Name = "nextImageButton";
			this.nextImageButton.Size = new System.Drawing.Size(104, 23);
			this.nextImageButton.TabIndex = 9;
			this.nextImageButton.Text = "Next image";
			this.nextImageButton.UseVisualStyleBackColor = true;
			this.nextImageButton.Click += new System.EventHandler(this.nextImageButton_Click);
			// 
			// signature
			// 
			this.signature.AutoSize = true;
			this.signature.ForeColor = System.Drawing.Color.LightGray;
			this.signature.Location = new System.Drawing.Point(689, 466);
			this.signature.Name = "signature";
			this.signature.Size = new System.Drawing.Size(99, 15);
			this.signature.TabIndex = 10;
			this.signature.Text = "@Horockey, 2021";
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
			this.ClientSize = new System.Drawing.Size(800, 486);
			this.Controls.Add(this.signature);
			this.Controls.Add(this.nextImageButton);
			this.Controls.Add(this.previousImageButton);
			this.Controls.Add(this.helpButton);
			this.Controls.Add(this.currentDirectoryListBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.selectLabelCB);
			this.Controls.Add(this.saveToJsonButton);
			this.Controls.Add(this.currentImgPreviewPB);
			this.Controls.Add(this.changeDirectoryButton);
			this.Controls.Add(this.currentDirrectoryLabel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "mainForm";
			this.Text = "Label tool";
			((System.ComponentModel.ISupportInitialize)(this.currentImgPreviewPB)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label currentDirrectoryLabel;
		private System.Windows.Forms.Button changeDirectoryButton;
		private System.Windows.Forms.PictureBox currentImgPreviewPB;
		private System.Windows.Forms.Button saveToJsonButton;
		private System.Windows.Forms.ComboBox selectLabelCB;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox currentDirectoryListBox;
		private System.Windows.Forms.Button helpButton;
		private System.Windows.Forms.Button previousImageButton;
		private System.Windows.Forms.Button nextImageButton;
		private System.Windows.Forms.Label signature;
	}
}

