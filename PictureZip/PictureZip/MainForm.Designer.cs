namespace ImageCompressor
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.selectImageButton = new System.Windows.Forms.Button();
            this.sourcePathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.originalSizeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.scaleComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.qualityLabel = new System.Windows.Forms.Label();
            this.qualityTrackBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.compressButton = new System.Windows.Forms.Button();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.formatComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.customWidthLabel = new System.Windows.Forms.Label();
            this.customWidthTextBox = new System.Windows.Forms.TextBox();
            this.customHeightLabel = new System.Windows.Forms.Label();
            this.customHeightTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qualityTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectImageButton
            // 
            this.selectImageButton.Location = new System.Drawing.Point(485, 12);
            this.selectImageButton.Name = "selectImageButton";
            this.selectImageButton.Size = new System.Drawing.Size(75, 23);
            this.selectImageButton.TabIndex = 0;
            this.selectImageButton.Text = "选择图片";
            this.selectImageButton.UseVisualStyleBackColor = true;
            this.selectImageButton.Click += new System.EventHandler(this.selectImageButton_Click);
            // 
            // sourcePathTextBox
            // 
            this.sourcePathTextBox.Location = new System.Drawing.Point(77, 14);
            this.sourcePathTextBox.Name = "sourcePathTextBox";
            this.sourcePathTextBox.ReadOnly = true;
            this.sourcePathTextBox.Size = new System.Drawing.Size(402, 21);
            this.sourcePathTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "图片路径:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.customHeightTextBox);
            this.groupBox1.Controls.Add(this.customHeightLabel);
            this.groupBox1.Controls.Add(this.customWidthTextBox);
            this.groupBox1.Controls.Add(this.customWidthLabel);
            this.groupBox1.Controls.Add(this.originalSizeLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.scaleComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 150);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "尺寸设置";
            // 
            // originalSizeLabel
            // 
            this.originalSizeLabel.AutoSize = true;
            this.originalSizeLabel.Location = new System.Drawing.Point(96, 22);
            this.originalSizeLabel.Name = "originalSizeLabel";
            this.originalSizeLabel.Size = new System.Drawing.Size(71, 12);
            this.originalSizeLabel.TabIndex = 3;
            this.originalSizeLabel.Text = "原始尺寸: --";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "原始图片信息:";
            // 
            // scaleComboBox
            // 
            this.scaleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scaleComboBox.FormattingEnabled = true;
            this.scaleComboBox.Location = new System.Drawing.Point(96, 47);
            this.scaleComboBox.Name = "scaleComboBox";
            this.scaleComboBox.Size = new System.Drawing.Size(121, 20);
            this.scaleComboBox.TabIndex = 1;
            this.scaleComboBox.SelectedIndexChanged += new System.EventHandler(this.scaleComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "缩放比例设置:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.qualityLabel);
            this.groupBox2.Controls.Add(this.qualityTrackBar);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "质量设置";
            // 
            // qualityLabel
            // 
            this.qualityLabel.AutoSize = true;
            this.qualityLabel.Location = new System.Drawing.Point(189, 22);
            this.qualityLabel.Name = "qualityLabel";
            this.qualityLabel.Size = new System.Drawing.Size(47, 12);
            this.qualityLabel.TabIndex = 2;
            this.qualityLabel.Text = "质量: --";
            // 
            // qualityTrackBar
            // 
            this.qualityTrackBar.Location = new System.Drawing.Point(18, 47);
            this.qualityTrackBar.Name = "qualityTrackBar";
            this.qualityTrackBar.Size = new System.Drawing.Size(224, 45);
            this.qualityTrackBar.TabIndex = 1;
            this.qualityTrackBar.Scroll += new System.EventHandler(this.qualityTrackBar_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "压缩质量设置:";
            // 
            // compressButton
            // 
            this.compressButton.Enabled = false;
            this.compressButton.Location = new System.Drawing.Point(485, 314);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(75, 23);
            this.compressButton.TabIndex = 5;
            this.compressButton.Text = "压缩图片";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.compressButton_Click);
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPictureBox.Location = new System.Drawing.Point(278, 41);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(282, 256);
            this.previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.previewPictureBox.TabIndex = 6;
            this.previewPictureBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.formatComboBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 303);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 50);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "输出格式";
            // 
            // formatComboBox
            // 
            this.formatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatComboBox.FormattingEnabled = true;
            this.formatComboBox.Location = new System.Drawing.Point(96, 17);
            this.formatComboBox.Name = "formatComboBox";
            this.formatComboBox.Size = new System.Drawing.Size(121, 20);
            this.formatComboBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "保存格式设置:";
            // 
            // customWidthLabel
            // 
            this.customWidthLabel.AutoSize = true;
            this.customWidthLabel.Location = new System.Drawing.Point(16, 87);
            this.customWidthLabel.Name = "customWidthLabel";
            this.customWidthLabel.Size = new System.Drawing.Size(41, 12);
            this.customWidthLabel.TabIndex = 4;
            this.customWidthLabel.Text = "宽度:";
            // 
            // customWidthTextBox
            // 
            this.customWidthTextBox.Location = new System.Drawing.Point(96, 84);
            this.customWidthTextBox.Name = "customWidthTextBox";
            this.customWidthTextBox.Size = new System.Drawing.Size(121, 21);
            this.customWidthTextBox.TabIndex = 5;
            // 
            // customHeightLabel
            // 
            this.customHeightLabel.AutoSize = true;
            this.customHeightLabel.Location = new System.Drawing.Point(16, 122);
            this.customHeightLabel.Name = "customHeightLabel";
            this.customHeightLabel.Size = new System.Drawing.Size(41, 12);
            this.customHeightLabel.TabIndex = 6;
            this.customHeightLabel.Text = "高度:";
            // 
            // customHeightTextBox
            // 
            this.customHeightTextBox.Location = new System.Drawing.Point(96, 119);
            this.customHeightTextBox.Name = "customHeightTextBox";
            this.customHeightTextBox.Size = new System.Drawing.Size(121, 21);
            this.customHeightTextBox.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 349);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.previewPictureBox);
            this.Controls.Add(this.compressButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sourcePathTextBox);
            this.Controls.Add(this.selectImageButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "图片压缩工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qualityTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectImageButton;
        private System.Windows.Forms.TextBox sourcePathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label originalSizeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox scaleComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label qualityLabel;
        private System.Windows.Forms.TrackBar qualityTrackBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button compressButton;
        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox formatComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox customHeightTextBox;
        private System.Windows.Forms.Label customHeightLabel;
        private System.Windows.Forms.TextBox customWidthTextBox;
        private System.Windows.Forms.Label customWidthLabel;
    }
}
