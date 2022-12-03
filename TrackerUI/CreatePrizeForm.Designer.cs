namespace TrackerUI
{
    partial class CreatePrizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePrizeForm));
            this.prizeLabel = new System.Windows.Forms.Label();
            this.placeNumberValueTextBox = new System.Windows.Forms.TextBox();
            this.placeNumberLabel = new System.Windows.Forms.Label();
            this.placeNameValueTextBox = new System.Windows.Forms.TextBox();
            this.placeNameLabel = new System.Windows.Forms.Label();
            this.prizeAmountValueTextBox = new System.Windows.Forms.TextBox();
            this.prizeAmountLabel = new System.Windows.Forms.Label();
            this.prizePercentageValueTextBox = new System.Windows.Forms.TextBox();
            this.prizePercentageLabel = new System.Windows.Forms.Label();
            this.orLabel = new System.Windows.Forms.Label();
            this.createPrizeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // prizeLabel
            // 
            this.prizeLabel.AutoSize = true;
            this.prizeLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prizeLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.prizeLabel.Location = new System.Drawing.Point(42, 19);
            this.prizeLabel.Name = "prizeLabel";
            this.prizeLabel.Size = new System.Drawing.Size(129, 30);
            this.prizeLabel.TabIndex = 15;
            this.prizeLabel.Text = "Create Prize";
            // 
            // placeNumberValueTextBox
            // 
            this.placeNumberValueTextBox.Location = new System.Drawing.Point(97, 68);
            this.placeNumberValueTextBox.Name = "placeNumberValueTextBox";
            this.placeNumberValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.placeNumberValueTextBox.TabIndex = 17;
            // 
            // placeNumberLabel
            // 
            this.placeNumberLabel.AutoSize = true;
            this.placeNumberLabel.ForeColor = System.Drawing.Color.Teal;
            this.placeNumberLabel.Location = new System.Drawing.Point(15, 73);
            this.placeNumberLabel.Name = "placeNumberLabel";
            this.placeNumberLabel.Size = new System.Drawing.Size(74, 13);
            this.placeNumberLabel.TabIndex = 16;
            this.placeNumberLabel.Text = "Place Number";
            // 
            // placeNameValueTextBox
            // 
            this.placeNameValueTextBox.Location = new System.Drawing.Point(97, 109);
            this.placeNameValueTextBox.Name = "placeNameValueTextBox";
            this.placeNameValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.placeNameValueTextBox.TabIndex = 19;
            // 
            // placeNameLabel
            // 
            this.placeNameLabel.AutoSize = true;
            this.placeNameLabel.ForeColor = System.Drawing.Color.Teal;
            this.placeNameLabel.Location = new System.Drawing.Point(15, 114);
            this.placeNameLabel.Name = "placeNameLabel";
            this.placeNameLabel.Size = new System.Drawing.Size(65, 13);
            this.placeNameLabel.TabIndex = 18;
            this.placeNameLabel.Text = "Place Name";
            // 
            // prizeAmountValueTextBox
            // 
            this.prizeAmountValueTextBox.Location = new System.Drawing.Point(97, 146);
            this.prizeAmountValueTextBox.Name = "prizeAmountValueTextBox";
            this.prizeAmountValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.prizeAmountValueTextBox.TabIndex = 21;
            this.prizeAmountValueTextBox.Text = "0";
            // 
            // prizeAmountLabel
            // 
            this.prizeAmountLabel.AutoSize = true;
            this.prizeAmountLabel.ForeColor = System.Drawing.Color.Teal;
            this.prizeAmountLabel.Location = new System.Drawing.Point(15, 151);
            this.prizeAmountLabel.Name = "prizeAmountLabel";
            this.prizeAmountLabel.Size = new System.Drawing.Size(69, 13);
            this.prizeAmountLabel.TabIndex = 20;
            this.prizeAmountLabel.Text = "Prize Amount";
            // 
            // prizePercentageValueTextBox
            // 
            this.prizePercentageValueTextBox.Location = new System.Drawing.Point(110, 213);
            this.prizePercentageValueTextBox.Name = "prizePercentageValueTextBox";
            this.prizePercentageValueTextBox.Size = new System.Drawing.Size(83, 20);
            this.prizePercentageValueTextBox.TabIndex = 23;
            this.prizePercentageValueTextBox.Text = "0";
            // 
            // prizePercentageLabel
            // 
            this.prizePercentageLabel.AutoSize = true;
            this.prizePercentageLabel.ForeColor = System.Drawing.Color.Teal;
            this.prizePercentageLabel.Location = new System.Drawing.Point(16, 216);
            this.prizePercentageLabel.Name = "prizePercentageLabel";
            this.prizePercentageLabel.Size = new System.Drawing.Size(88, 13);
            this.prizePercentageLabel.TabIndex = 22;
            this.prizePercentageLabel.Text = "Prize Percentage";
            // 
            // orLabel
            // 
            this.orLabel.AutoSize = true;
            this.orLabel.ForeColor = System.Drawing.Color.Teal;
            this.orLabel.Location = new System.Drawing.Point(73, 181);
            this.orLabel.Name = "orLabel";
            this.orLabel.Size = new System.Drawing.Size(28, 13);
            this.orLabel.TabIndex = 24;
            this.orLabel.Text = "- or -";
            // 
            // createPrizeButton
            // 
            this.createPrizeButton.Location = new System.Drawing.Point(63, 259);
            this.createPrizeButton.Name = "createPrizeButton";
            this.createPrizeButton.Size = new System.Drawing.Size(108, 44);
            this.createPrizeButton.TabIndex = 25;
            this.createPrizeButton.Text = "Create Prize";
            this.createPrizeButton.UseVisualStyleBackColor = true;
            this.createPrizeButton.Click += new System.EventHandler(this.createPrizeButton_Click);
            // 
            // CreatePrizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 350);
            this.Controls.Add(this.createPrizeButton);
            this.Controls.Add(this.orLabel);
            this.Controls.Add(this.prizePercentageValueTextBox);
            this.Controls.Add(this.prizePercentageLabel);
            this.Controls.Add(this.prizeAmountValueTextBox);
            this.Controls.Add(this.prizeAmountLabel);
            this.Controls.Add(this.placeNameValueTextBox);
            this.Controls.Add(this.placeNameLabel);
            this.Controls.Add(this.placeNumberValueTextBox);
            this.Controls.Add(this.placeNumberLabel);
            this.Controls.Add(this.prizeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreatePrizeForm";
            this.Text = "CreatePrizeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label prizeLabel;
        private System.Windows.Forms.TextBox placeNumberValueTextBox;
        private System.Windows.Forms.Label placeNumberLabel;
        private System.Windows.Forms.TextBox placeNameValueTextBox;
        private System.Windows.Forms.Label placeNameLabel;
        private System.Windows.Forms.TextBox prizeAmountValueTextBox;
        private System.Windows.Forms.Label prizeAmountLabel;
        private System.Windows.Forms.TextBox prizePercentageValueTextBox;
        private System.Windows.Forms.Label prizePercentageLabel;
        private System.Windows.Forms.Label orLabel;
        private System.Windows.Forms.Button createPrizeButton;
    }
}